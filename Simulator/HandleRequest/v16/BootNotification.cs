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
        public async Task<MessageType> BootNotification(Call call)
        {
            string str_retunString = "";

            BootNotificationRequest bootNotiReq_payload = new();
            BootNotificationResponse bootNotiResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                bootNotiReq_payload = JsonSerializer.Deserialize<BootNotificationRequest>(call.Payload.GetRawText());

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("BootNotification succeed.");
                    bootNotiResp_payload.CurrentTime = Utility.dtOffset_UTCNow;
                    bootNotiResp_payload.Interval = 10;
                    bootNotiResp_payload.Status = BootNotificationResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("BootNotification failed.");
                    bootNotiResp_payload.CurrentTime = Utility.dtOffset_UTCNow;
                    bootNotiResp_payload.Interval = 10;
                    bootNotiResp_payload.Status = BootNotificationResponseStatus.Rejected;
                }
                callResult.Payload = Utility.CalssToJsonElement(bootNotiResp_payload);
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
