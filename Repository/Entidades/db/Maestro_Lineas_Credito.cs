using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class Maestro_Lineas_Credito
    {
        public int ID { get; set; }
        [Required]
        public int company_id { get; set; }
        [Required]
        public string? line_description { get; set; }
        public int? bank_id { get; set; }
        public double? credito { get; set; }
        public bool? status { get; set; }
        public string? f_creacion { get; set; }
    }
}
