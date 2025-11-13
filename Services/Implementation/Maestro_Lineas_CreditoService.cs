using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using Services.Dtos;

namespace Services.Implementation
{
    public class Maestro_Lineas_CreditoService : IMaestro_Lineas_Credito
    {
        private  readonly  IGeneric<Maestro_Lineas_Credito> _maestro_Lineas_Credito;

        private readonly IGeneric<SAP_Maestro_Bancos> _sap_maestro_bancos;

        public Maestro_Lineas_CreditoService(IGeneric<Maestro_Lineas_Credito> maestro_Lineas_Credito, IGeneric<SAP_Maestro_Bancos> sap_maestro_bancos)
        {
            _maestro_Lineas_Credito = maestro_Lineas_Credito;
            _sap_maestro_bancos = sap_maestro_bancos;
        }

        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Add(Maestro_Lineas_Credito model)
        {
            return await _maestro_Lineas_Credito.Add(model);
        }
        

        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Get(Maestro_Lineas_Credito model)
        {

            throw new NotImplementedException();
            
        }

        public async Task<ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>> GetAll()
        {
            ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>> response = new ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>();

            var lineasResp =   _maestro_Lineas_Credito.Get();
            var bancoResp = _sap_maestro_bancos.Get();

            var bancos = bancoResp.Data?.ToList() ?? new List<SAP_Maestro_Bancos>();
            var lineas = lineasResp.Data?.ToList() ?? new List<Maestro_Lineas_Credito>();
            var bancosDict = bancos?.ToDictionary(b => b.BankID, b => b.Bank_Name);

            var lienasDto = lineas?.Select(l => new Maestro_Lineas_CreditoDto
            {
                ID = l.ID,
                Line_Description = l.Line_Description,
                BankID = l.BankID,
                Bank_Name = bancosDict.TryGetValue(l.BankID, out var name) ? name : null,
                Credito = l.Credito
            }).ToList();

            response.Data = lienasDto;
            response.Message = lineasResp.Message;
            response.IsCorrect = lineasResp.IsCorrect;

            return response;

        }

        public async Task<ResponseDTO<Maestro_Lineas_Credito>> Update(Maestro_Lineas_Credito model)
        {
            ResponseDTO<Maestro_Lineas_Credito> response = new  ResponseDTO<Maestro_Lineas_Credito>();
            try
            {
                var currentResp = _maestro_Lineas_Credito.Get(x => x.ID == model.ID);

                if (currentResp.IsCorrect || currentResp.Data ==  null || currentResp.Data.Any()) 
                { 
                    response.Data = null;
                    response.Message = currentResp.Message;
                    response.IsCorrect = false;
                    return await System.Threading.Tasks.Task.FromResult(response);
                }
                else
                {
                    var current = currentResp.Data?.FirstOrDefault();
                    
                    current.Line_Description = model.Line_Description;
                    current.BankID = model.BankID;
                    current.Credito = model.Credito;

                    var saved = await _maestro_Lineas_Credito.Update(current);

                    response.Data = saved.Data != null ? saved.Data : response.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = true;
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

        Task<ResponseDTO<IEnumerable<Maestro_Lineas_Credito>>> IGenericInterface<Maestro_Lineas_Credito>.GetALl()
        {
            throw new NotImplementedException();
        }
    }
}
