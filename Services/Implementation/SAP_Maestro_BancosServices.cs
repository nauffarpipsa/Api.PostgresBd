using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Services.Implementation
{
    public class SAP_Maestro_BancosServices : ISAP_Maestro_Bancos
    {
        private readonly IGeneric<SAP_Maestro_Bancos> _masterBanks;
        private readonly IGeneric<ODataLink> _odataLink;
        private readonly IRequestOData _odata;
        public SAP_Maestro_BancosServices(IGeneric<SAP_Maestro_Bancos> masterBanks, IGeneric<ODataLink> odataLink, IRequestOData odata)
        {
            _masterBanks = masterBanks;
            _odataLink = odataLink;
            _odata = odata;
        }
        public async Task<ResponseDTO<SAP_Maestro_Bancos>> Add(SAP_Maestro_Bancos model)
        {
            return await _masterBanks.Add(model);
        }

        public Task<ResponseDTO<Repository.Entidades.db_Externa.SAP_Maestro_Bancos>> Get(Repository.Entidades.db_Externa.SAP_Maestro_Bancos model)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>>> GetAll(int company_id)
        {
            ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>> response = new ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>>();
            var listmasterBanks = _masterBanks.Get(m => m.company_id == company_id);

            if (listmasterBanks?.Data != null)
            {
                response.Data = listmasterBanks.Data
                    .Select(x => new Services.Dtos.SAP_Maestro_BancosDto
                    {
                        company_id = x.company_id,
                        bank_id = x.bank_id,
                        bank_name = x.bank_name,
                        sap_bank_id = x.sap_bank_id,
                        status = x.status
                    });


                response.Message = listmasterBanks.Message;
                response.IsCorrect = true;
            }
            else
            {
                response.Data = null;
                response.Message = listmasterBanks.Message;
                response.IsCorrect = false;

            }
            return response;
        }
        public async Task<ResponseDTO<SAP_Maestro_Bancos>> Update(SAP_Maestro_Bancos model)
        {
            ResponseDTO<SAP_Maestro_Bancos> response = new ResponseDTO<SAP_Maestro_Bancos>();

            try
            {
                var currentResp = _masterBanks.Get(x => x.bank_id == model.bank_id && x.company_id == model.company_id);

                if (!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
                {
                    response.Data = null;
                    response.Message = $"No se encontro ningun registro con este ID {model.bank_id} para la company {model.company_id}";
                    response.IsCorrect = false;
                    return await System.Threading.Tasks.Task.FromResult(response);
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();

                    current.bank_name = model.bank_name;
                    current.sap_bank_id = model.sap_bank_id;
                    current.status = model.status;

                    var saved = await _masterBanks.Update(current);

                    response.Data = saved.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = saved.IsCorrect;

                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.IsCorrect = false;
            }
            return response;
        }

        Task<ResponseDTO<IEnumerable<SAP_Maestro_Bancos>>> IGenericInterface<SAP_Maestro_Bancos>.GetALl()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<IEnumerable<Services.Dtos.BankDTO>>> GetBankOdata( int bank_id)
        {
            ResponseDTO<IEnumerable<Services.Dtos.BankDTO>> response = new ResponseDTO<IEnumerable<Services.Dtos.BankDTO>>();

            var odatalink = _odataLink.Get(x => x.id == 3);
            if (odatalink.Data is not null)
            {

                var odataLink = odatalink.Data
                  .Select(x => x.link)
                   .FirstOrDefault();

                var result = await _odata.RequestODataAsyncOdata(
                          odataLink,
                          new Dictionary<string, object>{
                           { "bank_id", bank_id }});
                if (result != null)
                {
                    if (result.Data?.Count > 0)
                    {
                        var listaEntidades = (List<Bank>)BankHelper.BankHelper.ToList(result.Data);

                        var list = listaEntidades.Select(item => new Services.Dtos.BankDTO
                        {
                          
                            OrganisationFormattedName = item.OrganisationFormattedName,

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
