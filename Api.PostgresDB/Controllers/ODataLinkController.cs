using Analysis.API.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.db_Externa;
using Repository.Entidades.DTO;
using Services.Contract;

namespace Analysis.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Tags("OData Link")]
    public class ODataLinkController : ControllerBase
    {
        private readonly IODataLink _odata;
        private readonly IAccess _access;
        public ODataLinkController(IODataLink odata , IAccess access)
        {
            _odata = odata;
            _access = access;
        }

        [HttpGet]
        public async Task<ResponseDTO<IEnumerable<ODataLink>>> GetODataLinks()
        {
            return await _odata.GetAll();
        }

        [HttpGet("{id:int}")]
        public Task<ResponseDTO<Access>> Get(int id)
        {
            return _access.Get(id);
        }

        //[HttpPost]
        //public async Task<ResponseDTO<ODataLink>> AddODataLink([FromBody] ODataLinkDTO model)
        //{
        //    ODataLink Odata = new ODataLink()
        //    {
        //        description = model.Description,
        //        link = model.Link,
        //        body = model.Body,
        //        active = model.Active
        //    };
        //    return await _odata.Add(Odata);
        //}

        //[HttpPut]
        //public async Task<ResponseDTO<ODataLink>> UpdateODataLink([FromBody] ODataLink model)
        //{
        //    return await _odata.Update(model);
        //}
    }
}