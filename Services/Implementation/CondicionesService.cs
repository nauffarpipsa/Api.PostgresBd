using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Services.Implementation
{
    public class CondicionesService : ICondiciones
    {
        private readonly IGeneric<Condiciones> _Condiciones;
        public CondicionesService(IGeneric<Condiciones> Condiciones)
        {
            _Condiciones = Condiciones;
        }

        public Task<ResponseDTO<Condiciones>> Add(Condiciones model)
        {
            return _Condiciones.Add(model);

        }

        public Task<ResponseDTO<Condiciones>> Get(Condiciones model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<CondicionesDTO>>> GetALL(int company_id)
        {
            ResponseDTO<IEnumerable<CondicionesDTO>> response = new ResponseDTO<IEnumerable<CondicionesDTO>>();

            var condicion = _Condiciones.Get(c => c.company_id == company_id);

            var condicioneslist = condicion.Data?.ToList() ?? new List<Condiciones>();

            var condicionesDto = condicioneslist?.Select(c => new CondicionesDTO
            {
                ID = c.ID,
                descripcion = c.descripcion,
                status = c.status

            }).ToList();

            response.Data = condicionesDto;
            response.Message = condicion.Data?.Count() == 0 ? "Data list empty" : condicion.Message;
            response.IsCorrect = true;

            return response;
        }

        public Task<ResponseDTO<IEnumerable<Condiciones>>> GetALl()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<Condiciones>> Update(Condiciones model)
        {
             ResponseDTO<Condiciones> response = new ResponseDTO<Condiciones>();

            try
            {
                var currentResp = _Condiciones.Get(x => x.ID == model.ID && x.company_id == model.company_id);

                if (!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
                {
                    response.Data = null;
                    response.Message = $"No se encontro ningun registro con este ID {model.ID} pra la empresa {model.company_id}";
                    response.IsCorrect = false;
                    return await System.Threading.Tasks.Task.FromResult(response);
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();
                      
                    current.descripcion = model.descripcion;
                    current.status = model.status;
                    
                    var saved = await _Condiciones.Update(current);

                    response.Data = saved.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = saved.IsCorrect;
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
            }
            return response;
        }
    }
}
