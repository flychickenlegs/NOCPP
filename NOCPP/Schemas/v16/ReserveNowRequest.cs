//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


#nullable enable


namespace NOCPP.Schemas.v16
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ReserveNowRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("connectorId")]
        public int ConnectorId { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("expiryDate")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset ExpiryDate { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("idTag")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string IdTag { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("parentIdTag")]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string ParentIdTag { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("reservationId")]
        public int ReservationId { get; set; } = default!;


    }
}