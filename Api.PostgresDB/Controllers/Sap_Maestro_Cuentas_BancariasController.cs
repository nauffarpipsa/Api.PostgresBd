using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SapMaestroCuentasBancariasController : ControllerBase
    {
        private readonly ISap_Maestro_Cuentas_Bancarias _cuentasbancarias;
        public SapMaestroCuentasBancariasController(ISap_Maestro_Cuentas_Bancarias cuentasbancarias)
        {
            _cuentasbancarias = cuentasbancarias;
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<Sap_Maestro_Cuentas_BancariasDTo>>> GetCuentas([FromQuery] string IdCompany) 
        {
            return await _cuentasbancarias.GetALl(IdCompany);
        }
    }
}
