﻿using NOCPP.Schemas.v16;
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
        public async Task<MessageType> GetCompositeSchedule(Call call)
        {
            string str_retunString = "";

            GetCompositeScheduleRequest getCompSchReq_payload = new();
            GetCompositeScheduleResponse getCompSchResp_payload = new();
            CallResult callResult = new();
            CallError callError = new();

            callResult.UniqueId = call.UniqueId;
            callError.UniqueId = call.UniqueId;

            try
            {
                getCompSchReq_payload = JsonSerializer.Deserialize<GetCompositeScheduleRequest>(call.Payload);

                // Write down your logic here.
                if (true)
                {
                    Console.WriteLine("GetCompositeSchedule succeed.");
                    getCompSchResp_payload.Status = GetCompositeScheduleResponseStatus.Accepted;
                }
                else
                {
                    Console.WriteLine("GetCompositeSchedule failed.");
                    getCompSchResp_payload.Status = GetCompositeScheduleResponseStatus.Rejected; 
                }
                callResult.Payload = Utility.CalssToJsonElement(getCompSchResp_payload);
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
