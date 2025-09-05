using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Maestro_Lineas_CreditoController : ControllerBase
    {

        private readonly IMaestro_Lineas_Credito _maestroLineasCredito;

        public Maestro_Lineas_CreditoController(IMaestro_Lineas_Credito maestroLineasCredito)
        {
            _maestroLineasCredito = maestroLineasCredito;
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>> GetAll()
        {
          return await _maestroLineasCredito.GetAll();
        }

        [HttpPost]
        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Add([FromBody] Maestro_Lineas_CreditoDTO entity) 
        {
            var model = new Maestro_Lineas_Credito
            {
                Line_Description = entity.Line_Description!.Trim(),
                BankID= entity.BankID,
                Credito = entity.Credito
            };

           return await _maestroLineasCredito.Add(model);
        }

       [HttpPut("{ID:int}")]
        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Update(int ID, [FromBody] Maestro_Lineas_CreditoDTO entity)
        {

            //if (!string.IsNullOrEmpty(entity.Line_Description))
            //{
                var model = new Maestro_Lineas_Credito
                {
                    ID = ID,
                    Line_Description = entity.Line_Description!.Trim(),
                    BankID = entity.BankID,
                    Credito = entity.Credito
                };

                return await _maestroLineasCredito.Update(model);
                //return updated.IsCorrect ? Ok() : BadRequest(updated.Message);
            //}
            //else
            //{
            //    return BadRequest($"EL campo {nameof(entity.Line_Description)} está null");
            //}
        }

    }
}
