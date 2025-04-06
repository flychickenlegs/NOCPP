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
    public partial class NotifyChargingLimitRequest_CustomDataType
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
    /// Charging_ Limit. Charging_ Limit_ Source. Charging_ Limit_ Source_ Code
    /// <br/>urn:x-enexis:ecdm:uid:1:570845
    /// <br/>Represents the source of the charging limit.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyChargingLimitRequest_ChargingLimitSourceEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"EMS")]
        EMS = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"Other")]
        Other = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"SO")]
        SO = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"CSO")]
        CSO = 3,


    }

    /// <summary>
    /// Charging_ Schedule. Charging_ Rate_ Unit. Charging_ Rate_ Unit_ Code
    /// <br/>urn:x-oca:ocpp:uid:1:569238
    /// <br/>The unit of measure Limit is expressed in.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyChargingLimitRequest_ChargingRateUnitEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"W")]
        W = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"A")]
        A = 1,


    }

    /// <summary>
    /// Cost. Cost_ Kind. Cost_ Kind_ Code
    /// <br/>urn:x-oca:ocpp:uid:1:569243
    /// <br/>The kind of cost referred to in the message element amount
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum NotifyChargingLimitRequest_CostKindEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"CarbonDioxideEmission")]
        CarbonDioxideEmission = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"RelativePricePercentage")]
        RelativePricePercentage = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"RenewableGenerationPercentage")]
        RenewableGenerationPercentage = 2,


    }

    /// <summary>
    /// Charging_ Limit
    /// <br/>urn:x-enexis:ecdm:uid:2:234489
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_ChargingLimitType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingLimitSource")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyChargingLimitRequest_ChargingLimitSourceEnumType ChargingLimitSource { get; set; } = default!;

        /// <summary>
        /// Charging_ Limit. Is_ Grid_ Critical. Indicator
        /// <br/>urn:x-enexis:ecdm:uid:1:570847
        /// <br/>Indicates whether the charging limit is critical for the grid.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("isGridCritical")]
        public bool IsGridCritical { get; set; } = default!;


    }

    /// <summary>
    /// Charging_ Schedule_ Period
    /// <br/>urn:x-oca:ocpp:uid:2:233257
    /// <br/>Charging schedule period structure defines a time period in a charging schedule.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_ChargingSchedulePeriodType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;

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
    /// Charging_ Schedule
    /// <br/>urn:x-oca:ocpp:uid:2:233256
    /// <br/>Charging schedule structure defines a list of charging periods, as used in: GetCompositeSchedule.conf and ChargingProfile. 
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_ChargingScheduleType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Identifies the ChargingSchedule.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; } = default!;

        /// <summary>
        /// Charging_ Schedule. Start_ Schedule. Date_ Time
        /// <br/>urn:x-oca:ocpp:uid:1:569237
        /// <br/>Starting point of an absolute schedule. If absent the schedule will be relative to start of charging.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("startSchedule")]
        public System.DateTimeOffset StartSchedule { get; set; } = default!;

        /// <summary>
        /// Charging_ Schedule. Duration. Elapsed_ Time
        /// <br/>urn:x-oca:ocpp:uid:1:569236
        /// <br/>Duration of the charging schedule in seconds. If the duration is left empty, the last period will continue indefinitely or until end of the transaction if chargingProfilePurpose = TxProfile.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("duration")]
        public int Duration { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingRateUnit")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyChargingLimitRequest_ChargingRateUnitEnumType ChargingRateUnit { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingSchedulePeriod")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [System.ComponentModel.DataAnnotations.MaxLength(1024)]
        public System.Collections.Generic.ICollection<NotifyChargingLimitRequest_ChargingSchedulePeriodType> ChargingSchedulePeriod { get; set; } = new System.Collections.ObjectModel.Collection<NotifyChargingLimitRequest_ChargingSchedulePeriodType>();

        /// <summary>
        /// Charging_ Schedule. Min_ Charging_ Rate. Numeric
        /// <br/>urn:x-oca:ocpp:uid:1:569239
        /// <br/>Minimum charging rate supported by the EV. The unit of measure is defined by the chargingRateUnit. This parameter is intended to be used by a local smart charging algorithm to optimize the power allocation for in the case a charging process is inefficient at lower charging rates. Accepts at most one digit fraction (e.g. 8.1)
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("minChargingRate")]
        public double MinChargingRate { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("salesTariff")]
        public NotifyChargingLimitRequest_SalesTariffType SalesTariff { get; set; } = default!;


    }

    /// <summary>
    /// Consumption_ Cost
    /// <br/>urn:x-oca:ocpp:uid:2:233259
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_ConsumptionCostType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Consumption_ Cost. Start_ Value. Numeric
        /// <br/>urn:x-oca:ocpp:uid:1:569246
        /// <br/>The lowest level of consumption that defines the starting point of this consumption block. The block interval extends to the start of the next interval.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("startValue")]
        public double StartValue { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("cost")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [System.ComponentModel.DataAnnotations.MaxLength(3)]
        public System.Collections.Generic.ICollection<NotifyChargingLimitRequest_CostType> Cost { get; set; } = new System.Collections.ObjectModel.Collection<NotifyChargingLimitRequest_CostType>();


    }

    /// <summary>
    /// Cost
    /// <br/>urn:x-oca:ocpp:uid:2:233258
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_CostType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("costKind")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public NotifyChargingLimitRequest_CostKindEnumType CostKind { get; set; } = default!;

        /// <summary>
        /// Cost. Amount. Amount
        /// <br/>urn:x-oca:ocpp:uid:1:569244
        /// <br/>The estimated or actual cost per kWh
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("amount")]
        public int Amount { get; set; } = default!;

        /// <summary>
        /// Cost. Amount_ Multiplier. Integer
        /// <br/>urn:x-oca:ocpp:uid:1:569245
        /// <br/>Values: -3..3, The amountMultiplier defines the exponent to base 10 (dec). The final value is determined by: amount * 10 ^ amountMultiplier
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("amountMultiplier")]
        public int AmountMultiplier { get; set; } = default!;


    }

    /// <summary>
    /// Relative_ Timer_ Interval
    /// <br/>urn:x-oca:ocpp:uid:2:233270
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_RelativeTimeIntervalType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Relative_ Timer_ Interval. Start. Elapsed_ Time
        /// <br/>urn:x-oca:ocpp:uid:1:569279
        /// <br/>Start of the interval, in seconds from NOW.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("start")]
        public int Start { get; set; } = default!;

        /// <summary>
        /// Relative_ Timer_ Interval. Duration. Elapsed_ Time
        /// <br/>urn:x-oca:ocpp:uid:1:569280
        /// <br/>Duration of the interval, in seconds.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("duration")]
        public int Duration { get; set; } = default!;


    }

    /// <summary>
    /// Sales_ Tariff_ Entry
    /// <br/>urn:x-oca:ocpp:uid:2:233271
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_SalesTariffEntryType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("relativeTimeInterval")]
        [System.ComponentModel.DataAnnotations.Required]
        public NotifyChargingLimitRequest_RelativeTimeIntervalType RelativeTimeInterval { get; set; } = new NotifyChargingLimitRequest_RelativeTimeIntervalType();

        /// <summary>
        /// Sales_ Tariff_ Entry. E_ Price_ Level. Unsigned_ Integer
        /// <br/>urn:x-oca:ocpp:uid:1:569281
        /// <br/>Defines the price level of this SalesTariffEntry (referring to NumEPriceLevels). Small values for the EPriceLevel represent a cheaper TariffEntry. Large values for the EPriceLevel represent a more expensive TariffEntry.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("ePriceLevel")]
        [System.ComponentModel.DataAnnotations.Range(0, int.MaxValue)]
        public int EPriceLevel { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("consumptionCost")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [System.ComponentModel.DataAnnotations.MaxLength(3)]
        public System.Collections.Generic.ICollection<NotifyChargingLimitRequest_ConsumptionCostType> ConsumptionCost { get; set; } = default!;


    }

    /// <summary>
    /// Sales_ Tariff
    /// <br/>urn:x-oca:ocpp:uid:2:233272
    /// <br/>NOTE: This dataType is based on dataTypes from &amp;lt;&amp;lt;ref-ISOIEC15118-2,ISO 15118-2&amp;gt;&amp;gt;.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest_SalesTariffType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Identified_ Object. MRID. Numeric_ Identifier
        /// <br/>urn:x-enexis:ecdm:uid:1:569198
        /// <br/>SalesTariff identifier used to identify one sales tariff. An SAID remains a unique identifier for one schedule throughout a charging session.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public int Id { get; set; } = default!;

        /// <summary>
        /// Sales_ Tariff. Sales. Tariff_ Description
        /// <br/>urn:x-oca:ocpp:uid:1:569283
        /// <br/>A human readable title/short description of the sales tariff e.g. for HMI display purposes.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("salesTariffDescription")]
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public string SalesTariffDescription { get; set; } = default!;

        /// <summary>
        /// Sales_ Tariff. Num_ E_ Price_ Levels. Counter
        /// <br/>urn:x-oca:ocpp:uid:1:569284
        /// <br/>Defines the overall number of distinct price levels used across all provided SalesTariff elements.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("numEPriceLevels")]
        public int NumEPriceLevels { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("salesTariffEntry")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [System.ComponentModel.DataAnnotations.MaxLength(1024)]
        public System.Collections.Generic.ICollection<NotifyChargingLimitRequest_SalesTariffEntryType> SalesTariffEntry { get; set; } = new System.Collections.ObjectModel.Collection<NotifyChargingLimitRequest_SalesTariffEntryType>();


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class NotifyChargingLimitRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public NotifyChargingLimitRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingSchedule")]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<NotifyChargingLimitRequest_ChargingScheduleType> ChargingSchedule { get; set; } = default!;

        /// <summary>
        /// The charging schedule contained in this notification applies to an EVSE. evseId must be &amp;gt; 0.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("evseId")]
        public int EvseId { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingLimit")]
        [System.ComponentModel.DataAnnotations.Required]
        public NotifyChargingLimitRequest_ChargingLimitType ChargingLimit { get; set; } = new NotifyChargingLimitRequest_ChargingLimitType();


    }
}