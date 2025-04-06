
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
        public async Task<MessageType> GetLocalListVersion(Call call)
        {
            string str_retunString = "";

            GetLocalListVersionRequest getLocListReq_payload = new();
            GetLocalListVersionResponse getLocListResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                getLocListReq_payload = JsonSerializer.Deserialize<GetLocalListVersionRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("GetLocalListVersion succeed.");
                    getLocListResp_payload.ListVersion = 0;
                }
                else
                {
                    Console.WriteLine("GetLocalListVersion failed.");
                }
                callResult.Payload = Utility.CalssToJsonElement(getLocListResp_payload);
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
