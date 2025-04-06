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
        public async Task<MessageType> ReserveNow(Call call)
        {
            string str_retunString = "";

            ReserveNowRequest resNowReq_payload = new();
            ReserveNowResponse resNowResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                resNowReq_payload = JsonSerializer.Deserialize<ReserveNowRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("ReserveNow succeed.");
                    resNowResp_payload.Status = ReserveNowResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("ReserveNow failed.");
                    resNowResp_payload.Status = ReserveNowResponseStatus.Rejected; // Faulted, Occupied, Unavailable
                }
                callResult.Payload = Utility.CalssToJsonElement(resNowResp_payload);
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
