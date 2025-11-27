namespace Repository.Entidades.db_Externa
{
    public class SAPMaestroPrestamos
    {
        public int id { get; set; }
        public string? company { get;set; }
        public string? prestamo_id { get;set; }
        public string? factura_id { get;set; }        
        public string? c_proveedor { get;set; }
        public string? n_proveedor { get; set; }
        public string? code_bank_proveedor { get; set; }
        public string? name_bank_proveedor { get; set; }
        public string? number_bank_acount { get; set; }
        public DateTime? f_creacion { get; set; } = null;
        public DateTime? f_invoice { get; set; } = null;
        public DateTime? f_modificacion { get; set; } = null;
        public DateTime? f_inicial { get; set; } = null;
        public DateTime? f_final { get; set; } = null;
        public int? category_id { get; set; }
        public string? category_text { get; set; }
        public int? prestamo_type_id { get; set; }
        public string? prestamo_type_text { get; set; }
        public decimal? tasa { get; set; }
        public int? dia_pago { get; set; }
        public int? meses_gracia { get; set; }
        public int? plazo { get; set; }
        public string? commets { get; set; }
        public int? bank_id { get; set; }
        public SAP_Maestro_Bancos? Bank { get; set; }
        public int? creditline_id { get; set; }
        public Maestro_Lineas_Credito? CreditLine { get; set; }
        public int? cuotatipo_id { get; set; }
        public Maestro_Cuota_Tipos? CuotaTipo { get; set; }
        public int? condicion_id { get; set; }
        public Condiciones? condiciones { get; set; }
        public decimal? monto_neto { get; set; }
        public decimal? monto_bruto { get; set; }
        public bool? verified { get; set; }
        public int? dias_de_desembolso { get; set; }
        public int? metodo_redondeo { get; set; }

    }
}
