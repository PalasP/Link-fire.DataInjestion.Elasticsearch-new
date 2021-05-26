using DataInjestion.Elasticsearch.Business.Contract;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataInjestion.Elasticsearch.Test.Business.Test.Implementation.Test
{
    public class GetDataTest
    {        
        private readonly Elasticsearch.Business.Contract.IGetData _getData;
        private readonly Mock<IOptions<AppConfiguration>> _config;
        string indexNameExist = "test3";
        string indexNameNotExist = "abcde";

        public GetDataTest()
        {
            _config = new Mock<IOptions<AppConfiguration>>();
                       
            _getData = new Elasticsearch.Business.Implementation.GetData(_config.Object);
        }

        [Fact]
        public async Task Retrieve_GetDataFromElasticSearch()
        {
            //Arrange
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            //mockAppConfiguration
            var response =  _getData.ReadDataFromElasticSearch();
            //Assert
            Assert.True(response.Count >= 0);
        }


    }
}
