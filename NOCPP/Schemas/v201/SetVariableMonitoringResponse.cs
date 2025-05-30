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
    public partial class SetVariableMonitoringResponse_CustomDataType
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
    /// The type of this monitor, e.g. a threshold, delta or periodic monitor. 
    /// <br/>
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum SetVariableMonitoringResponse_MonitorEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"UpperThreshold")]
        UpperThreshold = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"LowerThreshold")]
        LowerThreshold = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"Delta")]
        Delta = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"Periodic")]
        Periodic = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"PeriodicClockAligned")]
        PeriodicClockAligned = 4,


    }

    /// <summary>
    /// Status is OK if a value could be returned. Otherwise this will indicate the reason why a value could not be returned.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum SetVariableMonitoringResponse_SetMonitoringStatusEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
        Accepted = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"UnknownComponent")]
        UnknownComponent = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"UnknownVariable")]
        UnknownVariable = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"UnsupportedMonitorType")]
        UnsupportedMonitorType = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"Rejected")]
        Rejected = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"Duplicate")]
        Duplicate = 5,


    }

    /// <summary>
    /// A physical or logical component
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariableMonitoringResponse_ComponentType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariableMonitoringResponse_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("evse")]
        public SetVariableMonitoringResponse_EVSEType Evse { get; set; } = default!;

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
    public partial class SetVariableMonitoringResponse_EVSEType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariableMonitoringResponse_CustomDataType CustomData { get; set; } = default!;

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
    /// Class to hold result of SetVariableMonitoring request.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariableMonitoringResponse_SetMonitoringResultType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariableMonitoringResponse_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Id given to the VariableMonitor by the Charging Station. The Id is only returned when status is accepted. Installed VariableMonitors should have unique id's but the id's of removed Installed monitors should have unique id's but the id's of removed monitors MAY be reused.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("statusInfo")]
        public SetVariableMonitoringResponse_StatusInfoType StatusInfo { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("status")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public SetVariableMonitoringResponse_SetMonitoringStatusEnumType Status { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("type")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public SetVariableMonitoringResponse_MonitorEnumType Type { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("component")]
        [System.ComponentModel.DataAnnotations.Required]
        public SetVariableMonitoringResponse_ComponentType Component { get; set; } = new SetVariableMonitoringResponse_ComponentType();


        [System.Text.Json.Serialization.JsonPropertyName("variable")]
        [System.ComponentModel.DataAnnotations.Required]
        public SetVariableMonitoringResponse_VariableType Variable { get; set; } = new SetVariableMonitoringResponse_VariableType();

        /// <summary>
        /// The severity that will be assigned to an event that is triggered by this monitor. The severity range is 0-9, with 0 as the highest and 9 as the lowest severity level.
        /// <br/>
        /// <br/>The severity levels have the following meaning: +
        /// <br/>*0-Danger* +
        /// <br/>Indicates lives are potentially in danger. Urgent attention is needed and action should be taken immediately. +
        /// <br/>*1-Hardware Failure* +
        /// <br/>Indicates that the Charging Station is unable to continue regular operations due to Hardware issues. Action is required. +
        /// <br/>*2-System Failure* +
        /// <br/>Indicates that the Charging Station is unable to continue regular operations due to software or minor hardware issues. Action is required. +
        /// <br/>*3-Critical* +
        /// <br/>Indicates a critical error. Action is required. +
        /// <br/>*4-Error* +
        /// <br/>Indicates a non-urgent error. Action is required. +
        /// <br/>*5-Alert* +
        /// <br/>Indicates an alert event. Default severity for any type of monitoring event.  +
        /// <br/>*6-Warning* +
        /// <br/>Indicates a warning event. Action may be required. +
        /// <br/>*7-Notice* +
        /// <br/>Indicates an unusual event. No immediate action is required. +
        /// <br/>*8-Informational* +
        /// <br/>Indicates a regular operational event. May be used for reporting, measuring throughput, etc. No action is required. +
        /// <br/>*9-Debug* +
        /// <br/>Indicates information useful to developers for debugging, not useful during operations.
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("severity")]
        public int Severity { get; set; } = default!;


    }

    /// <summary>
    /// Element providing more information about the status.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariableMonitoringResponse_StatusInfoType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariableMonitoringResponse_CustomDataType CustomData { get; set; } = default!;

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

    /// <summary>
    /// Reference key to a component-variable.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class SetVariableMonitoringResponse_VariableType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariableMonitoringResponse_CustomDataType CustomData { get; set; } = default!;

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
    public partial class SetVariableMonitoringResponse
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public SetVariableMonitoringResponse_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("setMonitoringResult")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<SetVariableMonitoringResponse_SetMonitoringResultType> SetMonitoringResult { get; set; } = new System.Collections.ObjectModel.Collection<SetVariableMonitoringResponse_SetMonitoringResultType>();


    }
}