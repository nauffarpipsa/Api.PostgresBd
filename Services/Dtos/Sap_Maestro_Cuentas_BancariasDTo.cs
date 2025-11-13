using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class Sap_Maestro_Cuentas_BancariasDTo
    {
        [Column("bank_account_id")]
        public string? BankAccountId { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }
}
