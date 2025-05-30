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
    public partial class DataTransferRequest_CustomDataType
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
    public partial class DataTransferRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public DataTransferRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// May be used to indicate a specific message or implementation.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("messageId")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string MessageId { get; set; } = default!;

        /// <summary>
        /// Data without specified length or format. This needs to be decided by both parties (Open to implementation).
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("data")]
        public object Data { get; set; } = default!;

        /// <summary>
        /// This identifies the Vendor specific implementation
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("vendorId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public string VendorId { get; set; } = default!;


    }
}