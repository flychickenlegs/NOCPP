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
    public partial class CustomerInformationResponse_CustomDataType
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
    /// Indicates whether the request was accepted.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum CustomerInformationResponse_CustomerInformationStatusEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
        Accepted = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Rejected")]
        Rejected = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"Invalid")]
        Invalid = 2,


    }

    /// <summary>
    /// Element providing more information about the status.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class CustomerInformationResponse_StatusInfoType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public CustomerInformationResponse_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// A predefined code for the reason why the status is returned in this response. The string is case-insensitive.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("reasonCode")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string ReasonCode { get; set; } = default!;

        /// <summary>
        /// Additional text to provide detailed information.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("additionalInfo")]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public string AdditionalInfo { get; set; } = default!;


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class CustomerInformationResponse
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public CustomerInformationResponse_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("status")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public CustomerInformationResponse_CustomerInformationStatusEnumType Status { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("statusInfo")]
        public CustomerInformationResponse_StatusInfoType StatusInfo { get; set; } = default!;


    }
}