using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CatalogoCreditoController : ControllerBase
    {
         private readonly ICreditoCatalogo _catalogoCredito;
        public CatalogoCreditoController(ICreditoCatalogo catalogoCredito)
        {
            _catalogoCredito = catalogoCredito;
        }
        [HttpGet]
        public async Task<ResponseDTO<CatalogoCreditoDto>> GetAll()
        {
          return await _catalogoCredito.Get();
        }
    }
}
