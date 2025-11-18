using Repository.Entidades.DTO;
using Services.Dtos;

namespace Services.Contract
{
    public interface ISap_Maestro_Cuentas_Bancarias 
    {
        Task<ResponseDTO<IEnumerable<Sap_Maestro_Cuentas_BancariasDTo>>> GetALl(int idcompany);
    }
}
