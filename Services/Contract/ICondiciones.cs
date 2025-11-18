using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Dtos;

namespace Services.Contract
{
    public interface ICondiciones : IGenericInterface<Condiciones> 
    {
        Task<ResponseDTO<IEnumerable<CondicionesDTO>>> GetALL(int company_id);


    }
}
