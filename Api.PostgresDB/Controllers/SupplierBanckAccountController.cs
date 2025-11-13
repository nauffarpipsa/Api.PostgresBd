using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SupplierBanckAccountController: ControllerBase
    {
        private readonly ISupplierBanckAccount _supplierBanckAccount;
        public SupplierBanckAccountController(ISupplierBanckAccount supplierBanckAccount)
        {
            _supplierBanckAccount = supplierBanckAccount;
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetSupplierBackAccount([FromQuery] string proveedoresID)
        {

            return await _supplierBanckAccount.GetDataProveedor(1, proveedoresID);
        }

        [HttpGet] 
        public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetSupplierBackAccountSinTask([FromQuery] string proveedoresID)
        {
            return await _supplierBanckAccount.GetDataProveedor(proveedoresID);
        }
    }
}
