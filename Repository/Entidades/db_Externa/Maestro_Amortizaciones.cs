namespace Repository.Entidades.db_Externa
{
    public class Maestro_Amortizaciones
    {
        public int ID { get; set; }
        public string? prestamo_Numer { get; set; }
        public int quota_Numer { get; set; }
        public int days { get; set; }
        public decimal capital { get; set; }
        public decimal interest { get; set; }
        public decimal total_Quota { get; set; }
        public decimal capital_Balance { get; set; }
        public decimal rate { get; set; }
        public decimal TEA { get; set; }
        public Boolean valid { get; set; }
        public Boolean Paid { get; set; }

    }
}
