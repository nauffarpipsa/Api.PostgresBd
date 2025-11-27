using Repository.Entidades.DTO;
using Services.Dtos;

namespace Services.Contract
{
    public  interface ICreditoCatalogo 
    {
      Task<ResponseDTO<CatalogoCreditoDto>> Get(int company_id);
    }
}
