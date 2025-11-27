using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Tags("Ordenes de Compras")]
    [Route("api/[controller]/[action]")]
    public class SapMaestroPurchaseOrdersController : ControllerBase
    {
        private readonly ISap_Maesto_Purchase_Orders _Maesto_Purchase_Orders;
        public SapMaestroPurchaseOrdersController(ISap_Maesto_Purchase_Orders Maesto_Purchase_Orders)
        {
            _Maesto_Purchase_Orders = Maesto_Purchase_Orders;
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<PurchaseOrderDto>>> GetPurchase( )
        {
            return await _Maesto_Purchase_Orders.Get();
        }
        [HttpGet]
        public async Task<ResponseDTO<PaginationDTO<PurchaseOrderDto>>> GetPaged([FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {

            return await _Maesto_Purchase_Orders.Get(pageNumber, pageSize);
        }
    }
}
