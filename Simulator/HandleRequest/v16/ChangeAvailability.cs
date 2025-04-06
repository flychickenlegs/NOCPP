
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
        public async Task<MessageType> ChangeAvailability(Call call)
        {
            string str_retunString = "";

            ChangeAvailabilityRequest chaAvaReq_payload = new();
            ChangeAvailabilityResponse chaAvaResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                chaAvaReq_payload = JsonSerializer.Deserialize<ChangeAvailabilityRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("ChangeAvailability succeed.");
                    chaAvaResp_payload.Status = ChangeAvailabilityResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("ChangeAvailability failed.");
                    chaAvaResp_payload.Status = ChangeAvailabilityResponseStatus.Rejected;
                }
                callResult.Payload = Utility.CalssToJsonElement(chaAvaResp_payload);
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
