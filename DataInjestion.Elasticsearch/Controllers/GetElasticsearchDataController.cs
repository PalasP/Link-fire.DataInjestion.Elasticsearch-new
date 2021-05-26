using DataInjestion.Elasticsearch.Business.Contract;
using DataInjestion.Elasticsearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetElasticsearchDataController : ControllerBase
    {
        private readonly IOptions<AppConfiguration> _config;
        public GetElasticsearchDataController(IOptions<AppConfiguration> config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult GetDataFromElasticSearch()
        {
            IGetData getData = new Business.Implementation.GetData(_config);
            var response = getData.ReadDataFromElasticSearch();
            if (response != null)
            {
                return Content("Total documents count :" + response.Count.ToString());
            }
            return StatusCode(204); //204 -> no content response

        }
    }
}
