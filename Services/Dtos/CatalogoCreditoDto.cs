using Repository.Entidades.db_Externa;

namespace Services.Dtos
{
    public class CatalogoCreditoDto
    {
        public IEnumerable<SAP_Maestro_BancosDTo> Bancos { get; set; } = [];
        public IEnumerable<Maestro_Lineas_CreditoDTo> LineasCredito { get; set; } = [];

        public IEnumerable<Maestro_Cuota_Tiposdto> TiposCuota { get; set; } = [];
        public IEnumerable<Condicionesdto> condiciones { get; set; } = [];
    }
}
