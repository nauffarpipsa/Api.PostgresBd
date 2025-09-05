using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;

namespace Services.Contract
{
    public interface IMaestro_Historial_Tasas : IGenericInterface<SAP_Maestro_Historial_Tasas>
    {
        Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> Addrange(IEnumerable<SAP_Maestro_Historial_Tasas> model);
        Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetAll();
        Task<ResponseDTO<IEnumerable<SAP_Maestro_Historial_Tasas>>> GetAll(string PrestamoID);


    }
}
