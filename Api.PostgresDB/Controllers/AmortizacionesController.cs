using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Services.Dtos;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AmortizacionesController : ControllerBase
    {
        private readonly IMaestro_Amortizaciones _maestroAmortizaciones;
        public AmortizacionesController(IMaestro_Amortizaciones maestroAmortizaciones)
        {
            _maestroAmortizaciones = maestroAmortizaciones;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Maestro_ArmortizacionesDto> model)
        {
            var entidades = model.Select(x => new Maestro_Amortizaciones
            {
                prestamo_Numer = x.prestamo_Numer,
                quota_Numer = x.quota_Numer,
                days = x.days,
                capital = x.capital,
                interest = x.interest,
                total_Quota = x.total_Quota,
                capital_Balance = x.capital_Balance,
                rate = x.rate,
                TEA = x.TEA,
                valid = x.valid,
                Paid = x.Paid
            }).ToList();

            var result = await _maestroAmortizaciones.Add(entidades);

            if (!result.IsCorrect) return StatusCode(500, result.Message);
            return Created(nameof(Post), new { inserted = result.Data?.Count() ?? 0 });
        }
    

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<Maestro_Amortizaciones>>> GeAll([FromQuery] string pestamo_number ,bool valid , bool paid )
        {
            return await _maestroAmortizaciones.GetALl(pestamo_number, valid, paid);
        }
    }
}
