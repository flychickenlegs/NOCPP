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
        public async Task<MessageType> UnlockConnector(Call call)
        {
            string str_retunString = "";

            UnlockConnectorRequest unlockConnReq_payload = new();
            UnlockConnectorResponse unlockConnResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                unlockConnReq_payload = JsonSerializer.Deserialize<UnlockConnectorRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("UnlockConnector succeed.");
                    unlockConnResp_payload.Status = UnlockConnectorResponseStatus.Unlocked;
                }
                else
                {
                    Console.WriteLine("UnlockConnector failed.");
                    unlockConnResp_payload.Status = UnlockConnectorResponseStatus.UnlockFailed; // NotSupported
                }
                callResult.Payload = Utility.CalssToJsonElement(unlockConnResp_payload);
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
