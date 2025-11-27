using Analysis.Services.Contract;
using Repository.Contract;
using Repository.Entidades.DTO;
using DbTask = Repository.Entidades.db_Externa.Task;
using System.Linq;

namespace Analysis.Services.Implementation
{

    public class TaskService : ITask
    {
        private readonly IGeneric<Repository.Entidades.db_Externa.Task> _task;
        public TaskService(IGeneric<Repository.Entidades.db_Externa.Task> task)
        {
            _task = task;
        }

        public async Task<ResponseDTO<Repository.Entidades.db_Externa.Task>> Add(Repository.Entidades.db_Externa.Task model)
        {
            return await _task.Add(model);
        }

        public async Task<ResponseDTO<Repository.Entidades.db_Externa.Task>> Get(int id)
        {
            ResponseDTO<Repository.Entidades.db_Externa.Task> response = new ResponseDTO<Repository.Entidades.db_Externa.Task>();
            var task = _task.Get(t => t.Id == id);

            response.Data = task.Data != null ? task.Data.First() : null;
            response.Message = task.Message;
            response.IsCorrect = task.IsCorrect;
            return response;
        }

        public async Task<ResponseDTO<DbTask>> Get(DbTask model)
        {
             var result = await _task.GetAsync(x => x.Id == model.Id);
             return new ResponseDTO<DbTask>
             {
                 Data = result.Data?.FirstOrDefault(),
                 Message = result.Message,
                 IsCorrect = result.IsCorrect
             };
        }

        public async Task<ResponseDTO<IEnumerable<Repository.Entidades.db_Externa.Task>>> GetAll(string companyCode)
        {
            ResponseDTO<IEnumerable<Repository.Entidades.db_Externa.Task>> response = new ResponseDTO<IEnumerable<Repository.Entidades.db_Externa.Task>>();
            var task = _task.Get();

            response.Data = task.Data != null ? task.Data.ToList() : null;
            response.Message = task.Data.Count() == 0 ? "Data list empty" : task.Message;
            response.IsCorrect = task.IsCorrect;
            return response;
        }

        public async Task<ResponseDTO<IEnumerable<DbTask>>> GetALl()
        {
           return null;
        }

        public async Task<ResponseDTO<Repository.Entidades.db_Externa.Task>> Update(Repository.Entidades.db_Externa.Task model)
        {
            return await _task.Update(model);
        }
    }
}