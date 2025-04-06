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
    public partial class ResponseHandler: IActionHandler_v16
    {
        public async Task<MessageType> UpdateFirmware(Call call)
        {
            string str_retunString = "";

            UpdateFirmwareRequest updateFirmReq_payload = new();
            UpdateFirmwareResponse updateFirmResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                updateFirmReq_payload = JsonSerializer.Deserialize<UpdateFirmwareRequest>(call.Payload);

                // Write down your logic here.
                Console.WriteLine("UpdateFirmware succeed.");
                callResult.Payload = Utility.CalssToJsonElement(updateFirmResp_payload);
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
