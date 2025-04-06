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
    public partial class UpdateFirmwareRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("location")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Uri Location { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("retries")]
        public int Retries { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("retrieveDate")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset RetrieveDate { get; set; } = default!;


        [System.Text.Json.Serialization.JsonPropertyName("retryInterval")]
        public int RetryInterval { get; set; } = default!;


    }
}