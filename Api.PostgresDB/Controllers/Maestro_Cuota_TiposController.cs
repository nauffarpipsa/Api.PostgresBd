using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{

    [ApiController]
    [Tags("Tipos de Cuotas")]
    [Route("api/[controller]/[action]")]
    public class Maestro_Cuota_TiposController : ControllerBase
    {
        private readonly IMaestro_Cuota_Tipos _maestro_Cuota_Tipos;
        public Maestro_Cuota_TiposController(IMaestro_Cuota_Tipos maestro_Cuota_Tipos)
        {
            _maestro_Cuota_Tipos = maestro_Cuota_Tipos;
        }
        [HttpGet("{company_id:int}")]
        public async Task<ActionResult<ResponseDTO<IEnumerable<Maestro_Cuota_TiposDTO>>>> GetAll(int company_id)
        {
            return await _maestro_Cuota_Tipos.GetALl(company_id);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO<Maestro_Cuota_Tipos>>> Add([FromBody] Maestro_Cuota_TiposDtoAdd entity)
        {
            var model = new Maestro_Cuota_Tipos
            {
                company_id = entity.company_id,
                description = entity.description!.Trim(),
                status = entity.status,
                f_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return await _maestro_Cuota_Tipos.Add(model);
        }


        [HttpPut("{id:int}/{company_id:int}")]
        public async Task<ResponseDTO<Maestro_Cuota_Tipos>> Update(int id,int company_id, [FromBody] Maestro_Cuota_TiposDto entity)
        {
            var model = new Maestro_Cuota_Tipos
            {
                id = id,
                description = entity.description!.Trim(),
                status = entity.status
            };
           return await _maestro_Cuota_Tipos.Update(model);
        }
    }
}
