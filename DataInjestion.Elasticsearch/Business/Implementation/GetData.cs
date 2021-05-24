using DataInjestion.Elasticsearch.Models;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Business.Implementation
{
    public class GetData : Contract.IGetData
    {
        private readonly IOptions<AppConfiguration> _config;

        public GetData(IOptions<AppConfiguration> config)
        {
            _config = config;
        }


        public CountResponse ReadDataFromElasticSearch()
        {
            Uri EsInstance = new Uri(_config.Value.elasticSearchUrl);
            ConnectionSettings EsConfiguration = new ConnectionSettings(EsInstance)/*.DefaultMappingFor<List<ElasticModel>>*/;
            ElasticClient EsClient = new ElasticClient(EsConfiguration);

            var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };
            var indexConfig = new IndexState
            {
                Settings = settings
            };

            if (EsClient.Indices.Exists(_config.Value.indexName).Exists) //creating database named "sample". check if exist before creating the new  
            {
                CountResponse getTableData = EsClient.Count<ElasticModel>(s => s.Index(_config.Value.indexName)); // This will return Count of records in table  
                return getTableData;
            }
            else
            {
                return null;
            }
        }
    }
}
