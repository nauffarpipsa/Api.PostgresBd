using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Dtos
{
    public class Maestro_Lineas_CreditoDto
    {

        public int ID { get; set; }
        public string? Line_Description { get; set; }
        public int? BankID { get; set; }
        [NotMapped]
        public string? Bank_Name { get; set; }
        public double? Credito { get; set; }
    }

    public class Maestro_Lineas_CreditoDTO
    {

        public string? Line_Description { get; set; }
        public int? BankID { get; set; }
        public double? Credito { get; set; }

    }
    public class Maestro_Lineas_CreditoDTo
    {

        public int ID { get; set; }
        public string? Line_Description { get; set; }
        public double? Credito { get; set; }

    }
}
