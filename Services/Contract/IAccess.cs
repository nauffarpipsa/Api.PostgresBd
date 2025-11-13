using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;

namespace Services.Contract
{
    public interface IAccess : IGenericInterface<Access>
    {
        Task<ResponseDTO<Access>> Get(int id);
    }
}
