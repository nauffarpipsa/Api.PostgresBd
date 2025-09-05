using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
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
                descripcion = model.descripcion,
                f_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return await _condiciones.Add(entity);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<IEnumerable<CondicionesDTO>>>> GetAll()
        {
            return await _condiciones.GetALL();
        }
    }
}
