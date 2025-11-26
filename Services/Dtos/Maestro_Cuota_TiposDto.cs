using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
    public class Maestro_Cuota_TiposDto
    {
        [Required]
        public string description { get; set; } = string.Empty;
        public bool status { get; set; }
    }

    public class Maestro_Cuota_TiposDTo
    {
        public int id { get; set; }
        [Required]
        public string? description { get; set; }
        //public bool status { get; set; }
    }

    public class Maestro_Cuota_TiposDTO
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public string? description { get; set; }
        public bool status { get; set; }
    }

     public class Maestro_Cuota_TiposDtoAdd
    {
        public int company_id { get; set; }
        [Required]
        public string description { get; set; } = string.Empty;
        public bool status { get; set; }
    }

    public class Maestro_Cuota_Tiposdto
    {
        public int id { get; set; }
        [Required]
        public string? description { get; set; }
    }
}
