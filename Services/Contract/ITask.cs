using Repository.Entidades.DTO;
using Services.Contract;

namespace Analysis.Services.Contract
{
    public interface ITask : IGenericInterface<Repository.Entidades.db_Externa.Task>
    {

        Task<ResponseDTO<Repository.Entidades.db_Externa.Task>> Get(int id);
    }
}