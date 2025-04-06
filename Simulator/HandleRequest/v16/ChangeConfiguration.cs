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
        public async Task<MessageType> ChangeConfiguration(Call call)
        {
            string str_retunString = "";

            ChangeConfigurationRequest chaConfReq_payload = new();
            ChangeConfigurationResponse chaConfResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                chaConfReq_payload = JsonSerializer.Deserialize<ChangeConfigurationRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("ChangeConfiguration succeed.");
                    chaConfResp_payload.Status = ChangeConfigurationResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("ChangeConfiguration failed.");
                    chaConfResp_payload.Status = ChangeConfigurationResponseStatus.Rejected; // RebootRequired, NotSupported
                }
                callResult.Payload = Utility.CalssToJsonElement(chaConfResp_payload);
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
