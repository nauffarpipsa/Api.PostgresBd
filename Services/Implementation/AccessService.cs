using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;


namespace Services.Implementation
{
    public class AccessService : IAccess
    {
        private readonly IGeneric<Access> _access;
        public AccessService(IGeneric<Access> access)
        {
            _access = access;
        }

        public async Task<ResponseDTO<Access>> Add(Access model)
        {
            return await _access.Add(model);
        }

      

        public Task<ResponseDTO<Access>> Get(Access model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<Access>> Get(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<Access>> Get(int id)
        {
            ResponseDTO<Access> response = new ResponseDTO<Access>();
            var access = _access.Get(a => a.Id == id);

            response.Data = access.Data != null ? access.Data.First() : null;
            response.Message = access.Message;
            response.IsCorrect = access.IsCorrect;
            return response;
        
        }

        public async Task<ResponseDTO<IEnumerable<Access>>> GetAll(string companyCode)
        {
            ResponseDTO<IEnumerable<Access>> response = new ResponseDTO<IEnumerable<Access>>();
            var access = _access.Get();

            response.Data = access.Data != null ? access.Data.ToList() : null;
            response.Message = access.Data.Count() == 0 ? "Data list empty" : access.Message;
            response.IsCorrect = access.IsCorrect;
            return response;
        }

        public Task<ResponseDTO<IEnumerable<Access>>> GetALl()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<Access>> Update(Access model)
        {
            return await _access.Update(model);
        }
    }
}
