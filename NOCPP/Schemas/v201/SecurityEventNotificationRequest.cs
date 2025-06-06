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
    public partial class SecurityEventNotificationRequest_CustomDataType
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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SecurityEventNotificationRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SecurityEventNotificationRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Type of the security event. This value should be taken from the Security events list.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Type { get; set; } = default!;

        /// <summary>
        /// Date and time at which the event occurred.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("timestamp")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset Timestamp { get; set; } = default!;

        /// <summary>
        /// Additional information about the occurred security event.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("techInfo")]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public string TechInfo { get; set; } = default!;


    }
}