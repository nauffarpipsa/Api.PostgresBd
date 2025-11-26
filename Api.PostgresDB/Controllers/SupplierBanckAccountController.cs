using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Tags ("Supplier Bank Account")]
    [Route("api/[controller]/[action]")]
    public class SupplierBanckAccountController: ControllerBase
    {
        private readonly ISupplierBanckAccount _supplierBanckAccount;
        public SupplierBanckAccountController(ISupplierBanckAccount supplierBanckAccount)
        {
            _supplierBanckAccount = supplierBanckAccount;
        }

        [HttpGet("{company_id:int}")]
        public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetSupplierBackAccount(string company_id)
        {

            return await _supplierBanckAccount.GetAllSupplierBankAccount(company_id);
        }
    }
}
