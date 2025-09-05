using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
    public class Maestro_Cuota_TiposDto
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Status { get; set; }
    }

    public class Maestro_Cuota_TiposDTo
    {
        public int ID { get; set; }
        public string? Description { get; set; }

        public bool Status { get; set; }
    }


}
