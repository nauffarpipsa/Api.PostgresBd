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
                        status = x.status    
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
                var currentResp = _masterBanks.Get(x => x.bank_id == model.bank_id);

               if (!currentResp.IsCorrect || currentResp.Data == null || !currentResp.Data.Any())
                {
                    response.Data = null;
                    response.Message = $"No se encontro ningun registro con este ID {model.bank_id}";
                    response.IsCorrect = false;
                    return await System.Threading.Tasks.Task.FromResult(response);
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();

                    current.bank_name = model.bank_name;
                    current.status = model.status;

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
