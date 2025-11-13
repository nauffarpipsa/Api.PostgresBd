using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;


namespace Services.Implementation
{
    public class SAP_Maestro_BancosServices : ISAP_Maestro_Bancos
    {
        private readonly IGeneric<SAP_Maestro_Bancos> _masterBanks;
        public SAP_Maestro_BancosServices(IGeneric<SAP_Maestro_Bancos> masterBanks)
        {
            _masterBanks = masterBanks; 
            
        }
        public async Task<ResponseDTO<SAP_Maestro_Bancos>> Add(SAP_Maestro_Bancos model)
        {
            return await _masterBanks.Add(model);
        }

        public Task<ResponseDTO<Repository.Entidades.db_Externa.SAP_Maestro_Bancos>> Get(Repository.Entidades.db_Externa.SAP_Maestro_Bancos model)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>>> GetAll()
        {
            ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>> response = new ResponseDTO<IEnumerable<Services.Dtos.SAP_Maestro_BancosDto>>();
            var listmasterBanks = _masterBanks.Get();

            if (listmasterBanks?.Data != null) 
            {
                response.Data = listmasterBanks.Data
                    .Select(x => new Services.Dtos.SAP_Maestro_BancosDto
                {
                        BankID = x.BankID,
                        Bank_Name = x.Bank_Name,
                        Status = x.Status
                });


                response.Message =  listmasterBanks.Message;
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
                var currentResp = _masterBanks.Get(x => x.BankID == model.BankID);

               if (!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
                {
                    response.Data = null;
                    response.Message = $"No se encontro ningun registro con este ID {model.BankID}";
                    response.IsCorrect = false;
                    return await System.Threading.Tasks.Task.FromResult(response);
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();

                    current.Bank_Name = model.Bank_Name;
                    current.Status = model.Status;

                    var saved = await _masterBanks.Update(current);

                    response.Data = saved.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = saved.IsCorrect;

                }
            }
            catch (Exception ex )
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
    }
}
