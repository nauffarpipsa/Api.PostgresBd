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
                company_id = c.company_id,
                descripcion = c.descripcion
           
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

        public Task<ResponseDTO<Condiciones>> Update(Condiciones model)
        {
            throw new NotImplementedException();
        }
    }
}
