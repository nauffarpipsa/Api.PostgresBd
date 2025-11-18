using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Tags("Bancos")]
    [Route("api/[controller]/[action]")]
    public class SAP_Maestro_BancosController : ControllerBase
    {
        private readonly ISAP_Maestro_Bancos _masterBanks;
        public SAP_Maestro_BancosController(ISAP_Maestro_Bancos masterBanks)
        {
            _masterBanks = masterBanks;
        }

        [HttpPost]
        public async Task<ResponseDTO<SAP_Maestro_Bancos>> AddBank([FromBody] SAP_Maestro_BancosDTO entity)
        {

            var model = new SAP_Maestro_Bancos
            { 
                company_id = entity.company_id,
                bank_name = entity.bank_name,
                status = entity.status,
                fecha_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return await _masterBanks.Add(model);
        }

        [HttpGet("{company_id:int}")]
        public async Task<ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>>> GetAll(int company_id)
        {
            return await _masterBanks.GetAll(company_id);
        }

        [HttpPut ("{id:int}")]
        public async Task<ResponseDTO<SAP_Maestro_Bancos>> UpdateBank(int id, [FromBody] SAP_Maestro_BancosDTO entity)
        {
            var model = new SAP_Maestro_Bancos
            {
                bank_id = id,
                bank_account_name = entity.bank_name,
                status = entity.status
            };
            return  await _masterBanks.Update(model);
        }


    }
}
