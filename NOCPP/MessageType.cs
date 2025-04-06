using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Buffers.Text;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NOCPP
{
    /// <summary>
    /// The base class for OCPP messages, containing the general fields MessageTypeId and UniqueId.
    /// </summary>
    public abstract class MessageType
    {
        /// <summary>
        /// Message Type (2 = Call, 3 = CallResult, 4 = CallError)
        /// </summary>
        [JsonPropertyName("messageTypeId")]
        public abstract int MessageTypeId { get; }

        /// <summary>
        /// The message ID serves to identify a request. 
        /// </summary>
        /// <remarks>
        /// A message ID for a CALL message MUST be different from all message IDs previously 
        /// used by the same sender for CALL messages on the same WebSocket connection.
        /// A message ID for a CALLRESULT or CALLERROR message MUST be equal to that of the CALL message that 
        /// the CALLRESULT or CALLERROR message is a response to.
        /// </remarks>
        [JsonPropertyName("uniqueId")]
        public abstract string UniqueId { get; set; }

    }

    /// <summary>
    /// Call Message 
    /// </summary>
    public class Call : MessageType
    {
        [JsonPropertyName("messageTypeId")]
        public override int MessageTypeId => 2; 

        /// <summary>
        /// This is a unique identifier that will be used to match request and result.
        /// </summary>
        [JsonPropertyName("uniqueId")]
        public override string UniqueId { get; set; }

        /// <summary>
        /// The name of the remote procedure or action.
        /// </summary>
        /// <remarks>
        /// This will be a case-sensitive string containing the same value as 
        /// the Action-field in SOAP-based messages, without the preceding slash.
        /// </remarks>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// Payload is a JSON object containing the arguments relevant to the Action.
        /// </summary>
        /// <remarks>
        /// If there is no payload JSON allows for two different notations: null or and empty object {}. 
        /// Although it seems trivial we consider it good practice to only use the empty object statement.
        /// Null usually represents something undefined, which is not the same as empty, and also { } is shorter.
        /// </remarks>
        [JsonPropertyName("payload")]
        public JsonElement Payload { get; set; }
    }

    /// <summary>
    /// CallResult Message 
    /// </summary>
    public class CallResult : MessageType
    {
        [JsonPropertyName("messageTypeId")]
        public override int MessageTypeId => 3; 

        /// <summary>
        /// This must be the exact same ID that is in the call request so that the recipient can match request and result.
        /// </summary>
        [JsonPropertyName("uniqueId")]
        public override string UniqueId { get; set; }

        /// <summary>
        /// Payload is a JSON object containing the results of the executed Action.
        /// </summary>
        /// <remarks>
        /// If there is no payload JSON allows for two different notations: null or and empty object {}. 
        /// Although it seems trivial we consider it good practice to only use the empty object statement.
        /// Null usually represents something undefined, which is not the same as empty, and also { } is shorter.
        /// </remarks>
        [JsonPropertyName("payload")]
        public JsonElement Payload { get; set; }
    }

    /// <summary>
    /// CallError Message (Server-to-Client)
    /// </summary>
    public class CallError : MessageType
    {
        [JsonPropertyName("messageTypeId")]
        public override int MessageTypeId => 4; 

        /// <summary>
        /// This must be the exact same id that is in the call request so that the recipient can match request and result.
        /// </summary>
        [JsonPropertyName("uniqueId")]
        public override string UniqueId { get; set; }

        /// <summary>
        /// This field must contain a string from the ErrorCode table.
        /// </summary>
        [JsonPropertyName("errorCode")]
        public ErrorCodes ErrorCode 
        { 
            get => _ErrorCode;
            set {
                _ErrorCode = value;
                ErrorDescription = value.ToString() switch  
                {
                    "NotImplemented" => "Requested Action is not known by receiver.",
                    "NotSupported" => "Requested Action is recognized but not supported by the receiver.",
                    "InternalError" => "An internal error occurred and the receiver was not able to process the requested Action successfully.",
                    "ProtocolError" => "Payload for Action is incomplete.",
                    "SecurityError" => "During the processing of Action a security issue occurred preventing receiver from completing the Action successfully.",
                    "FormationViolation" => "Payload for Action is syntactically incorrect or not conform the PDU structure for Action.",
                    "PropertyConstraintViolation" => "Payload is syntactically correct but at least one field contains an invalid value.",
                    "OccurenceConstraintViolation" => "Payload for Action is syntactically correct but at least one of the fields violates occurrence constraints.",
                    "TypeConstraintViolation" => "Payload for Action is syntactically correct but at least one of the fields violates data type constraints (e.g. \"somestring\": 12).",
                    "GenericError" => "Any other error not covered by the previous ones.",
                    _ => "Unknown error code."
                };
            } 
        } 
        private ErrorCodes _ErrorCode { get; set; }

        /// <summary>
        /// Should be filled in if possible, otherwise a clear empty string "".
        /// </summary>
        [JsonPropertyName("errorDescription")]
        public string ErrorDescription { get; private set; } = "";

        /// <summary>
        /// This JSON object describes error details in an undefined way.
        /// If there are no error details you MUST fill in an empty object {}.
        /// </summary>
        [JsonPropertyName("errorDetails")]
        public JsonElement ErrorDetails { get; set; }
        //public object ErrorDetails { get; set; }
    }

    /// <summary>
    /// Valid Error Codes.
    /// </summary>
    public enum ErrorCodes
    {
        NotImplemented,
        NotSupported,
        InternalError,
        ProtocolError,
        SecurityError,
        FormationViolation,
        PropertyConstraintViolation,
        OccurenceConstraintViolation,
        TypeConstraintViolation,
        GenericError
    }

    /// <summary>
    /// Message Result (for Message.Handler)
    /// </summary>
    public class HandleResult()
    {
        public bool IsCall { get; set; }
        public MessageType Message { get; set; }
    }


}
