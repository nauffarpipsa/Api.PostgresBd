using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;

namespace Services.Contract
{
    public interface IMaestro_Amortizaciones : IGenericInterface<Maestro_Amortizaciones> 
    {
        Task<ResponseDTO <IEnumerable<Maestro_Amortizaciones>>> Add( IEnumerable<Maestro_Amortizaciones> model);
        Task<ResponseDTO<IEnumerable<Maestro_Amortizaciones>>> GetALl(string prestamo_numbre,  bool valid, bool paid);
    };
   
}
