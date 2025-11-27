using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class Maestro_Centro_CostosService : IMaestro_Centro_Costos
    {
        private readonly IGeneric<Maestro_Centro_Costos> _ccostos;
        public Maestro_Centro_CostosService(IGeneric<Maestro_Centro_Costos> ccostos)
        {
            _ccostos = ccostos;
        }

        public async Task<ResponseDTO<Maestro_Centro_Costos>> Add(Maestro_Centro_Costos model)
        {
            return await _ccostos.Add(model);
        }

        public async Task<ResponseDTO<Maestro_Centro_Costos>> Get(Maestro_Centro_Costos model)
        {
            ResponseDTO<Maestro_Centro_Costos> response = new ResponseDTO<Maestro_Centro_Costos>();

            var result = await _ccostos.GetAsync(x => x.ID == model.ID);

            response.Data = result.Data != null && result.Data.Any() ? result.Data.FirstOrDefault() : null;
            response.Message = result.Message;
            response.IsCorrect = response.IsCorrect ;

            return response;

        }

        public async Task<ResponseDTO<IEnumerable<Maestro_Centro_Costos>>> GetALl()
        {
            return null;
        }

        public async Task<ResponseDTO<Maestro_Centro_Costos>> Update(Maestro_Centro_Costos model)
        {
            return await _ccostos.Update(model);
        }
    }
}
