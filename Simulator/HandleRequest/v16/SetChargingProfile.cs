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
        public async Task<MessageType> SetChargingProfile(Call call)
        {
            string str_retunString = "";

            SetChargingProfileRequest setChProfReq_payload = new();
            SetChargingProfileResponse setChProfResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                setChProfReq_payload = JsonSerializer.Deserialize<SetChargingProfileRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("SetChargingProfile succeed.");
                    setChProfResp_payload.Status = SetChargingProfileResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("SetChargingProfile failed.");
                    setChProfResp_payload.Status = SetChargingProfileResponseStatus.Rejected; // NotSupported
                }
                callResult.Payload = Utility.CalssToJsonElement(setChProfResp_payload);
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
