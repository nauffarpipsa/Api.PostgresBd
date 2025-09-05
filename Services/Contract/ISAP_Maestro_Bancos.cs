using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Dtos;


namespace Services.Contract
{
     public interface ISAP_Maestro_Bancos : IGenericInterface<SAP_Maestro_Bancos>
    {
        Task<ResponseDTO<IEnumerable<Dtos.SAP_Maestro_BancosDto>>> GetAll();

    }
}
