using NOCPP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOCPP
{
    public class ChargePoint : IChargePoint, IDisposable
    {
        public ChargePoint(string url, string version, CancellationToken cancellToken)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeWs))
            {
                _str_url = url; 
                _bool_url_check = true; 
            }
            else { throw new ArgumentException("Please enter a valid url, e.g. \"ws://localhost:12345\"."); }


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

        }

        private string _str_url;
        private string _str_subProtocol;
        private CancellationTokenSource _cts;
        private CancellationToken _cancellToken;
        private bool _bool_url_check = false, _bool_subProtocol_check = false, _bool_cancellToken_check = false;
        private ClientWebSocket _clientWebSocket;

        public Action<string> OnMessageReceived { get; set; }
        public Action<string> OnMessageSent { get; set; }

        public async Task StartAsync()
        {

            if (_bool_url_check & _bool_subProtocol_check & _bool_cancellToken_check)
            {
                _clientWebSocket = new ClientWebSocket();
                _clientWebSocket.Options.AddSubProtocol(_str_subProtocol);
                _cts = CancellationTokenSource.CreateLinkedTokenSource(_cancellToken);

                try
                {
                    await _clientWebSocket.ConnectAsync(new Uri(_str_url), _cts.Token).ConfigureAwait(false);
                    Console.WriteLine("CP's WebSocket connection has been established.");
                    // Starts the receive loop but does not wait for it to complete,
                    // allowing the server to continue accepting new connections.
                    _ = ReceiveAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"WebSocket connection to CP failed to be established: {e.Message}");
                    StopAsync().Wait(); // Ensure that resources are cleaned up if the connection fails.
                    throw; // Re-throw the exception to let the caller know that the connection failed.
                }
            }
            
        }

        public async Task StopAsync()
        {
            _cts?.Cancel(); // Cancel the receive loop.
            if (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
            {
                await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "The charge point shutdown.", CancellationToken.None).ConfigureAwait(false);
            }
            _clientWebSocket?.Dispose();
            Console.WriteLine("The charge point is down.");
        }

        public async Task SendAsync(string message)
        {
            if (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
            {
                var buffer = Encoding.UTF8.GetBytes(message);
                await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None).ConfigureAwait(false);
                OnMessageSent?.Invoke(message);
            }
        }

        public async Task ReceiveAsync()
        {
            if (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
            {
                byte[] buffer = new byte[1024];
                while (!_cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        WebSocketReceiveResult result = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cts.Token).ConfigureAwait(false);

                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            //Console.WriteLine($"ChargePoint.Receive message= {message}");
                            OnMessageReceived?.Invoke(message);
                        }
                        else if (result.MessageType == WebSocketMessageType.Close)
                        {
                            Console.WriteLine($"The central system closes the connection, CloseStatus: {result.CloseStatus}, CloseDescription: {result.CloseStatusDescription}");
                            await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Confirmation of the central system closure.", CancellationToken.None).ConfigureAwait(false);
                            break; // End receive loop.
                        }
                    }
                    catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                    {
                        Console.WriteLine("The central system force closes the connection.");
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
            _clientWebSocket?.Dispose();
            _cts?.Dispose();
        }
    }
}
