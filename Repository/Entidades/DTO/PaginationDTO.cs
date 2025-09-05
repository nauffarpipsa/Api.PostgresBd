namespace Repository.Entidades.DTO
{
    public class PaginationDTO<T> 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T>? items { get; set; }
    }
}
