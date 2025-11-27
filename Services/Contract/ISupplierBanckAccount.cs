using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Dtos;

namespace Services.Contract
{
    public interface ISupplierBanckAccount   : IGenericRequest<SupplierBanckAccount>
    {
        //Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetDataProveedor(int taskId, string proveedores);

        Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetAllSupplierBankAccount(string company_id);
    }
}
