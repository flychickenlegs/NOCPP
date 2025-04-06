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
        public async Task<MessageType> StopTransaction(Call call)
        {
            string str_retunString = "";

            StopTransactionRequest stopTranReq_payload = new();
            StopTransactionResponse stopTranResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                stopTranReq_payload = JsonSerializer.Deserialize<StopTransactionRequest>(call.Payload.GetRawText());

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("StopTransaction succeed.");
                    stopTranResp_payload.IdTagInfo = new StopTransactionResponse_IdTagInfo() {
                        ExpiryDate = Utility.dtOffset_UTCNow.AddHours(24),
                        Status = StopTransactionResponse_IdTagInfoStatus.Accepted
                    };
                    //stopTranResp_payload.IdTagInfo.ExpiryDate = Utility.dtOffset_UTCNow.AddHours(24);
                    //stopTranResp_payload.IdTagInfo.Status = StopTransactionResponse_IdTagInfoStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("StopTransaction failed.");
                    stopTranResp_payload.IdTagInfo = new StopTransactionResponse_IdTagInfo()
                    {
                        ExpiryDate = Utility.dtOffset_UTCNow.AddHours(24),
                        Status = StopTransactionResponse_IdTagInfoStatus.Invalid // Blocked, Expired, ConcurrentTx
                    };
                }
                callResult.Payload = Utility.CalssToJsonElement(stopTranResp_payload);
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
