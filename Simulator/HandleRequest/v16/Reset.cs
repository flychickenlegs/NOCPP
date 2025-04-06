using NOCPP.Schemas.v16;
using NOCPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NOCPP.Interfaces;

namespace Simulator.HandleRequest.v16
{
    public partial class ResponseHandler : IActionHandler_v16
    {
        public async Task<MessageType> Reset(Call call)
        {
            string str_retunString = "";

            ResetRequest resetReq_payload = new();
            ResetResponse resetResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                resetReq_payload = JsonSerializer.Deserialize<ResetRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("Reset succeed.");
                    resetResp_payload.Status = ResetResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("Reset failed.");
                    resetResp_payload.Status = ResetResponseStatus.Rejected; 
                }
                callResult.Payload = Utility.CalssToJsonElement(resetResp_payload);
                str_retunString = Utility.ClassToJsonArray(callResult);
                return callResult;
            }
            catch (JsonException ex)
            {
                callError.ErrorCode = ErrorCodes.ProtocolError;
                str_retunString = Utility.ClassToJsonArray(callResult);
                return callError;
                
                throw new ApplicationException("JSON format error: " + ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                callError.ErrorCode = ErrorCodes.InternalError;
                str_retunString = Utility.ClassToJsonArray(callResult);
                return callError;
                
                throw new ApplicationException("Other Operation error: " + ex.Message, ex);
            }
        }
    }
}
