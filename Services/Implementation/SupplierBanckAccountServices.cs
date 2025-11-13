
using Analysis.Services.Contract;
using Repository.Entidades.DTO;
using Repository.Entidades.Odatas;
using Services.Contract;
using Services.Dtos;
using Services.Utilities;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace Services.Implementation
{
    public class SupplierBanckAccountServices : ISupplierBanckAccount
    {
        private readonly IRequestOData _odata;
        private readonly ITask _task;

        public SupplierBanckAccountServices(IRequestOData oData, ITask task )
        {
            _odata = oData;
            _task = task;
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
        public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetDataProveedor(int taskId , string proveedores)
        {
            ResponseDTO<IEnumerable<SupplierBanckAccount>> response = new ResponseDTO<IEnumerable<SupplierBanckAccount>>();
            response.Data = new List<SupplierBanckAccount>();

            try
            {
                var task = await _task.Get(taskId);

                if (task.Data != null)
                {
                    if (task.Data.active)
                    {

                        string linkGeneric = string.Empty;

                        if (proveedores is null)
                        {
                            linkGeneric = $"(CCREATION_DT  ge datetime'{DateTime.Now.Subtract(TimeSpan.FromMinutes(task.Data.minute_range)).Date.ToString("yyyy-MM-dd")}T00:00:00')";
                        }
                        else
                        {

                            linkGeneric = $"(CBP_UUID  eq '{proveedores}')";
                            foreach (var item in proveedores)
                            {
                                linkGeneric += $"(CBP_UUID eq '{item}') or ";
                            }

                            linkGeneric = linkGeneric.Substring(0, linkGeneric.Length - 5);
                            linkGeneric += ")";
                        }

                        var result = await _odata.RequestODataAsync(
                            task.Data.Id,
                            new Dictionary<string, object> {
                                    { "Link", linkGeneric }});

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
                                response.Message = "Porveedor list Empty";
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

        public async Task<ResponseDTO<IEnumerable<SupplierBanckAccount>>> GetDataProveedor(string proveedores)
        {
            ResponseDTO<IEnumerable<SupplierBanckAccount>> response = new ResponseDTO<IEnumerable<SupplierBanckAccount>>();
            response.Data = new List<SupplierBanckAccount>();

            try
            {
                var Odata = "https://my431112.businessbydesign.cloud.sap/sap/byd/odata/ana_businessanalytics_analytics.svc/RPBUPSPP_Q0001QueryResults?$select=CCREATION_DT,CBANK_NAT_CODE,CSTATUS,TSTATUS,CBANK_NAME,CBANK_ACCOUNT_ID,CBP_UUID,TBP_UUID&$filter=(CBP_UUID eq '{0}')&$top=999999&$format=json&sap-language=ES";

                var result = await _odata.RequestODataAsyncOdata(
                          Odata,
                          new Dictionary<string, object> {
                                    { "Proveedor", proveedores }});

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
            catch (Exception)
            {

                throw;
            }
            return response;
        }

    }
}
