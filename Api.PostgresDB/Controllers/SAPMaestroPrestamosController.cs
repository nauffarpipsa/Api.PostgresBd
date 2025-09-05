using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;
using Api.PostgresDB;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SAPMaestroPrestamosController : ControllerBase
    {
        private readonly ISAPMaestroPrestamos _prestamos;

        public SAPMaestroPrestamosController(ISAPMaestroPrestamos prestamos)
        {
            _prestamos = prestamos;
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<PrestamoDTO>>> GetALl()
        {
            return await _prestamos.GetAll();
        }

        [HttpPut]
        public async Task<IActionResult> Update( string prestamo_id, [FromBody] SAPMaestroPrestamosDto enty)
        {
            var model = new SAPMaestroPrestamos
            {
                prestamo_id = prestamo_id,
                tasa = enty.tasa,
                dia_pago = enty.dia_pago,
                meses_gracia = enty.meses_gracia,
                plazo = enty.plazo,
                commets = enty.commets,
                bank_id = enty.bank_id,
                creditline_id = enty.creditline_id,
                cuotatipo_id = enty.cuotatipo_id,
                condicion_id = enty.condicion_id
            };
            var updated = await _prestamos.Update(model);

            if (updated.IsCorrect == true) 
                return Ok();
            else
                return BadRequest(updated.Message);


        }
    }

}
