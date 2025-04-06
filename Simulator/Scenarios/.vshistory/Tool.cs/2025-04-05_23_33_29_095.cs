using NOCPP;
using NOCPP.Schemas.v16;
using Simulator.HandleRequest.v16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Simulator.Scenarios
{
    internal partial class ScenarioManager
    {
        public ScenarioManager(ChargePoint cp) 
        {
            //_message = _message;
            _chargePoint = cp;

            _message = _message=  new Message();
            ResponseHandler responseHandler = new ResponseHandler();
            _message.CreateResponseHandler(responseHandler);
        }
        private Message _message;
        private ChargePoint _chargePoint;
        private MessageType _msgType_receive;
        private HandleResult _handleRes_result;
        private MessageType _msgType_result;

        private readonly Dictionary<string, TaskCompletionSource<MessageType>> _dict_waiters = new();

        public Task<MessageType> WaitForMessageAsync(string uniqueId, TimeSpan timeout)
        {
            var tcs = new TaskCompletionSource<MessageType>(TaskCreationOptions.RunContinuationsAsynchronously);
            _dict_waiters[uniqueId] = tcs;

            var cts = new CancellationTokenSource(timeout);
            cts.Token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false);

            return tcs.Task;
        }

        public async Task FeedMessage(string messageJson)
        {
            //_msgType_receive = JsonSerializer.Deserialize<MessageType>(messageJson);
            _handleRes_result = await _message.Handler(messageJson, false);

            _msgType_result = _handleRes_result.Message;
            if (_msgType_result is Call call_result)
            {
                if (_dict_waiters.TryGetValue("", out var tcs))
                {
                    tcs.TrySetResult(call_result);
                    _dict_waiters.Remove("");
                }
            }
            if (_msgType_result is CallResult callRes_result)
            {
                if (_dict_waiters.TryGetValue(callRes_result.UniqueId, out var tcs))
                {
                    tcs.TrySetResult(callRes_result);
                    _dict_waiters.Remove(callRes_result.UniqueId);
                }
            }
            else if (_msgType_result is CallError callErr_result)
            {
                if (_dict_waiters.TryGetValue(callErr_result.UniqueId, out var tcs))
                {
                    tcs.TrySetResult(callErr_result);
                    _dict_waiters.Remove(callErr_result.UniqueId);
                }
            }

            //if (_handleRes_result.IsCall)
            //{
            //    _msgType_result = _handleRes_result.Message;
            //    if (_msgType_result is Call call_result)
            //    {
            //        _chargePoint.SendAsync(Utility.ClassToJsonArray(call_result));
            //    }
            //    if (_msgType_result is CallResult callRes_result)
            //    {
            //        _chargePoint.SendAsync(Utility.ClassToJsonArray(callRes_result));
            //    }
            //    else if (_msgType_result is CallError callErr_result)
            //    {
            //        _chargePoint.SendAsync(Utility.ClassToJsonArray(callErr_result));
            //    }
            //}
            //else
            //{
            //    _msgType_result = _handleRes_result.Message;
            //    if (_msgType_result is Call call_result)
            //    {
            //        tcs.TrySetResult(callRes_result);
            //    }
            //    if (_msgType_result is CallResult callRes_result)
            //    {
            //        if (_dict_waiters.TryGetValue(callRes_result.UniqueId, out var tcs))
            //        {
            //            tcs.TrySetResult(callRes_result);
            //            _dict_waiters.Remove(callRes_result.UniqueId);
            //        }
            //    }
            //    else if (_msgType_result is CallError callErr_result)
            //    {
            //        if (_dict_waiters.TryGetValue(callErr_result.UniqueId, out var tcs))
            //        {
            //            tcs.TrySetResult(callErr_result);
            //            _dict_waiters.Remove(callErr_result.UniqueId);
            //        }
            //    }
            //}


        }

        private async Task CP_Heartbeat(int interval, CancellationToken cancellToken)
        {

            CancellationTokenSource _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellToken);
            await Task.Run(() =>
            {
                DateTimeOffset dt_now = DateTimeOffset.UtcNow;
                //DateTimeOffset dt_nextTime = dt_now.AddSeconds(interval);
                DateTimeOffset dt_nextTime = DateTimeOffset.UtcNow;
                HeartbeatRequest heartbeatRequest = new HeartbeatRequest() { };
                while (true)
                {
                    dt_now = DateTimeOffset.UtcNow;
                    if (dt_now > dt_nextTime)
                    {
                        dt_nextTime = dt_now.AddSeconds(interval);
                        string callHeartbeat = Utility.ClassToJsonArray(new Call()
                        {
                            UniqueId = Guid.NewGuid().ToString(),
                            Action = "Heartbeat",
                            Payload = Utility.CalssToJsonElement(heartbeatRequest)
                        });
                        _chargePoint.SendAsync(callHeartbeat);
                        //Console.WriteLine($"{DateTime.Now:HH:mm:ss.ffffff} [CP] [Sent Heartbeat]");
                    }
                    Task.Delay(10);
                }
            }, _cts.Token
            );
        }

    }
}
