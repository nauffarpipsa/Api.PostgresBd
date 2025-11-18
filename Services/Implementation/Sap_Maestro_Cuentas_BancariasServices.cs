
using Repository.Contract;
using Repository.Entidades.db;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Dtos;

namespace Services.Implementation
{
    public class SapMaestroCuentasBancariasServices : ISap_Maestro_Cuentas_Bancarias
    {
        private readonly IGeneric<sap_maestro_cuentas_bancarias> _cuentasback;
        public SapMaestroCuentasBancariasServices(IGeneric<sap_maestro_cuentas_bancarias> _cuentasback)
        {
            this._cuentasback = _cuentasback;
        }

        public async Task<ResponseDTO<IEnumerable<Sap_Maestro_Cuentas_BancariasDTo>>> GetALl(int company_id)
        {
                var reques = await _cuentasback.GetAsync(x =>  x.IdCompany == company_id);

                var response = new ResponseDTO<IEnumerable<Sap_Maestro_Cuentas_BancariasDTo>>
                {
                    IsCorrect = reques?.IsCorrect ?? false,
                    Message = reques?.Message ?? "Data list Emty"
                };

                var origen = reques?.Data ?? Enumerable.Empty<sap_maestro_cuentas_bancarias>();
                response.Data = origen.Select(Services.Dtos.sap_maestro_cuentas_bancariasMapper.MapToDto).ToList();

            return response;
        }
    }
}
