
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Dtos
{
    public class Sap_Maestro_Cuentas_BancariasDTo
    {
        [Column("InternalID")]
        public string? InternalID { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
