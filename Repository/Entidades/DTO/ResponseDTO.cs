namespace Repository.Entidades.DTO
{
    public class ResponseDTO<T> where T : class
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool IsCorrect { get; set; }
    }

}
