using Repository.Entidades.DTO;


namespace Services.Contract
{
    public interface  IGenericInterface<T> where T : class
    {
        Task<ResponseDTO<T>> Add(T model);    
        Task<ResponseDTO<T>> Update(T model);
        Task<ResponseDTO<T>> Get(T model);
        Task<ResponseDTO<IEnumerable<T>>> GetALl();

    }
}
