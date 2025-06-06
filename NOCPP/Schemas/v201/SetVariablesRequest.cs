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
    public partial class SetVariablesRequest_CustomDataType
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
    /// Type of attribute: Actual, Target, MinSet, MaxSet. Default is Actual when omitted.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum SetVariablesRequest_AttributeEnumType
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
    /// A physical or logical component
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariablesRequest_ComponentType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariablesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("evse")]
        public SetVariablesRequest_EVSEType Evse { get; set; } = default!;

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
    public partial class SetVariablesRequest_EVSEType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariablesRequest_CustomDataType CustomData { get; set; } = default!;

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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariablesRequest_SetVariableDataType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariablesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("attributeType")]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public SetVariablesRequest_AttributeEnumType AttributeType { get; set; } = default!;

        /// <summary>
        /// Value to be assigned to attribute of variable.
        /// <br/>
        /// <br/>The Configuration Variable &amp;lt;&amp;lt;configkey-configuration-value-size,ConfigurationValueSize&amp;gt;&amp;gt; can be used to limit SetVariableData.attributeValue and VariableCharacteristics.valueList. The max size of these values will always remain equal. 
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("attributeValue")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(1000)]
        public string AttributeValue { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("component")]
        [System.ComponentModel.DataAnnotations.Required]
        public SetVariablesRequest_ComponentType Component { get; set; } = new SetVariablesRequest_ComponentType();


        [System.Text.Json.Serialization.JsonPropertyName("variable")]
        [System.ComponentModel.DataAnnotations.Required]
        public SetVariablesRequest_VariableType Variable { get; set; } = new SetVariablesRequest_VariableType();


    }

    /// <summary>
    /// Reference key to a component-variable.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariablesRequest_VariableType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariablesRequest_CustomDataType CustomData { get; set; } = default!;

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
    public partial class SetVariablesRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariablesRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("setVariableData")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<SetVariablesRequest_SetVariableDataType> SetVariableData { get; set; } = new System.Collections.ObjectModel.Collection<SetVariablesRequest_SetVariableDataType>();


    }
}