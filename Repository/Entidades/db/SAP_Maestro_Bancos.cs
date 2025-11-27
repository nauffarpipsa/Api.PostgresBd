using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class SAP_Maestro_Bancos
    {
        [Key]
        public  int? bank_id { get; set; }
        public int company_id { get; set; }
        public string? bank_name { get; set; } 
        public string? sap_bank_id { get; set; }
        public bool? status { get; set; }
        public string? f_creacion { get; set; }
                
    }
}
