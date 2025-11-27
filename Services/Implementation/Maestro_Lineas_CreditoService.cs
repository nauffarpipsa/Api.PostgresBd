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

        public async Task<ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>> GetAll(int company_id)
        {
            ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>> response = new ResponseDTO<IEnumerable<Maestro_Lineas_CreditoDto>>();

            var lineasResp =   _maestro_Lineas_Credito.Get(l => l.company_id == company_id);
            var bancoResp = _sap_maestro_bancos.Get(b => b.company_id == company_id);

            var bancos = bancoResp.Data?.ToList() ?? new List<SAP_Maestro_Bancos>();
            var lineas = lineasResp.Data?.ToList() ?? new List<Maestro_Lineas_Credito>();
            var bancosDict = bancos?.ToDictionary(b => b.bank_id, b => b.bank_name);

            var lienasDto = lineas?.Select(l => new Maestro_Lineas_CreditoDto
            {
                ID = l.ID,
                line_description = l.line_description,
                bank_id = l.bank_id,
                bank_name = bancosDict.TryGetValue(l.bank_id, out var name) ? name : null,
                credito = l.credito,
                status = l.status
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
                var currentResp = _maestro_Lineas_Credito.Get(x => x.ID == model.ID && x.company_id == model.company_id);

                if (currentResp.Data != null) 
                {
                    var current = currentResp.Data?.FirstOrDefault();

                    current!.company_id = model.company_id;
                    current.line_description = model.line_description;
                    current.bank_id = model.bank_id;
                    current.credito = model.credito;
                    current.status = model.status;

                    var saved = await _maestro_Lineas_Credito.Update(current);

                    response.Data = saved.Data != null ? saved.Data : response.Data;
                    response.Message = saved.Message;
                    response.IsCorrect = true;
                }
                else
                {
                    response.Data = null;
                    response.Message = currentResp.Message;
                    response.IsCorrect = false;
                    return await System.Threading.Tasks.Task.FromResult(response);
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
