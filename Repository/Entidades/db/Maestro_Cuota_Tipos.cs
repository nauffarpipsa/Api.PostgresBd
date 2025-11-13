using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class Maestro_Cuota_Tipos
    {
        public int ID { get; set; }
        public string? Description { get; set; } 
        public bool Status { get; set; }
        public string? Creadate { get; set; }
    }
}
