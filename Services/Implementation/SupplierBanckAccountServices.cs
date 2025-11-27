
using Analysis.Services.Contract;
using Repository.Contract;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Utilities;

namespace Services.Implementation
{
    public class SupplierBanckAccountServices : ISupplierBanckAccount
    {
        private readonly IRequestOData _odata;
        private readonly ITask _task;
        private readonly IGeneric<ODataLink> _oDataLink;

        public SupplierBanckAccountServices(IRequestOData oData, ITask task, IGeneric<ODataLink> oDataLink )
        {
            _odata = oData;
            _task = task;
            _oDataLink = oDataLink;
        }

        public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetAsync(int taskId)
        {
            ResponseDTO<IEnumerable<SupplierBanckAccount>> response = new ResponseDTO<IEnumerable<SupplierBanckAccount>>();
            response.Data = new List<SupplierBanckAccount>();

            try
            {
                var task = await _task.Get(taskId);
                var company = "1000000";

                if (task.Data != null)
                {
                    if (task.Data.active)
                    {
                        if (company != null)
                        {
                            //if (company.Data.Active)
                            //{
                                var result = await _odata.RequestODataAsync(
                                    task.Data.Id,
                                    new Dictionary<string, object> {
                                        { "Company", company }});

                                if (result != null)
                                {
                                    if (result.Data?.Count > 0)
                                    {
                                    var list = (IEnumerable<SupplierBanckAccount>)SupplierBanckAccountHelper.ToList(result.Data);


                                    response.Data = list;
                                    response.Message = result.Message;
                                    response.IsCorrect = result.IsCorrect;

                                }
                                    else
                                    {
                                        response.Message = "Order list Empty";
                                        response.IsCorrect = true;
                                    }
                                }
                                else
                                {
                                    response.Data = result.Data;
                                    response.Message = result.Message;
                                    response.IsCorrect = result.IsCorrect;
                                }
                            //}
                            //else
                            //{
                            //    response.Data = null;
                            //    response.IsCorrect = false;
                            //    response.Message = $"Company {task.Data.CompanyId} is not active";
                            //}
                        }
                        else
                        {
                            response.Data = null;
                            response.IsCorrect = false;
                            response.Message = $"Company {task.Data.company_id} not found";
                        }
                    }
                    else
                    {
                        response.Data = null;
                        response.IsCorrect = false;
                        response.Message = $"Task {taskId} is not active";
                    }
                }
                else
                {
                    response.Data = null;
                    response.IsCorrect = false;
                    response.Message = $"Task {taskId} not found";
                }
                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }
       
         public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetAllSupplierBankAccount(string company_id)
        {
            ResponseDTO<IEnumerable<SupplierBanckAccount>> response = new ResponseDTO<IEnumerable<SupplierBanckAccount>>();
            response.Data = new List<SupplierBanckAccount>();

            var odatalink = _oDataLink.Get(o => o.id == 1);

            if (odatalink.Data is not null)
            {

                var odataLink = odatalink.Data
                  .Select(x => x.link)
                   .FirstOrDefault();

                var result = await _odata.RequestODataAsyncOdata(
                          odataLink,
                         new Dictionary<string, object> {
                                        { "Company", company_id }});
                if (result != null)
                {
                    if (result.Data?.Count > 0)
                    {
                         var entities = AccountBankHelper.ToList(result.Data);

                        var list = (IEnumerable<SupplierBanckAccount>)SupplierBanckAccountHelper.ToList(result.Data);


                        response.Data = list;
                        response.Message = result.Message;
                        response.IsCorrect = result.IsCorrect;

                    }
                    else
                    {
                        response.Message = "Porveerdor list Empty";
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
