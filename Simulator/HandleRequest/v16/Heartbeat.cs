using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using NOCPP;
using NOCPP.Interfaces;
using NOCPP.Schemas.v16;

namespace Simulator.HandleRequest.v16
{
    public partial class ResponseHandler : IActionHandler_v16
    {
        public async Task<MessageType> Heartbeat(Call call)
        {
            string str_retunString = "";

            HeartbeatRequest heartReq_payload = new();
            HeartbeatResponse heartResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                heartReq_payload = JsonSerializer.Deserialize<HeartbeatRequest>(call.Payload.GetRawText());

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("Heartbeat succeed.");
                    heartResp_payload.CurrentTime = DateTime.UtcNow;
                }
                else
                {
                    Console.WriteLine("Heartbeat failed.");
                }
                callResult.Payload = Utility.CalssToJsonElement(heartResp_payload);
                str_retunString = Utility.ClassToJsonArray(callResult);
                return callResult;
            }
            catch (JsonException ex)
            {
                callError.ErrorCode = ErrorCodes.ProtocolError;
                str_retunString = Utility.ClassToJsonArray(callError);
                return callError;
                
                throw new ApplicationException("JSON format error: " + ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                callError.ErrorCode = ErrorCodes.InternalError;
                str_retunString = Utility.ClassToJsonArray(callError);
                return callError;
                
                throw new ApplicationException("Other Operation error: " + ex.Message, ex);
            }
        }
    }
}
