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
    public partial class NotifyReportRequest_CustomDataType
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
    /// Attribute: Actual, MinSet, MaxSet, etc.
    /// <br/>Defaults to Actual if absent.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyReportRequest_AttributeEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Actual")]
        Actual = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Target")]
        Target = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"MinSet")]
        MinSet = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"MaxSet")]
        MaxSet = 3,


    }

    /// <summary>
    /// Data type of this variable.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyReportRequest_DataEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"string")]
        String = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"decimal")]
        Decimal = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"integer")]
        Integer = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"dateTime")]
        DateTime = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"boolean")]
        Boolean = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"OptionList")]
        OptionList = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"SequenceList")]
        SequenceList = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"MemberList")]
        MemberList = 7,


    }

    /// <summary>
    /// Defines the mutability of this attribute. Default is ReadWrite when omitted.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyReportRequest_MutabilityEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"ReadOnly")]
        ReadOnly = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"WriteOnly")]
        WriteOnly = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"ReadWrite")]
        ReadWrite = 2,


    }

    /// <summary>
    /// A physical or logical component
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyReportRequest_ComponentType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("evse")]
        public NotifyReportRequest_EVSEType Evse { get; set; } = default!;

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
    public partial class NotifyReportRequest_EVSEType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;

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
    /// Class to report components, variables and variable attributes and characteristics.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyReportRequest_ReportDataType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("component")]
        [System.ComponentModel.DataAnnotations.Required]
        public NotifyReportRequest_ComponentType Component { get; set; } = new NotifyReportRequest_ComponentType();


        [System.Text.Json.Serialization.JsonPropertyName("variable")]
        [System.ComponentModel.DataAnnotations.Required]
        public NotifyReportRequest_VariableType Variable { get; set; } = new NotifyReportRequest_VariableType();


        [System.Text.Json.Serialization.JsonPropertyName("variableAttribute")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [System.ComponentModel.DataAnnotations.MaxLength(4)]
        public System.Collections.Generic.ICollection<NotifyReportRequest_VariableAttributeType> VariableAttribute { get; set; } = new System.Collections.ObjectModel.Collection<NotifyReportRequest_VariableAttributeType>();


        [System.Text.Json.Serialization.JsonPropertyName("variableCharacteristics")]
        public NotifyReportRequest_VariableCharacteristicsType VariableCharacteristics { get; set; } = default!;


    }

    /// <summary>
    /// Attribute data of a variable.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyReportRequest_VariableAttributeType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyReportRequest_AttributeEnumType Type { get; set; } = default!;

        /// <summary>
        /// Value of the attribute. May only be omitted when mutability is set to 'WriteOnly'.
        /// <br/>
        /// <br/>The Configuration Variable &amp;lt;&amp;lt;configkey-reporting-value-size,ReportingValueSize&amp;gt;&amp;gt; can be used to limit GetVariableResult.attributeValue, VariableAttribute.value and EventData.actualValue. The max size of these values will always remain equal. 
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("value")]
        [System.ComponentModel.DataAnnotations.StringLength(2500)]
        public string Value { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("mutability")]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyReportRequest_MutabilityEnumType Mutability { get; set; } = default!;

        /// <summary>
        /// If true, value will be persistent across system reboots or power down. Default when omitted is false.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("persistent")]
        public bool Persistent { get; set; } = false;

        /// <summary>
        /// If true, value that will never be changed by the Charging Station at runtime. Default when omitted is false.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("constant")]
        public bool Constant { get; set; } = false;


    }

    /// <summary>
    /// Fixed read-only parameters of a variable.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyReportRequest_VariableCharacteristicsType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Unit of the variable. When the transmitted value has a unit, this field SHALL be included.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("unit")]
        [System.ComponentModel.DataAnnotations.StringLength(16)]
        public string Unit { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("dataType")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyReportRequest_DataEnumType DataType { get; set; } = default!;

        /// <summary>
        /// Minimum possible value of this variable.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("minLimit")]
        public double MinLimit { get; set; } = default!;

        /// <summary>
        /// Maximum possible value of this variable. When the datatype of this Variable is String, OptionList, SequenceList or MemberList, this field defines the maximum length of the (CSV) string.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("maxLimit")]
        public double MaxLimit { get; set; } = default!;

        /// <summary>
        /// Allowed values when variable is Option/Member/SequenceList. 
        /// <br/>
        /// <br/>* OptionList: The (Actual) Variable value must be a single value from the reported (CSV) enumeration list.
        /// <br/>
        /// <br/>* MemberList: The (Actual) Variable value  may be an (unordered) (sub-)set of the reported (CSV) valid values list.
        /// <br/>
        /// <br/>* SequenceList: The (Actual) Variable value  may be an ordered (priority, etc)  (sub-)set of the reported (CSV) valid values.
        /// <br/>
        /// <br/>This is a comma separated list.
        /// <br/>
        /// <br/>The Configuration Variable &amp;lt;&amp;lt;configkey-configuration-value-size,ConfigurationValueSize&amp;gt;&amp;gt; can be used to limit SetVariableData.attributeValue and VariableCharacteristics.valueList. The max size of these values will always remain equal. 
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("valuesList")]
        [System.ComponentModel.DataAnnotations.StringLength(1000)]
        public string ValuesList { get; set; } = default!;

        /// <summary>
        /// Flag indicating if this variable supports monitoring. 
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("supportsMonitoring")]
        public bool SupportsMonitoring { get; set; } = default!;


    }

    /// <summary>
    /// Reference key to a component-variable.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyReportRequest_VariableType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Name of the variable. Name should be taken from the list of standardized variable names whenever possible. Case Insensitive. strongly advised to use Camel Case.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Name of instance in case the variable exists as multiple instances. Case Insensitive. strongly advised to use Camel Case.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("instance")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Instance { get; set; } = default!;


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyReportRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyReportRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// The id of the GetReportRequest  or GetBaseReportRequest that requested this report
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("requestId")]
        public int RequestId { get; set; } = default!;

        /// <summary>
        /// Timestamp of the moment this message was generated at the Charging Station.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("generatedAt")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset GeneratedAt { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("reportData")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<NotifyReportRequest_ReportDataType> ReportData { get; set; } = default!;

        /// <summary>
        /// “to be continued” indicator. Indicates whether another part of the report follows in an upcoming notifyReportRequest message. Default value when omitted is false.
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tbc")]
        public bool Tbc { get; set; } = false;

        /// <summary>
        /// Sequence number of this message. First message starts at 0.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("seqNo")]
        public int SeqNo { get; set; } = default!;


    }
}