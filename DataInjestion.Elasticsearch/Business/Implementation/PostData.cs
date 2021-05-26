using DataInjestion.Elasticsearch.Models;
using Elasticsearch.Net;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Business.Implementation
{
    public class PostData : Contract.IPostData
    {
        private readonly IOptions<AppConfiguration> _config;

        public PostData(IOptions<AppConfiguration> config)
        {
            _config = config;
        }

        /// <summary>
        /// Post the data in Elasticsearch
        /// </summary>
        /// <param name="elasticDataList"></param>
        /// <returns></returns>
        public bool InjectDataToElasticsearch(List<ElasticModel> elasticDataList)
        {
            try
            {
                if (elasticDataList != null)
                {
                    Uri EsInstance = new Uri(_config.Value.elasticSearchUrl);
                    ConnectionSettings EsConfiguration = new ConnectionSettings(EsInstance);
                    ElasticClient EsClient = new ElasticClient(EsConfiguration);

                    var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };
                    var indexConfig = new IndexState
                    {
                        Settings = settings
                    };

                    //creating database named "album". check if exist before creating the new  
                    if (!EsClient.Indices.Exists(_config.Value.indexName).Exists)
                    {

                        var response = EsClient.Indices.Create(_config.Value.indexName.ToLower(), index => index.Map<ElasticModel>(x => x.AutoMap()));
                    }

                    var getTableData = EsClient.Count<ElasticModel>(s => s.Index(_config.Value.indexName)); // This will return Count of records in table  

                    //var searchResult = EsClient.Search<ElasticModel>(s =>s./*From(0).Size(10).*/Index(indexName)/*Type(tableName)*//*.Query(q => q.Term(t => t))*/);
                    var searchResult = EsClient.Search<ElasticModel>(s => s.From(0).Size(3000).Index(_config.Value.indexName)/*Type(tableName)*//*.Query(q => q.Term(t => t))*/);

                    if (EsClient.Indices.Exists(_config.Value.indexName).Exists)
                    {
                        long count = getTableData.Count;

                        foreach (var item in elasticDataList)
                        {
                            //Here model is the Object containing the data which we passed to API and want to insert in Table / type
                            var result = EsClient.Index(item, i => i
                                .Index(_config.Value.indexName)
                                .Id(count + 1)
                                .Refresh(Refresh.True)
                                );
                            count++;
                            if (Convert.ToString(result.Result) == "Created")
                            {
                                Console.WriteLine("new entry created");
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return false;

        }
    }
}
