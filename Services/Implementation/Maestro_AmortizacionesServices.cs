using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;

namespace Services.Implementation
{
    public class Maestro_AmortizacionesServices : IMaestro_Amortizaciones
    {
        private readonly IGeneric<Maestro_Amortizaciones> _amortizacion;
        public Maestro_AmortizacionesServices(IGeneric<Maestro_Amortizaciones> amortizacion)
        {
            _amortizacion = amortizacion;
        }
        public async Task<ResponseDTO<Maestro_Amortizaciones>> Add(Maestro_Amortizaciones model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<Maestro_Amortizaciones>>> Add(IEnumerable<Maestro_Amortizaciones> model)
        {
               return await _amortizacion.AddRange(model);
        }

        public Task<ResponseDTO<Maestro_Amortizaciones>> Get(Maestro_Amortizaciones model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<Maestro_Amortizaciones>>> GetALl( string pestamo_number, bool valid,bool paid)
        {
            ResponseDTO<IEnumerable<Maestro_Amortizaciones>> respose = new ResponseDTO<IEnumerable<Maestro_Amortizaciones>>();

           try
            {
                var reques =  _amortizacion.Get(x => x.prestamo_number == pestamo_number &&  x.valid == valid && x.Paid == paid);

                respose.Data = reques.Data != null ? reques.Data.ToList().OrderByDescending(x => x.quota_number ) : null;
                respose.Message = reques.Data?.Count() == 0 ? "Data list empty" : reques.Message;
                respose.IsCorrect = true;


            }
            catch (Exception ex)
            {
                respose.Data = null;
                respose.IsCorrect = false;
                respose.Message = ex.Message;
            }
            return respose;
        }

        public Task<ResponseDTO<IEnumerable<Maestro_Amortizaciones>>> GetALl()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<Maestro_Amortizaciones>> Update(Maestro_Amortizaciones model)
        {
            throw new NotImplementedException();
        }
    }
}
