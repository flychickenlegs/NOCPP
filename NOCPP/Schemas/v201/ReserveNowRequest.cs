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
    public partial class ReserveNowRequest_CustomDataType
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
    /// This field specifies the connector type.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum ReserveNowRequest_ConnectorEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"cCCS1")]
        CCCS1 = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"cCCS2")]
        CCCS2 = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"cG105")]
        CG105 = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"cTesla")]
        CTesla = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"cType1")]
        CType1 = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"cType2")]
        CType2 = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"s309-1P-16A")]
        S3091P16A = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"s309-1P-32A")]
        S3091P32A = 7,


        [System.Runtime.Serialization.EnumMember(Value = @"s309-3P-16A")]
        S3093P16A = 8,


        [System.Runtime.Serialization.EnumMember(Value = @"s309-3P-32A")]
        S3093P32A = 9,


        [System.Runtime.Serialization.EnumMember(Value = @"sBS1361")]
        SBS1361 = 10,


        [System.Runtime.Serialization.EnumMember(Value = @"sCEE-7-7")]
        SCEE77 = 11,


        [System.Runtime.Serialization.EnumMember(Value = @"sType2")]
        SType2 = 12,


        [System.Runtime.Serialization.EnumMember(Value = @"sType3")]
        SType3 = 13,


        [System.Runtime.Serialization.EnumMember(Value = @"Other1PhMax16A")]
        Other1PhMax16A = 14,


        [System.Runtime.Serialization.EnumMember(Value = @"Other1PhOver16A")]
        Other1PhOver16A = 15,


        [System.Runtime.Serialization.EnumMember(Value = @"Other3Ph")]
        Other3Ph = 16,


        [System.Runtime.Serialization.EnumMember(Value = @"Pan")]
        Pan = 17,


        [System.Runtime.Serialization.EnumMember(Value = @"wInductive")]
        WInductive = 18,


        [System.Runtime.Serialization.EnumMember(Value = @"wResonant")]
        WResonant = 19,


        [System.Runtime.Serialization.EnumMember(Value = @"Undetermined")]
        Undetermined = 20,


        [System.Runtime.Serialization.EnumMember(Value = @"Unknown")]
        Unknown = 21,


    }

    /// <summary>
    /// Enumeration of possible idToken types.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum ReserveNowRequest_IdTokenEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Central")]
        Central = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"eMAID")]
        EMAID = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"ISO14443")]
        ISO14443 = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"ISO15693")]
        ISO15693 = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"KeyCode")]
        KeyCode = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"Local")]
        Local = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"MacAddress")]
        MacAddress = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"NoAuthorization")]
        NoAuthorization = 7,


    }

    /// <summary>
    /// Contains a case insensitive identifier to use for the authorization and the type of authorization to support multiple forms of identifiers.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ReserveNowRequest_AdditionalInfoType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public ReserveNowRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// This field specifies the additional IdToken.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("additionalIdToken")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(36)]
        public string AdditionalIdToken { get; set; } = default!;

        /// <summary>
        /// This defines the type of the additionalIdToken. This is a custom type, so the implementation needs to be agreed upon by all involved parties.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Type { get; set; } = default!;


    }

    /// <summary>
    /// Contains a case insensitive identifier to use for the authorization and the type of authorization to support multiple forms of identifiers.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ReserveNowRequest_IdTokenType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public ReserveNowRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("additionalInfo")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<ReserveNowRequest_AdditionalInfoType> AdditionalInfo { get; set; } = default!;

        /// <summary>
        /// IdToken is case insensitive. Might hold the hidden id of an RFID tag, but can for example also contain a UUID.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("idToken")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(36)]
        public string IdToken { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public ReserveNowRequest_IdTokenEnumType Type { get; set; } = default!;


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ReserveNowRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public ReserveNowRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Id of reservation.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; } = default!;

        /// <summary>
        /// Date and time at which the reservation expires.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("expiryDateTime")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset ExpiryDateTime { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("connectorType")]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public ReserveNowRequest_ConnectorEnumType ConnectorType { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("idToken")]
        [System.ComponentModel.DataAnnotations.Required]
        public ReserveNowRequest_IdTokenType IdToken { get; set; } = new ReserveNowRequest_IdTokenType();

        /// <summary>
        /// This contains ID of the evse to be reserved.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("evseId")]
        public int EvseId { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("groupIdToken")]
        public ReserveNowRequest_IdTokenType GroupIdToken { get; set; } = default!;


    }
}