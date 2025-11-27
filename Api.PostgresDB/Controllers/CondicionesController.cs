using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Tags("Condiciones")]
    [Route("api/[controller]/[action]")]
    public class CondicionesController : ControllerBase
    {
        private readonly ICondiciones _condiciones;
        public CondicionesController(ICondiciones condiciones)
        {
            _condiciones = condiciones;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<Condiciones>>> Add([FromBody] CondicionesDto model) 
        {
            var entity = new Condiciones
            { 
                company_id = model.company_id,
                descripcion = model.descripcion,
                status = model.status,
                f_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return await _condiciones.Add(entity);
        }

        [HttpGet("{company_id:int}") ]
        public async Task<ActionResult<ResponseDTO<IEnumerable<CondicionesDTO>>>> GetAll(int company_id)
        {
            return await _condiciones.GetALL(company_id);
        }

        [HttpPut("{id:int}/{company_id:int}")]
        public async Task<ResponseDTO<Condiciones>> Update( int id ,int company_id, [FromBody] CondicionesDTo entity)
        {
            var model = new Condiciones
            {
                ID = id,
                company_id = company_id,
                descripcion = entity.descripcion,
                status = entity.status
            };
            
            return  await _condiciones.Update(model);
         
        }
    }
}
