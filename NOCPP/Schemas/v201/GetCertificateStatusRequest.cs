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
    public partial class GetCertificateStatusRequest_CustomDataType
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
    /// Used algorithms for the hashes provided.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum GetCertificateStatusRequest_HashAlgorithmEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"SHA256")]
        SHA256 = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"SHA384")]
        SHA384 = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"SHA512")]
        SHA512 = 2,


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetCertificateStatusRequest_OCSPRequestDataType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetCertificateStatusRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("hashAlgorithm")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public GetCertificateStatusRequest_HashAlgorithmEnumType HashAlgorithm { get; set; } = default!;

        /// <summary>
        /// Hashed value of the Issuer DN (Distinguished Name).
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("issuerNameHash")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public string IssuerNameHash { get; set; } = default!;

        /// <summary>
        /// Hashed value of the issuers public key
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("issuerKeyHash")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(128)]
        public string IssuerKeyHash { get; set; } = default!;

        /// <summary>
        /// The serial number of the certificate.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("serialNumber")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(40)]
        public string SerialNumber { get; set; } = default!;

        /// <summary>
        /// This contains the responder URL (Case insensitive). 
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("responderURL")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public string ResponderURL { get; set; } = default!;


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetCertificateStatusRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetCertificateStatusRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("ocspRequestData")]
        [System.ComponentModel.DataAnnotations.Required]
        public GetCertificateStatusRequest_OCSPRequestDataType OcspRequestData { get; set; } = new GetCertificateStatusRequest_OCSPRequestDataType();


    }
}