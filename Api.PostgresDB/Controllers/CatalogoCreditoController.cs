using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{

    [ApiController]
    [Tags("Catalago de Creditos")]
    [Route("api/[controller]/[action]")]
    public class CatalogoCreditoController : ControllerBase
    {
         private readonly ICreditoCatalogo _catalogoCredito;
        public CatalogoCreditoController(ICreditoCatalogo catalogoCredito)
        {
            _catalogoCredito = catalogoCredito;
        }
        [HttpGet("{company_id:int}")]
        public async Task<ResponseDTO<CatalogoCreditoDto>> GetAll(int company_id)
        {
          return await _catalogoCredito.Get(company_id);
        }
    }
}
