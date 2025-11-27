using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Dtos;

namespace Services.Contract
{
    public interface ISAPMaestroPrestamos : IGenericInterface<SAPMaestroPrestamos>
    {
        Task<ResponseDTO<IEnumerable<PrestamoDTO>>> GetAll(string sociedadID);
        Task<ResponseDTO<SAPMaestroPrestamos>> UpdateVerified(SAPMaestroPrestamos model);



    }
}

