using System.Text.Json.Serialization;
namespace Services.Dtos
{
    public class SupplierAccountItemDTO
    {
        [JsonPropertyName("id_proveedor")]
        public string? CBP_UUID { get; set; } 
        [JsonPropertyName("id_cuenta")]
        public string? cbanK_ACCOUNT_ID { get; set; }
        [JsonPropertyName("banco")]
        public string? CBANK_NAME { get; set; }
        [JsonPropertyName("codigo")]
        public string? CBANK_NAT_CODE { get; set; }
    }

}

