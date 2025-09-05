using Repository.Entidades.db_Externa;

namespace Services.Dtos
{
    public class CatalogoCreditoDto
    {
        public IEnumerable<SAP_Maestro_BancosDTo> Bancos { get; set; } = [];
        public IEnumerable<Maestro_Lineas_CreditoDTo> LineasCredito { get; set; } = [];

        public IEnumerable<Maestro_Cuota_TiposDTo> TiposCuota { get; set; } = [];
        public IEnumerable<CondicionesDTO> condiciones { get; set; } = [];
    }
}
