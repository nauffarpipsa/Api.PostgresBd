using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Tags("Cuentas Bancarias")]
    [Route("api/[controller]/[action]")]
    public class SapMaestroCuentasBancariasController : ControllerBase
    {
        private readonly ISap_Maestro_Cuentas_Bancarias _cuentasbancarias;
        public SapMaestroCuentasBancariasController(ISap_Maestro_Cuentas_Bancarias cuentasbancarias)
        {
            _cuentasbancarias = cuentasbancarias;
        }

        [HttpGet("{company_id:int}")]
        public async Task<ResponseDTO<IEnumerable<Sap_Maestro_Cuentas_BancariasDTo>>> GetCuentas(string company_id) 
        {
            return await _cuentasbancarias.GetALl(company_id);
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<AccountBankDTO>>> GetCuentasXOdata()
        {
            return await _cuentasbancarias.GetxOdata();
        }
    }
}
