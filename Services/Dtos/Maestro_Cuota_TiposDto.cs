using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
    public class Maestro_Cuota_TiposDto
    {
        public int company_id { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool status { get; set; }
    }

    public class Maestro_Cuota_TiposDTo
    {
        public int id { get; set; }
        public string? description { get; set; }
        public bool? status { get; set; }
    }


}
