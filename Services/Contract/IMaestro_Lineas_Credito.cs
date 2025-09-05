using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Dtos;

namespace Services.Contract
{
    public interface IMaestro_Lineas_Credito : IGenericInterface<Maestro_Lineas_Credito>
    {
        Task<ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>> GetAll();
    }
}
