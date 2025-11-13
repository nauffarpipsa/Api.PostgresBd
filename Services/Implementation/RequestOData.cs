using Newtonsoft.Json.Linq;
using Repository;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class RequestOData : IRequestOData
    {
        private readonly applicationDbContext _db;
        public RequestOData(applicationDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseDTO<dynamic>> RequestODataAsyncOdata(string Odata, Dictionary<string, object> Values)
        {
            ResponseDTO<dynamic> response = new ResponseDTO<dynamic>();

            
            var link = Odata;
            var user = _db.Access.First();

            using (var http = new HttpClient())
            {
                http.Timeout = TimeSpan.FromMinutes(60);

                var authenticationString = $"{user.user_name}:{user.password}";
                var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

                var request = await http.GetAsync(string.Format(link, Values.Values.ToArray()));
                if (request.IsSuccessStatusCode)
                {
                    var result = await request.Content.ReadAsStringAsync();
                    dynamic data = JObject.Parse(result);
                    var results = data.d.results;

                    response.Data = results;
                    response.IsCorrect = true;
                    response.Message = "Data successfully obtained";
                }
                else
                {
                    response.Data = null;
                    response.IsCorrect = false;
                    response.Message = "Status Code: " + request.StatusCode + ", Request Message: " + request.RequestMessage;
                }
            }
            return response;
        }

        public async Task<ResponseDTO<dynamic>> RequestODataAsync(int TaskId, Dictionary<string, object> Values)
        {
            ResponseDTO<dynamic> response = new ResponseDTO<dynamic>();
            try
            {
                var task = _db.Task.First(t => t.Id == TaskId);
                var link = _db.ODataLink.First(d => d.id == task.odata_link_id);
                var user = _db.Access.First(u => u.Id == task.user_id);

                if (task.active)
                {
                    if (link.active)
                    {
                        if (user.active)
                        {
                            using (var http = new HttpClient())
                            {
                                http.Timeout = TimeSpan.FromMinutes(60);

                                var authenticationString = $"{user.user_name}:{user.password}";
                                var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));
                                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

                                var request = await http.GetAsync(string.Format(link.link, Values.Values.ToArray()));
                                if (request.IsSuccessStatusCode)
                                {
                                    var result = await request.Content.ReadAsStringAsync();
                                    dynamic data = JObject.Parse(result);
                                    var results = data.d.results;

                                    response.Data = results;
                                    response.IsCorrect = true;
                                    response.Message = "Data successfully obtained";
                                }
                                else
                                {
                                    response.Data = null;
                                    response.IsCorrect = false;
                                    response.Message = "Status Code: " + request.StatusCode + ", Request Message: " + request.RequestMessage;
                                }
                            }
                        }
                        else
                        {
                            response.Data = null;
                            response.IsCorrect = false;
                            response.Message = $"User {user.user_name} is not active";
                        }
                    }
                    else
                    {
                        response.Data = null;
                        response.IsCorrect = false;
                        response.Message = $"OData link {link.description} is not active";
                    }
                }
                else
                {
                    response.Data = null;
                    response.IsCorrect = false;
                    response.Message = $"Task {TaskId} is not active";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsCorrect = false;
                response.Message = ex.Message;

                return response;
            }
        }
    }

}
