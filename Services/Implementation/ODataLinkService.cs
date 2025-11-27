using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;

namespace Services.Implementation
{
    public class ODataLinkService : IODataLink
    {
        private readonly IGeneric<ODataLink> _odata;
        public ODataLinkService(IGeneric<ODataLink> odata)
        {
            _odata = odata;
        }

        public async Task<ResponseDTO<ODataLink>> Add(ODataLink model)
        {
            return await _odata.Add(model);
        }

        public async Task<ResponseDTO<ODataLink>> Get(int id)
        {
            ResponseDTO<ODataLink> response = new ResponseDTO<ODataLink>();
            var odata = _odata.Get(o => o.id == id);

            response.Data = odata.Data != null ? odata.Data.First() : null;
            response.Message = odata.Message;
            response.IsCorrect = odata.IsCorrect;
            return response;
        }

        public async Task<ResponseDTO<ODataLink>> Get(ODataLink model)
        {
             var result = await _odata.GetAsync(x => x.id == model.id);
             return new ResponseDTO<ODataLink>
             {
                 Data = result.Data?.FirstOrDefault(),
                 Message = result.Message,
                 IsCorrect = result.IsCorrect
             };
        }


        public async Task<ResponseDTO<IEnumerable<ODataLink>>> GetALl()
        {
          return null;
        }

        public async Task<ResponseDTO<IEnumerable<ODataLink>>> GetAll()
        {
            ResponseDTO<IEnumerable<ODataLink>> response = new ResponseDTO<IEnumerable<ODataLink>>();
             var odata = _odata.Get();

            response.Data = odata.Data != null ? odata.Data.ToList() : null;
            response.Message = odata.Data.Count() == 0 ? "Data list empty" : odata.Message;
            response.IsCorrect = odata.IsCorrect;
            return response;
        }

        public async Task<ResponseDTO<ODataLink>> Update(ODataLink model)
        {
            return await _odata.Update(model);
        }
    }
}
