namespace Services.Dtos
{
    public class Maestro_ArmortizacionesDto
    {
        public string? prestamo_number { get; set; }
        public int quota_number { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int days { get; set; }
        public decimal capital { get; set; }
        public decimal interest { get; set; }
        public decimal total_quota { get; set; }
        public decimal capital_balance { get; set; }
        public decimal rate { get; set; }
        public decimal TEA { get; set; }
        public Boolean valid { get; set; }
        public Boolean Paid { get; set; }


    }
}
