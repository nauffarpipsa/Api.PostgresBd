using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;


namespace Services.Implementation
{
    public class Maestro_Historial_TasasServices : IMaestro_Historial_Tasas
    {

        private readonly IGeneric<SAP_Maestro_Historial_Tasas> _historyRates;

        public Maestro_Historial_TasasServices(IGeneric<SAP_Maestro_Historial_Tasas> historyRates)
        {
            _historyRates = historyRates;
        }
        public async Task<ResponseDTO<SAP_Maestro_Historial_Tasas>> Add(SAP_Maestro_Historial_Tasas model)
        {
            SAP_Maestro_Historial_Tasas historyRates = new SAP_Maestro_Historial_Tasas();
            {
                historyRates.ID = model.ID;
                historyRates.PrestamoID = model.PrestamoID;
                historyRates.TasaH = model.TasaH;
                historyRates.FechaCreacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            }
            return await _historyRates.Add(historyRates);
          
        }

        public Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> Addrange(IEnumerable<SAP_Maestro_Historial_Tasas> model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<SAP_Maestro_Historial_Tasas>> Get(SAP_Maestro_Historial_Tasas model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetAll()
        {
            ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>> response = new ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>();
            var historyrate = _historyRates.Get();
            response.Data = historyrate.Data != null ? historyrate.Data.ToList() : null;
            response.Message = historyrate.Data?.Count() == 0 ? "Data list empty" : historyrate.Message;
            response.IsCorrect = true;

            return response;
        }


        public async Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetAll(string PrestamoID)
        {
            ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>> response = new ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>();

            var historyrate = _historyRates.Get(x => x.PrestamoID == PrestamoID);

            response.Data = historyrate.Data != null ? historyrate.Data.ToList() : null;
            response.Message = historyrate.Data?.Count() == 0 ? "Data list empty" : historyrate.Message;
            response.IsCorrect = true;

            return response;
        }


        public Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetALl()
        {
            throw new NotImplementedException();
        }
        public Task<ResponseDTO<SAP_Maestro_Historial_Tasas>> Update(SAP_Maestro_Historial_Tasas model)
        {
            throw new NotImplementedException();
        }

    }
}
