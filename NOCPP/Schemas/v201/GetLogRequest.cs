//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


#nullable enable


namespace NOCPP.Schemas.v201
{
    #pragma warning disable // Disable all warnings

    /// <summary>
    /// This class does not get 'AdditionalProperties = false' in the schema generation, so it can be extended with arbitrary JSON properties to allow adding custom data.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetLogRequest_CustomDataType
    {

        [System.Text.Json.Serialization.JsonPropertyName("vendorId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public string VendorId { get; set; } = default!;



        private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// This contains the type of log file that the Charging Station
    /// <br/>should send.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum GetLogRequest_LogEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"DiagnosticsLog")]
        DiagnosticsLog = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"SecurityLog")]
        SecurityLog = 1,


    }

    /// <summary>
    /// Log
    /// <br/>urn:x-enexis:ecdm:uid:2:233373
    /// <br/>Generic class for the configuration of logging entries.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetLogRequest_LogParametersType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetLogRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Log. Remote_ Location. URI
        /// <br/>urn:x-enexis:ecdm:uid:1:569484
        /// <br/>The URL of the location at the remote system where the log should be stored.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("remoteLocation")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public string RemoteLocation { get; set; } = default!;

        /// <summary>
        /// Log. Oldest_ Timestamp. Date_ Time
        /// <br/>urn:x-enexis:ecdm:uid:1:569477
        /// <br/>This contains the date and time of the oldest logging information to include in the diagnostics.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("oldestTimestamp")]
        public System.DateTimeOffset OldestTimestamp { get; set; } = default!;

        /// <summary>
        /// Log. Latest_ Timestamp. Date_ Time
        /// <br/>urn:x-enexis:ecdm:uid:1:569482
        /// <br/>This contains the date and time of the latest logging information to include in the diagnostics.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("latestTimestamp")]
        public System.DateTimeOffset LatestTimestamp { get; set; } = default!;


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetLogRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetLogRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("log")]
        [System.ComponentModel.DataAnnotations.Required]
        public GetLogRequest_LogParametersType Log { get; set; } = new GetLogRequest_LogParametersType();


        [System.Text.Json.Serialization.JsonPropertyName("logType")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public GetLogRequest_LogEnumType LogType { get; set; } = default!;

        /// <summary>
        /// The Id of this request
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("requestId")]
        public int RequestId { get; set; } = default!;

        /// <summary>
        /// This specifies how many times the Charging Station must try to upload the log before giving up. If this field is not present, it is left to Charging Station to decide how many times it wants to retry.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("retries")]
        public int Retries { get; set; } = default!;

        /// <summary>
        /// The interval in seconds after which a retry may be attempted. If this field is not present, it is left to Charging Station to decide how long to wait between attempts.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("retryInterval")]
        public int RetryInterval { get; set; } = default!;


    }
}