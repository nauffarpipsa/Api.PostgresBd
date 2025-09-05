using Repository.Entidades;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Dtos;


namespace Services.Contract
{
    public interface ISap_Maesto_Purchase_Orders : IGenericInterface<SAP_Maestro_Purchase_Orders>
    {
        Task<ResponseDTO<IEnumerable<PurchaseOrderDto>>> Get();

        Task<ResponseDTO<PaginationDTO<PurchaseOrderDto>>> Get(int pageNumber, int pageSize);
    }
}
