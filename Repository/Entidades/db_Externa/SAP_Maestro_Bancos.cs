using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class SAP_Maestro_Bancos
    {
        [Key]
        public  int? BankID { get; set; }
        public string? Bank_Name { get; set; }
        public bool? Status { get; set; }
        public string? FechaCreacion { get; set; }
                
    }
}
