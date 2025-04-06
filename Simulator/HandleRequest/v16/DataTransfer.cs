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
        public async Task<MessageType> DataTransfer(Call call)
        {
            string str_retunString = "";

            DataTransferRequest dataTrReq_payload = new();
            DataTransferResponse dataTrResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                dataTrReq_payload = JsonSerializer.Deserialize<DataTransferRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("DataTransfer succeed.");
                    dataTrResp_payload.Status = DataTransferResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("DataTransfer failed.");
                    dataTrResp_payload.Status = DataTransferResponseStatus.Rejected; // UnknownMessageId, UnknownVendorId
                }
                callResult.Payload = Utility.CalssToJsonElement(dataTrResp_payload);
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
