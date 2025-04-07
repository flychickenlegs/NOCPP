using NOCPP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;

namespace NOCPP
{
    public class Message 
    {
        public async Task<HandleResult?> Handler(string message, bool autoCreateResponse=true)
        {
            int int_jArrLen = 0;
            int int_messageTypeId = 0;
            string str_uniqueId = "";
            string str_action = "";
            JsonElement jEle_payload = new();
            string str_errorCode = "";
            ErrorCodes errorCode = new ErrorCodes();
            string str_errorDescription = "";
            JsonElement jEle_errorDetails = new();
            MessageType msgType_result = null;
            HandleResult msgType_handleResult = null;

            try
            {
                if ((message != "") && (message != null))
                {
                    JsonArray? jArr_message = JsonSerializer.Deserialize<JsonArray>(message);
                    if (jArr_message != null) 
                    {
                        int_jArrLen = jArr_message.Count();
                        int_messageTypeId = (int)jArr_message[0];
                        str_uniqueId = ((string?)jArr_message[1]) ?? throw new JsonException("UniqueId is null");

                        switch (int_messageTypeId)
                        {
                            case 2: // Call
                                str_action = (string?)jArr_message[2] ?? throw new JsonException("Action is null");
                                if (int_jArrLen == 4) { jEle_payload = JsonSerializer.Deserialize<JsonElement>(jArr_message[3]); }
                                // Recoed all request
                                StoreRequest(str_uniqueId, str_action);
                                msgType_result = new Call
                                {
                                    UniqueId = str_uniqueId,
                                    Action = str_action,
                                    Payload = jEle_payload
                                };
                                if (autoCreateResponse)
                                {
                                    msgType_handleResult = new HandleResult()
                                    {
                                        IsCall = true,
                                        Message = await HandleCall((Call)msgType_result)
                                    };
                                }
                                else
                                {
                                    msgType_handleResult = new HandleResult()
                                    {
                                        IsCall = true,
                                        Message = (Call)msgType_result
                                    };
                                }
                                Console.WriteLine("Recived Message: " + JsonSerializer.Serialize((Call)msgType_result, new JsonSerializerOptions
                                {
                                    WriteIndented = true 
                                }));
                                break;

                            case 3: // CallResult
                                if (int_jArrLen == 3) { jEle_payload = JsonSerializer.Deserialize<JsonElement>(jArr_message[2]); }

                                msgType_result = new CallResult
                                {
                                    UniqueId = str_uniqueId,
                                    Payload = jEle_payload
                                };
                                msgType_handleResult = new HandleResult()
                                {
                                    IsCall = false,
                                    Message = (CallResult)msgType_result
                                };
                                Console.WriteLine("Recived Message: " + JsonSerializer.Serialize((CallResult)msgType_result, new JsonSerializerOptions
                                {
                                    WriteIndented = true 
                                }));
                                break;

                            case 4: // CallError
                                str_errorCode = (string?)jArr_message[2] ?? throw new JsonException("ErrorCode is null");
                                str_errorDescription = (string?)jArr_message[3] ?? throw new JsonException("ErrorDescription is null");
                                if (int_jArrLen == 5) { jEle_errorDetails = JsonSerializer.Deserialize<JsonElement>(jArr_message[4]); }
                                errorCode = Enum.Parse<ErrorCodes>(str_errorCode);

                                msgType_result = new CallError
                                {
                                    UniqueId = str_uniqueId,
                                    ErrorCode = errorCode,
                                    ErrorDetails = jEle_errorDetails
                                };
                                msgType_handleResult = new HandleResult()
                                {
                                    IsCall = false,
                                    Message = (CallError)msgType_result
                                };
                                Console.WriteLine("Recived Message: " + JsonSerializer.Serialize((CallError)msgType_result, new JsonSerializerOptions
                                {
                                    WriteIndented = true 
                                }));
                                break;

                            default:
                                throw new JsonException($"Unknown MessageTypeId: {int_messageTypeId}");
                        }
                        return msgType_handleResult;

                    }
                    else
                    {
                        throw new JsonException("String to JsonArray conversion failed, please check if the string format is a valid JSON Array.");
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing the OCPP message: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        #region Recording request history

        private Dictionary<string, string> _dict_requestHistory = new(); 
        /// <summary>
        /// Recording Request
        /// </summary>
        private void StoreRequest(string messageId, string action)
        {
            _dict_requestHistory[messageId] = action;
        }

        /// <summary>
        /// 查詢 Request Action
        /// </summary>
        private string? RetrieveRequestAction(string messageId)
        {
            return _dict_requestHistory.TryGetValue(messageId, out string? action) ? action : null;
        }
        #endregion

        #region Action Handler
        private Dictionary<string, Func<Call, Task<MessageType?>>> _dict_requestHandlers = 
            new Dictionary<string, Func<Call, Task<MessageType?>>>();

        /// <summary>
        /// Registration Action Function
        /// </summary>
        /// <param name="requestHandler"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void CreateRequestHandler(IRequestHandler_v16 requestHandler)
        {
            List<MethodInfo> list_allMethods = new List<MethodInfo>(typeof(IRequestHandler_v16).GetMethods());
            foreach (var baseInterface in typeof(IRequestHandler_v16).GetInterfaces())
            {
                list_allMethods.AddRange(baseInterface.GetMethods());
            }

            foreach (var method in list_allMethods)
            {
                string actionName = method.Name;
                _dict_requestHandlers[actionName] = async (Call call) =>
                {
                    var result = method.Invoke(requestHandler, new object[] { call });
                    if (result is Task<MessageType?> task)
                    {
                        MessageType? msgType_result = await task; 

                        if (msgType_result is CallResult callResult)
                        {
                            return callResult;
                        }
                        else if (msgType_result is CallError callError)
                        {
                            return callError;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Method {actionName} did not return a Task<MessageType?> as expected.");
                    }
                };
            }
        }

        /// <summary>
        /// Registration Action Function
        /// </summary>
        /// <param name="requestHandler"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void CreateRequestHandler(IRequestHandler_v201 requestHandler)
        {
            List<MethodInfo> list_allMethods = new List<MethodInfo>(typeof(IRequestHandler_v201).GetMethods());
            foreach (var baseInterface in typeof(IRequestHandler_v201).GetInterfaces())
            {
                list_allMethods.AddRange(baseInterface.GetMethods());
            }

            foreach (var method in list_allMethods)
            {
                string actionName = method.Name;
                _dict_requestHandlers[actionName] = async (Call call) =>
                {
                    var result = method.Invoke(requestHandler, new object[] { call });
                    if (result is Task<MessageType?> task)
                    {
                        MessageType? msgType_result = await task; 
                        if (msgType_result is CallResult callResult)
                        {
                            return callResult;
                        }
                        else if (msgType_result is CallError callError)
                        {
                            return callError;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Method {actionName} did not return a Task<MessageType?> as expected.");
                    }
                };
            }
        }

        /// <summary>
        /// Handle the input call.
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public async Task<MessageType?> HandleCall(Call call) 
        {
            string str_action = call.Action;
            try
            {

                if (_dict_requestHandlers.ContainsKey(str_action))
                {
                    return await _dict_requestHandlers[str_action].Invoke(call);
                }
                else
                {
                    Console.WriteLine($"Unregistered response: {str_action}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Handling error={ex.Message}");
                throw;
            }
        }
        
        #endregion

    }
}
