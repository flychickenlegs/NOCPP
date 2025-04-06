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
        public async Task<MessageType> StartTransaction(Call call)
        {
            string str_retunString = "";

            StartTransactionRequest startTranReq_payload = new();
            StartTransactionResponse startTranResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                startTranReq_payload = JsonSerializer.Deserialize<StartTransactionRequest>(call.Payload.GetRawText());

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("StartTransaction succeed.");
                    startTranResp_payload.IdTagInfo.ExpiryDate = DateTime.UtcNow.AddHours(24);
                    startTranResp_payload.IdTagInfo.Status = StartTransactionResponse_IdTagInfoStatus.Accepted;
                    startTranResp_payload.TransactionId = new Random().Next(1, int.MaxValue);
                }
                else
                {
                    Console.WriteLine("StartTransaction failed.");
                    startTranResp_payload.IdTagInfo.ExpiryDate = DateTime.UtcNow.AddHours(24);
                    startTranResp_payload.IdTagInfo.Status = StartTransactionResponse_IdTagInfoStatus.Invalid; // Blocked, Expired, ConcurrentTx
                }
                callResult.Payload = Utility.CalssToJsonElement(startTranResp_payload);
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
