namespace Repository.Entidades.db_Externa
{
    public class Maestro_Lineas_Credito
    {
        public int ID { get; set; }
        public int company_id { get; set; }

        public string? line_description { get; set; }
        public int? bank_id { get; set; }
        public double? credito { get; set; } 
    }
}
