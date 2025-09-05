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

        public async Task<ResponseDTO<CatalogoCreditoDto>> Get()
        {
            var response = new ResponseDTO<CatalogoCreditoDto>();

            var bancosResp =  _masterBanks.Get();
            var lineasResp =  _maestro_Lineas_Credito.Get();
            var cuotaTiposResp =  _maestro_Cuota_Tipos.Get();
            var condicionesResp =  _Condiciones.Get();

           

            try
            { 
                var bancos = bancosResp.Data?.Where(b => b.Status == true).ToList() ?? new List<SAP_Maestro_Bancos>();
                var lineas = lineasResp.Data?.ToList() ?? new List<Maestro_Lineas_Credito>();
                var cuotaTipos = cuotaTiposResp.Data?.Where(l => l.Status == true).ToList() ?? new List<Maestro_Cuota_Tipos>();
                var condiciones = condicionesResp.Data?.ToList() ?? new List<Condiciones>();

                var bancosDict = bancos?.ToDictionary(b => b.BankID, b => b.Bank_Name);

                var lienasDto = lineas?.Select(l => new Maestro_Lineas_CreditoDTo
                {
                    ID = l.ID,
                    Line_Description = string.Concat(l.Line_Description + "/" + (bancosDict.TryGetValue(l.BankID, out var name) ? name : null)),
                    Credito = l.Credito,

                }).ToList();

                var dto = new CatalogoCreditoDto
                {
                    Bancos = bancos.Select(b => new SAP_Maestro_BancosDTo { BankID = b.BankID, Bank_Name = b.Bank_Name, }),
                    LineasCredito = lienasDto,
                    TiposCuota = cuotaTipos.Select(c => new Maestro_Cuota_TiposDTo { ID = c.ID, Description = c.Description }),
                    condiciones = condiciones.Select(c => new CondicionesDTO { ID = c.ID, descripcion = c.descripcion })

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
