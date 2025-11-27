using Repository.Contract;
using Repository.Entidades.db;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Dtos;
using Services.Utilities;

namespace Services.Implementation
{
    public class SapMaestroCuentasBancariasServices : ISap_Maestro_Cuentas_Bancarias
    {
        private readonly IGeneric<sap_maestro_cuentas_bancarias> _cuentasback;
        private readonly IGeneric<ODataLink> _odataLink;
        private readonly IRequestOData _odata;

        public SapMaestroCuentasBancariasServices(IGeneric<sap_maestro_cuentas_bancarias> cuentasback , IGeneric<ODataLink> odataLink , IRequestOData odata)
        {
            _cuentasback = cuentasback;
            _odataLink = odataLink;
            _odata = odata;
        }

        public async Task<ResponseDTO<IEnumerable<Sap_Maestro_Cuentas_BancariasDTo>>> GetALl(string company_id)
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

        public async Task<ResponseDTO<IEnumerable<AccountBankDTO>>> GetxOdata()
        {
            ResponseDTO<IEnumerable<AccountBankDTO>> response = new ResponseDTO<IEnumerable<AccountBankDTO>>();

            var odatalink = _odataLink.Get(x => x.id == 2);
            if (odatalink.Data is not null)
            {

                var odataLink = odatalink.Data
                  .Select(x => x.link)
                   .FirstOrDefault();

                var result = await _odata.RequestODataAsyncOdata(
                          odataLink,
                          new Dictionary<string, object> { });
                if (result != null)
                {
                    if (result.Data?.Count > 0)
                    {
                        var listaEntidades = (List<sap_maestro_cuentas_bancarias>)AccountBankHelper.ToList(result.Data);

                        var list = listaEntidades.Select(item => new Dtos.AccountBankDTO
                        {
                            InternalID = item.InternalId,
                            BankInternalID = item.BankInternalId,

                        }).ToList(); 

                        response.Data = list;
                        response.Message = result.Message;
                        response.IsCorrect = result.IsCorrect;

                    }
                    else
                    {
                        response.Message = "Account list Empty";
                        response.IsCorrect = true;
                    }
                }
                else
                {
                    response.Data = result.Data;
                    response.Message = result.Message;
                    response.IsCorrect = result.IsCorrect;
                }
            }
            return response;
        }



        

    }
}
