using DataInjestion.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Business.Contract
{
    public interface IPostData
    {
        bool InjectDataToElasticsearch(List<ElasticModel> elasticDataList);
    }
}
