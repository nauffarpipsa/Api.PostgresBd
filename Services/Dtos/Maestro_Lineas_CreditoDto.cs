using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Dtos
{
    public class Maestro_Lineas_CreditoDto
    {

        public int ID { get; set; }
        public int company_id { get; set; }
        public string? line_description { get; set; }
        public int? bank_id { get; set; }
        [NotMapped]
        public string? bank_name { get; set; }
        public double? credito { get; set; }
        public bool? status { get; set; }
    }

    public class Maestro_Lineas_CreditoDTO
    {
        public int company_id { get; set; }
        public string? line_description { get; set; }
        public int? bank_id { get; set; }
        public double? credito { get; set; }
        public bool? status { get; set; }

    }
    public class Maestro_Lineas_CreditoDTo
    {

        public int ID { get; set; }
        public int? bank_id { get; set; }
        public string? Line_Description { get; set; }
        public double? Credito { get; set; }

    }

    public class Maestro_Lineas_Creditodto
    {
        public string? line_description { get; set; }
        public int? bank_id { get; set; }
        public double? credito { get; set; }
        public bool? status { get; set; }

    }
}
