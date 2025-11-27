using System.ComponentModel.DataAnnotations;

namespace Services.Dtos
{
    public class SAP_Maestro_BancosDto
    {

        public int? bank_id { get; set; }
        public int company_id { get; set; }
        public string? bank_name { get; set; }
        public string? sap_bank_id { get; set; }
        public bool? status { get; set; }
    }

    public class SAP_Maestro_Bancosdto
    {
        [Required]
        public string? bank_name { get; set; }
        public string? sap_bank_id { get; set; }
        public bool? status { get; set; }
    }

    public class SAP_Maestro_BancosDTO
    {
        [Required]
        public int company_id { get; set; }
        [Required]
        public string? bank_name { get; set; }
        public string? sap_bank_id { get; set; }
        public bool? status { get; set; }
    }
    public class SAP_Maestro_BancosDTo
    {

        public int? bank_id { get; set; }
        public string? bank_name { get; set; }
    }
}
