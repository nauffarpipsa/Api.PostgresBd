using Repository.Entidades.db_Externa;
using System.Text.Json.Serialization;

namespace Api.PostgresDB.VIew
{
    public class SAPMaestroPrestamos
    {
        public string? company { get; set; }
        public string? prestamo_id { get; set; }
        public string? factura_id { get; set; }
        public string? c_proveedor { get; set; }
        public string? n_proveedor { get; set; }
        public DateTime? f_creacion { get; set; }
        public DateTime? f_invoice { get; set; }
        public DateTime? f_modificacion { get; set; }
        public DateTime? f_inicial { get; set; }
        public DateTime? f_final { get; set; }
        public int? category_id { get; set; }
        public string? category_text { get; set; }
        public int? prestamo_type_id { get; set; }
        public string? prestamo_type_text { get; set; }
        public decimal? tasa { get; set; }
        public int? dia_pago { get; set; }
        public int? meses_gracia { get; set; }
        public int? plazo { get; set; }
        public string? commets { get; set; }
        [JsonPropertyName("banco_name")]
        public string? bank_name { get; set; }
        [JsonPropertyName("liniea_credito_desciption")]

        public string? creditline_name { get; set; }

        public decimal? monto_neto { get; set; }
        public decimal? monto_bruto { get; set; }
    }
}
