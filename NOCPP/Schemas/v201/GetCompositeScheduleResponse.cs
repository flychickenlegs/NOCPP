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
    public partial class GetCompositeScheduleResponse_CustomDataType
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
    /// The unit of measure Limit is
    /// <br/>expressed in.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum GetCompositeScheduleResponse_ChargingRateUnitEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"W")]
        W = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"A")]
        A = 1,


    }

    /// <summary>
    /// The Charging Station will indicate if it was
    /// <br/>able to process the request
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum GetCompositeScheduleResponse_GenericStatusEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
        Accepted = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Rejected")]
        Rejected = 1,


    }

    /// <summary>
    /// Charging_ Schedule_ Period
    /// <br/>urn:x-oca:ocpp:uid:2:233257
    /// <br/>Charging schedule period structure defines a time period in a charging schedule.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetCompositeScheduleResponse_ChargingSchedulePeriodType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetCompositeScheduleResponse_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Charging_ Schedule_ Period. Start_ Period. Elapsed_ Time
        /// <br/>urn:x-oca:ocpp:uid:1:569240
        /// <br/>Start of the period, in seconds from the start of schedule. The value of StartPeriod also defines the stop time of the previous period.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("startPeriod")]
        public int StartPeriod { get; set; } = default!;

        /// <summary>
        /// Charging_ Schedule_ Period. Limit. Measure
        /// <br/>urn:x-oca:ocpp:uid:1:569241
        /// <br/>Charging rate limit during the schedule period, in the applicable chargingRateUnit, for example in Amperes (A) or Watts (W). Accepts at most one digit fraction (e.g. 8.1).
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public double Limit { get; set; } = default!;

        /// <summary>
        /// Charging_ Schedule_ Period. Number_ Phases. Counter
        /// <br/>urn:x-oca:ocpp:uid:1:569242
        /// <br/>The number of phases that can be used for charging. If a number of phases is needed, numberPhases=3 will be assumed unless another number is given.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("numberPhases")]
        public int NumberPhases { get; set; } = default!;

        /// <summary>
        /// Values: 1..3, Used if numberPhases=1 and if the EVSE is capable of switching the phase connected to the EV, i.e. ACPhaseSwitchingSupported is defined and true. It’s not allowed unless both conditions above are true. If both conditions are true, and phaseToUse is omitted, the Charging Station / EVSE will make the selection on its own.
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("phaseToUse")]
        public int PhaseToUse { get; set; } = default!;


    }

    /// <summary>
    /// Composite_ Schedule
    /// <br/>urn:x-oca:ocpp:uid:2:233362
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetCompositeScheduleResponse_CompositeScheduleType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetCompositeScheduleResponse_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingSchedulePeriod")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<GetCompositeScheduleResponse_ChargingSchedulePeriodType> ChargingSchedulePeriod { get; set; } = new System.Collections.ObjectModel.Collection<GetCompositeScheduleResponse_ChargingSchedulePeriodType>();

        /// <summary>
        /// The ID of the EVSE for which the
        /// <br/>schedule is requested. When evseid=0, the
        /// <br/>Charging Station calculated the expected
        /// <br/>consumption for the grid connection.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("evseId")]
        public int EvseId { get; set; } = default!;

        /// <summary>
        /// Duration of the schedule in seconds.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("duration")]
        public int Duration { get; set; } = default!;

        /// <summary>
        /// Composite_ Schedule. Start. Date_ Time
        /// <br/>urn:x-oca:ocpp:uid:1:569456
        /// <br/>Date and time at which the schedule becomes active. All time measurements within the schedule are relative to this timestamp.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("scheduleStart")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset ScheduleStart { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingRateUnit")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public GetCompositeScheduleResponse_ChargingRateUnitEnumType ChargingRateUnit { get; set; } = default!;


    }

    /// <summary>
    /// Element providing more information about the status.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class GetCompositeScheduleResponse_StatusInfoType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetCompositeScheduleResponse_CustomDataType CustomData { get; set; } = default!;

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
    public partial class GetCompositeScheduleResponse
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public GetCompositeScheduleResponse_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("status")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public GetCompositeScheduleResponse_GenericStatusEnumType Status { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("statusInfo")]
        public GetCompositeScheduleResponse_StatusInfoType StatusInfo { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("schedule")]
        public GetCompositeScheduleResponse_CompositeScheduleType Schedule { get; set; } = default!;


    }
}