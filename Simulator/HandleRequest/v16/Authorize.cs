using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

using NOCPP;
using NOCPP.Interfaces;
using NOCPP.Schemas.v16;

namespace Simulator.HandleRequest.v16
{    
    public partial class ResponseHandler: IActionHandler_v16
    {
        public async Task<MessageType> Authorize(Call call)
        {
            string str_retunString = "";

            AuthorizeRequest authReq_payload = new();
            AuthorizeResponse authResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                authReq_payload = JsonSerializer.Deserialize<AuthorizeRequest>(call.Payload.GetRawText());

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("Authorization succeed.");
                    authResp_payload.IdTagInfo.ExpiryDate = Utility.dtOffset_UTCNow.AddHours(24);
                    authResp_payload.IdTagInfo.Status = AuthorizeResponse_IdTagInfoStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("Authorization failed.");
                    authResp_payload.IdTagInfo.Status = AuthorizeResponse_IdTagInfoStatus.Invalid;
                }
                callResult.Payload = Utility.CalssToJsonElement(authResp_payload);
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
