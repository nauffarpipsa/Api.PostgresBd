using System.ComponentModel.DataAnnotations;

namespace Repository.Entidades.db_Externa
{
    public class Maestro_Cuota_Tipos
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public string? description { get; set; } 
        public bool status { get; set; }
        public string? creadate { get; set; }
    }
}
