using Repository.Entidades.Odatas;

namespace Services.Dtos
{
    public static class SupplierAccountMapper
    {
        public static SupplierAccountItemDTO MapToDto(SupplierBanckAccount s)
        {
            return new SupplierAccountItemDTO
            {
                cbanK_ACCOUNT_ID = s.CBANK_ACCOUNT_ID, // id_cuenta
                CBANK_NAME = s.CBANK_NAME,       // banco
                CBANK_NAT_CODE = s.CBANK_NAT_CODE    // codigo
            };
        }
    }
}
