using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class Condiciones
    {
        public int ID { get; set; }
        [Required]
        public int company_id { get; set; }
        [Required]
        public string? descripcion { get; set; }
        public Boolean? status { get; set; }
        public string? f_creacion { get; set; }
    }
}
