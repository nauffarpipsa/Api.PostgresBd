using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Dtos;

namespace Services.Contract
{
    public interface IMaestro_Cuota_Tipos : IGenericInterface<Maestro_Cuota_Tipos>
    {
        Task<ResponseDTO<IEnumerable<Maestro_Cuota_TiposDTO>>> GetALl(int company_id);
    }
}
