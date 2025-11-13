using Repository.Entidades.db;

namespace Services.Dtos
{
    public class sap_maestro_cuentas_bancariasMapper
    {
        public static Sap_Maestro_Cuentas_BancariasDTo MapToDto(sap_maestro_cuentas_bancarias b)
        {
            return new Sap_Maestro_Cuentas_BancariasDTo
            {
                BankAccountId = b.BankAccountId,
                Description = b.Description
            };
        }
    }
}
