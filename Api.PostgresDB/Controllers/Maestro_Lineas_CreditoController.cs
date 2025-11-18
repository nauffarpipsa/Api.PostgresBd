using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{

    [ApiController]
    [Tags("Linieas de Creditos")]
    [Route("api/[controller]/[action]")]
    public class Maestro_Lineas_CreditoController : ControllerBase
    {

        private readonly IMaestro_Lineas_Credito _maestroLineasCredito;

        public Maestro_Lineas_CreditoController(IMaestro_Lineas_Credito maestroLineasCredito)
        {
            _maestroLineasCredito = maestroLineasCredito;
        }

        [HttpGet("{company_id:int}")]
        public async Task<ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>> GetAll(int company_id)
        {
          return await _maestroLineasCredito.GetAll(company_id);
        }

        [HttpPost]
        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Add([FromBody] Maestro_Lineas_CreditoDTO entity) 
        {
            var model = new Maestro_Lineas_Credito
            {
                company_id = entity.company_id,
                line_description = entity.line_description!.Trim(),
                bank_id= entity.bank_id,
                credito = entity.credito
            };

           return await _maestroLineasCredito.Add(model);
        }

       [HttpPut("{ID:int}")]
        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Update(int ID, [FromBody] Maestro_Lineas_CreditoDTO entity)
        {
           var model = new Maestro_Lineas_Credito
           {
               ID = ID,
               company_id = entity.company_id,
               line_description = entity.line_description!.Trim(),
               bank_id = entity.bank_id,
               credito = entity.credito
           };

           return await _maestroLineasCredito.Update(model);
             
        }

    }
}
