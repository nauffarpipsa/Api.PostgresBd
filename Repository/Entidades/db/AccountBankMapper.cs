
namespace Repository.Entidades.db
{
    public class AccountBankMapper
    {
        public static sap_maestro_cuentas_bancarias MapToDto(sap_maestro_cuentas_bancarias s)
        {
            return new sap_maestro_cuentas_bancarias
            {
                BankAccountId = s.BankAccountId,
                Descripcion   = s.Descripcion
            };
        }
    }
}
