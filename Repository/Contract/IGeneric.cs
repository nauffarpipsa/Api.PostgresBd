using Repository.Entidades.DTO;
using System.Linq.Expressions;

namespace Repository.Contract
{
    public interface IGeneric<T> where T : class
    {
        public IQueryable<T> Query(Expression<Func<T, bool>>? filter = null);
        public Task<ResponseDTO<List<T>>> GetAsync(Expression<Func<T, bool>>? filter = null);
        ResponseDTO<IQueryable<T>> Get(Expression<Func<T, bool>>? filter = null);
        Task<ResponseDTO<T>> Add(T model);
        Task<ResponseDTO<IEnumerable<T>>> AddRange(IEnumerable<T> model);
        Task<ResponseDTO<T>> Update(T model);
        Task<ResponseDTO<IEnumerable<T>>> UpdateRange(IEnumerable<T> model);
        Task<ResponseDTO<IEnumerable<T>>> Empty(IEnumerable<T> model);
        Task<ResponseDTO<T>> UpdatePartial<T>(T model, params Expression<Func<T, object>>[] properties) where T : class;

    }
}
