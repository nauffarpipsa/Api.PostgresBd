using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
    public class CondicionesDto
    {
        [Required]
        public int company_id { get; set; }
        [Required]
        public string? descripcion { get; set; }
        public bool? status { get; set; }
    }

    public class CondicionesDTO
    {
        public int ID { get; set; }
        public string? descripcion { get; set; }
        public bool? status { get; set; }
    }

    public class CondicionesDTo
    {
        [Required]
        public string? descripcion { get; set; }
        public bool? status { get; set; }
    }
    public class Condicionesdto
    {
        public int ID { get; set; }
        public string? descripcion { get; set; }
    }

}
