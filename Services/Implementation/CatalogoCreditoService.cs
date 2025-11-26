using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Services.Implementation
{
    public class CatalogoCreditoService : ICreditoCatalogo
    {
        private readonly IGeneric<SAP_Maestro_Bancos> _masterBanks;
        private readonly IGeneric<Maestro_Lineas_Credito> _maestro_Lineas_Credito;
        private readonly IGeneric<Maestro_Cuota_Tipos> _maestro_Cuota_Tipos;
        private readonly IGeneric<Condiciones> _Condiciones;

        public CatalogoCreditoService(IGeneric<SAP_Maestro_Bancos> masterBanks, IGeneric<Maestro_Lineas_Credito> maestro_Lineas_Credito, IGeneric<Maestro_Cuota_Tipos> Maestro_Cuota_Tipos, IGeneric<Condiciones> Condiciones)
        {
            _masterBanks = masterBanks;
            _maestro_Lineas_Credito = maestro_Lineas_Credito;
            _maestro_Cuota_Tipos = Maestro_Cuota_Tipos;
            _Condiciones = Condiciones;
        }

        public async Task<ResponseDTO<CatalogoCreditoDto>> Get(int company_id)
        {
            var response = new ResponseDTO<CatalogoCreditoDto>();

            var bancosResp =  _masterBanks.Get(m => m.company_id == company_id && m.status == true);
            var lineasResp =  _maestro_Lineas_Credito.Get(l => l.company_id == company_id && l.status == true);
            var cuotaTiposResp =  _maestro_Cuota_Tipos.Get(c => c.company_id == company_id && c.status == true);
            var condicionesResp =  _Condiciones.Get(cd => cd.company_id == company_id && cd.status == true);

           
            try
            { 
                var bancos = bancosResp.Data?.ToList() ?? new List<SAP_Maestro_Bancos>();
                var lineas = lineasResp.Data?.ToList() ?? new List<Maestro_Lineas_Credito>();
                var cuotaTipos = cuotaTiposResp.Data?.ToList() ?? new List<Maestro_Cuota_Tipos>();
                var condiciones = condicionesResp.Data?.ToList() ?? new List<Condiciones>();

                var bancosDict = bancos?.ToDictionary(b => b.bank_id, b => b.bank_name);

                var lienasDto = lineas?.Select(l => new Maestro_Lineas_CreditoDTo
                {
                    ID = l.ID,
                    bank_id = l.bank_id,
                    Line_Description = string.Concat(l.line_description + "/" + (bancosDict.TryGetValue(l.bank_id, out var name) ? name : null)),
                    Credito = l.credito,

                }).ToList();

                var dto = new CatalogoCreditoDto
                {
                    Bancos = bancos.Select(b => new SAP_Maestro_BancosDTo { bank_id = b.bank_id, bank_name = b.bank_name, }),
                    LineasCredito = lienasDto,
                    TiposCuota = cuotaTipos.Select(c => new Maestro_Cuota_Tiposdto { id = c.id, description = c.description}),
                    condiciones = condiciones.Select(c => new Condicionesdto { ID = c.ID, descripcion = c.descripcion })

                };
                response.Data = dto;
                response.Message = "Catálogos obtenidos correctamente.";
                response.IsCorrect = true;

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = $"Error al obtener los catálogos: {ex.Message}";
                response.IsCorrect = false;
            }
          

            return response;
        }

    }
}
