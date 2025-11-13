using Repository.Entidades.DTO;


namespace Services.Contract
{
    public interface IGenericRequest<T> where T : class
    {
        Task<ResponseDTO<IEnumerable<T>>> GetAsync(int TaskId);
    }
}
