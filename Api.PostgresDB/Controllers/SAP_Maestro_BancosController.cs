using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
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
                Bank_Name = entity.Bank_Name,
                Status = entity.Status,
                FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return await _masterBanks.Add(model);
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>>> GetAll()
        {
            return await _masterBanks.GetAll();
        }

        [HttpPut ("{id:int}")]
        public async Task<ResponseDTO<SAP_Maestro_Bancos>> UpdateBank(int id, [FromBody] SAP_Maestro_BancosDTO entity)
        {
            var model = new SAP_Maestro_Bancos
            {
                BankID = id,
                Bank_Name = entity.Bank_Name,
                Status = entity.Status
            };
            return  await _masterBanks.Update(model);

            //return updated.IsCorrect ? Ok() : BadRequest(updated.Message);
        }


    }
}
