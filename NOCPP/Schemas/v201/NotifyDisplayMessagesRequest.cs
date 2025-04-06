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
    public partial class NotifyDisplayMessagesRequest_CustomDataType
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
    /// Message_ Content. Format. Message_ Format_ Code
    /// <br/>urn:x-enexis:ecdm:uid:1:570848
    /// <br/>Format of the message.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyDisplayMessagesRequest_MessageFormatEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"ASCII")]
        ASCII = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"HTML")]
        HTML = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"URI")]
        URI = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"UTF8")]
        UTF8 = 3,


    }

    /// <summary>
    /// Message_ Info. Priority. Message_ Priority_ Code
    /// <br/>urn:x-enexis:ecdm:uid:1:569253
    /// <br/>With what priority should this message be shown
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyDisplayMessagesRequest_MessagePriorityEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"AlwaysFront")]
        AlwaysFront = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"InFront")]
        InFront = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"NormalCycle")]
        NormalCycle = 2,


    }

    /// <summary>
    /// Message_ Info. State. Message_ State_ Code
    /// <br/>urn:x-enexis:ecdm:uid:1:569254
    /// <br/>During what state should this message be shown. When omitted this message should be shown in any state of the Charging Station.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyDisplayMessagesRequest_MessageStateEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Charging")]
        Charging = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Faulted")]
        Faulted = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"Idle")]
        Idle = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"Unavailable")]
        Unavailable = 3,


    }

    /// <summary>
    /// A physical or logical component
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyDisplayMessagesRequest_ComponentType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyDisplayMessagesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("evse")]
        public NotifyDisplayMessagesRequest_EVSEType Evse { get; set; } = default!;

        /// <summary>
        /// Name of the component. Name should be taken from the list of standardized component names whenever possible. Case Insensitive. strongly advised to use Camel Case.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Name of instance in case the component exists as multiple instances. Case Insensitive. strongly advised to use Camel Case.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("instance")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Instance { get; set; } = default!;


    }

    /// <summary>
    /// EVSE
    /// <br/>urn:x-oca:ocpp:uid:2:233123
    /// <br/>Electric Vehicle Supply Equipment
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyDisplayMessagesRequest_EVSEType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyDisplayMessagesRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Identified_ Object. MRID. Numeric_ Identifier
        /// <br/>urn:x-enexis:ecdm:uid:1:569198
        /// <br/>EVSE Identifier. This contains a number (&amp;gt; 0) designating an EVSE of the Charging Station.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; } = default!;

        /// <summary>
        /// An id to designate a specific connector (on an EVSE) by connector index number.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("connectorId")]
        public int ConnectorId { get; set; } = default!;


    }

    /// <summary>
    /// Message_ Content
    /// <br/>urn:x-enexis:ecdm:uid:2:234490
    /// <br/>Contains message details, for a message to be displayed on a Charging Station.
    /// <br/>
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyDisplayMessagesRequest_MessageContentType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyDisplayMessagesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("format")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyDisplayMessagesRequest_MessageFormatEnumType Format { get; set; } = default!;

        /// <summary>
        /// Message_ Content. Language. Language_ Code
        /// <br/>urn:x-enexis:ecdm:uid:1:570849
        /// <br/>Message language identifier. Contains a language code as defined in &amp;lt;&amp;lt;ref-RFC5646,[RFC5646]&amp;gt;&amp;gt;.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("language")]
        [System.ComponentModel.DataAnnotations.StringLength(8)]
        public string Language { get; set; } = default!;

        /// <summary>
        /// Message_ Content. Content. Message
        /// <br/>urn:x-enexis:ecdm:uid:1:570852
        /// <br/>Message contents.
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("content")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public string Content { get; set; } = default!;


    }

    /// <summary>
    /// Message_ Info
    /// <br/>urn:x-enexis:ecdm:uid:2:233264
    /// <br/>Contains message details, for a message to be displayed on a Charging Station.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyDisplayMessagesRequest_MessageInfoType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyDisplayMessagesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("display")]
        public NotifyDisplayMessagesRequest_ComponentType Display { get; set; } = default!;

        /// <summary>
        /// Identified_ Object. MRID. Numeric_ Identifier
        /// <br/>urn:x-enexis:ecdm:uid:1:569198
        /// <br/>Master resource identifier, unique within an exchange context. It is defined within the OCPP context as a positive Integer value (greater or equal to zero).
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("priority")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyDisplayMessagesRequest_MessagePriorityEnumType Priority { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("state")]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyDisplayMessagesRequest_MessageStateEnumType State { get; set; } = default!;

        /// <summary>
        /// Message_ Info. Start. Date_ Time
        /// <br/>urn:x-enexis:ecdm:uid:1:569256
        /// <br/>From what date-time should this message be shown. If omitted: directly.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("startDateTime")]
        public System.DateTimeOffset StartDateTime { get; set; } = default!;

        /// <summary>
        /// Message_ Info. End. Date_ Time
        /// <br/>urn:x-enexis:ecdm:uid:1:569257
        /// <br/>Until what date-time should this message be shown, after this date/time this message SHALL be removed.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("endDateTime")]
        public System.DateTimeOffset EndDateTime { get; set; } = default!;

        /// <summary>
        /// During which transaction shall this message be shown.
        /// <br/>Message SHALL be removed by the Charging Station after transaction has
        /// <br/>ended.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("transactionId")]
        [System.ComponentModel.DataAnnotations.StringLength(36)]
        public string TransactionId { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("message")]
        [System.ComponentModel.DataAnnotations.Required]
        public NotifyDisplayMessagesRequest_MessageContentType Message { get; set; } = new NotifyDisplayMessagesRequest_MessageContentType();


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyDisplayMessagesRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyDisplayMessagesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("messageInfo")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<NotifyDisplayMessagesRequest_MessageInfoType> MessageInfo { get; set; } = default!;

        /// <summary>
        /// The id of the &amp;lt;&amp;lt;getdisplaymessagesrequest,GetDisplayMessagesRequest&amp;gt;&amp;gt; that requested this message.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("requestId")]
        public int RequestId { get; set; } = default!;

        /// <summary>
        /// "to be continued" indicator. Indicates whether another part of the report follows in an upcoming NotifyDisplayMessagesRequest message. Default value when omitted is false.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tbc")]
        public bool Tbc { get; set; } = false;


    }
}