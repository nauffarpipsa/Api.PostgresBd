using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class Maestro_Cuota_Tipos
    {
        public int id { get; set; }
        [Required]
        public int company_id { get; set; }
        [Required]
        public string? description { get; set; } 
        public bool status { get; set; }
        public string? f_creacion { get; set; }
    }
}
