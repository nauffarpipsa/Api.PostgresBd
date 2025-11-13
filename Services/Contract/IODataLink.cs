using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;

namespace Services.Contract
{
    public interface IODataLink : IGenericInterface<ODataLink>
    {
        Task<ResponseDTO<IEnumerable<ODataLink>>> GetAll();
    }
}
