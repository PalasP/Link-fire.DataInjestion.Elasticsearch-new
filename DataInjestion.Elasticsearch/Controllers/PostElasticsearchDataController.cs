using DataInjestion.Elasticsearch.Models;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostElasticsearchDataController : ControllerBase
    {
        private readonly IOptions<AppConfiguration> _config;
        public PostElasticsearchDataController(IOptions<AppConfiguration> config)
        {
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> PostDataToElasticSearch(List<ElasticModel> elasticdata)
        {
            Business.Implementation.PostData postData = new Business.Implementation.PostData(_config);
            bool response = postData.InjectDataToElasticsearch(elasticdata);
            StatusCodeResult responsecode = response ? StatusCode(200) : StatusCode(417);//417 -> Expectation Failed
            return responsecode;

        }

    }
}
