using Repository.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IRequestOData
    {
        Task<ResponseDTO<dynamic>> RequestODataAsync(int TaskId, Dictionary<string, object> Values);
        Task<ResponseDTO<dynamic>> RequestODataAsyncOdata(string Odata, Dictionary<string, object> Values);
    }
}
