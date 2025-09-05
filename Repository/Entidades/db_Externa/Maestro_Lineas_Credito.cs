namespace Repository.Entidades.db_Externa
{
    public class Maestro_Lineas_Credito
    {
        public int ID { get; set; }
        public string? Line_Description { get; set; }
        public int? BankID { get; set; }
        public double? Credito { get; set; } 
    }
}
