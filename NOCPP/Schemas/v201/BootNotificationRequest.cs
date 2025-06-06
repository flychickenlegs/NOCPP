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
    public partial class BootNotificationRequest_CustomDataType
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
    /// This contains the reason for sending this message to the CSMS.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum BootNotificationRequest_BootReasonEnumType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"ApplicationReset")]
        ApplicationReset = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"FirmwareUpdate")]
        FirmwareUpdate = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"LocalReset")]
        LocalReset = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"PowerUp")]
        PowerUp = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"RemoteReset")]
        RemoteReset = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"ScheduledReset")]
        ScheduledReset = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"Triggered")]
        Triggered = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"Unknown")]
        Unknown = 7,


        [System.Runtime.Serialization.EnumMember(Value = @"Watchdog")]
        Watchdog = 8,


    }

    /// <summary>
    /// Charge_ Point
    /// <br/>urn:x-oca:ocpp:uid:2:233122
    /// <br/>The physical system where an Electrical Vehicle (EV) can be charged.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class BootNotificationRequest_ChargingStationType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public BootNotificationRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Device. Serial_ Number. Serial_ Number
        /// <br/>urn:x-oca:ocpp:uid:1:569324
        /// <br/>Vendor-specific device identifier.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("serialNumber")]
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        public string SerialNumber { get; set; } = default!;

        /// <summary>
        /// Device. Model. CI20_ Text
        /// <br/>urn:x-oca:ocpp:uid:1:569325
        /// <br/>Defines the model of the device.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("model")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string Model { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("modem")]
        public BootNotificationRequest_ModemType Modem { get; set; } = default!;

        /// <summary>
        /// Identifies the vendor (not necessarily in a unique manner).
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("vendorName")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string VendorName { get; set; } = default!;

        /// <summary>
        /// This contains the firmware version of the Charging Station.
        /// <br/>
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("firmwareVersion")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string FirmwareVersion { get; set; } = default!;


    }

    /// <summary>
    /// Wireless_ Communication_ Module
    /// <br/>urn:x-oca:ocpp:uid:2:233306
    /// <br/>Defines parameters required for initiating and maintaining wireless communication with other devices.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class BootNotificationRequest_ModemType
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public BootNotificationRequest_CustomDataType CustomData { get; set; } = default!;

        /// <summary>
        /// Wireless_ Communication_ Module. ICCID. CI20_ Text
        /// <br/>urn:x-oca:ocpp:uid:1:569327
        /// <br/>This contains the ICCID of the modem’s SIM card.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("iccid")]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string Iccid { get; set; } = default!;

        /// <summary>
        /// Wireless_ Communication_ Module. IMSI. CI20_ Text
        /// <br/>urn:x-oca:ocpp:uid:1:569328
        /// <br/>This contains the IMSI of the modem’s SIM card.
        /// <br/>
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("imsi")]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string Imsi { get; set; } = default!;


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class BootNotificationRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("customData")]
        public BootNotificationRequest_CustomDataType CustomData { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("chargingStation")]
        [System.ComponentModel.DataAnnotations.Required]
        public BootNotificationRequest_ChargingStationType ChargingStation { get; set; } = new BootNotificationRequest_ChargingStationType();


        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public BootNotificationRequest_BootReasonEnumType Reason { get; set; } = default!;


    }
}