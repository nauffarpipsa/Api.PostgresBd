using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;

namespace Api.PostgresDB.Controllers
{
    [ApiController]
    [Tags("Historial de Tasas")]
    [Route("api/[controller]/[action]")]
    public class HistoryRatesController : ControllerBase
    {
        private readonly IMaestro_Historial_Tasas _historyRates;

        public HistoryRatesController(IMaestro_Historial_Tasas historyRates)
        {
            _historyRates = historyRates;
        }
        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetForID(string PrestamoID) 
        {
            return await _historyRates.GetAll(PrestamoID);
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetHistoryRate() 
        {
            return await _historyRates.GetAll();
        }


        [HttpPost]
        public async Task<ResponseDTO<SAP_Maestro_Historial_Tasas>> Addhistoryrate([FromBody] SAP_Maestro_Historial_Tasas model) 
        {
           
            return await _historyRates.Add(model);
        }

    }
}
