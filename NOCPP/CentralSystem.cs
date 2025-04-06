using NOCPP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;



namespace NOCPP
{
    public class CentralSystem : ICentralSystem, IDisposable
    {
        public CentralSystem(string url, string version, CancellationToken cancellToken, X509Certificate2 rootCert = null, X509Certificate2 cert=null) 
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp ))
            {
                _str_url = url;
                _bool_url_check = true;
            }
            else { throw new ArgumentException("Please enter a valid url, e.g. \"http://localhost:12345\"."); }


            if (Utility.dict_ocppVersion.TryGetValue(version, out _str_subProtocol))
            { _bool_subProtocol_check = true; }
            else { throw new ArgumentException("Please enter a valid version, e.g. \"1.6\" or \"2.0.1\"."); }

            if (cancellToken != CancellationToken.None)
            { 
                _bool_cancellToken_check = true;
                _cancellToken = cancellToken;
            }
            else
            { throw new ArgumentException("Please enter a valid \"CancellationToken\"."); }

            if (_bool_url_check & _bool_subProtocol_check & _bool_cancellToken_check & _bool_cert_check)
            { StartAsync(); }
            

        }

        private string _str_url;
        private string _str_subProtocol;
        private CancellationTokenSource _cts;
        private CancellationToken _cancellToken;
        private X509Certificate2 _certificate;
        private bool _bool_url_check = false, _bool_subProtocol_check = false, _bool_cancellToken_check = false, _bool_cert_check = false;
        private HttpListener _listener;
        private WebSocket _webSocket;

        public Action<string> OnMessageReceived { get; set; }
        public Action<string> OnMessageSent { get; set; }

        public async Task StartAsync()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(_str_url);
            _listener.Start();
            _cts = CancellationTokenSource.CreateLinkedTokenSource(_cancellToken);

            while (!_cts.Token.IsCancellationRequested)
            {
                HttpListenerContext context = await _listener.GetContextAsync().ConfigureAwait(false);
                if (context.Request.IsWebSocketRequest)
                {
                    if (context.Request.Headers["Sec-WebSocket-Protocol"] == _str_subProtocol)
                    {
                        WebSocketContext webSocketContext = null;
                        try
                        {
                            webSocketContext = await context.AcceptWebSocketAsync(_str_subProtocol).ConfigureAwait(false);
                            _webSocket = webSocketContext.WebSocket;
                            Console.WriteLine("CS's WebSocket connection has been established");
                            // Starts the receive loop but does not wait for it to complete,
                            // allowing the server to continue accepting new connections.
                            _ = ReceiveAsync();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"WebSocket connection to CS failed to be established: {e.Message}");
                            if (webSocketContext != null)
                            {
                                webSocketContext.WebSocket.Abort();
                            }
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                        Console.WriteLine($"Unaccepted Sec-WebSocket-Protocol: {context.Request.Headers["Sec-WebSocket-Protocol"]}");
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        public async Task StopAsync()
        {
            _cts?.Cancel(); // Cancel the receive loop.
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "The central system shutdown.", CancellationToken.None).ConfigureAwait(false);
            }
            _listener?.Stop();
            _listener?.Close();
            Console.WriteLine("The central system is down.");
        }

        public async Task SendAsync(string message)
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None).ConfigureAwait(false);
                OnMessageSent?.Invoke(message);
            }
        }

        public async Task ReceiveAsync()
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = new byte[1024];
                while (!_cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cts.Token).ConfigureAwait(false);

                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            //Console.WriteLine($"CentralSystem.Receive message= {message}");
                            OnMessageReceived?.Invoke(message);
                        }
                        else if (result.MessageType == WebSocketMessageType.Close)
                        {
                            Console.WriteLine($"The charge point closes the connection, CloseStatus: {result.CloseStatus}, CloseDescription: {result.CloseStatusDescription}");
                            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Confirmation of the charge point closure.", CancellationToken.None).ConfigureAwait(false);
                            break; // End receive loop.
                        }
                    }
                    catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                    {
                        Console.WriteLine("The charge point force closes the connection.");
                        break; // End receive loop.
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("The receiving task is canceled.");
                        break; // End receive loop, because CancellationToken was triggered.
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while receiving a message: {ex.Message}");
                        break; // End receive loop.
                    }
                }
            }
        }

        public void Dispose()
        {
            _listener?.Stop();
            _listener?.Close();
            _webSocket?.Dispose();
            _cts?.Dispose();
        }


    }
}
