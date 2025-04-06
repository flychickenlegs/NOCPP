﻿using System;
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
        public async Task<MessageType> RemoteStopTransaction(Call call)
        {
            string str_retunString = "";

            RemoteStopTransactionRequest rmStopTranReq_payload = new();
            RemoteStopTransactionResponse rmStopTranResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                rmStopTranReq_payload = JsonSerializer.Deserialize<RemoteStopTransactionRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("RemoteStopTransaction succeed.");
                    rmStopTranResp_payload.Status = RemoteStopTransactionResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("RemoteStopTransaction failed.");
                    rmStopTranResp_payload.Status = RemoteStopTransactionResponseStatus.Rejected;
                }
                callResult.Payload = Utility.CalssToJsonElement(rmStopTranResp_payload);
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
