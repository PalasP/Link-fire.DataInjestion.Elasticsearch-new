using DataInjestion.Elasticsearch.Controllers;
using DataInjestion.Elasticsearch.Models;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataInjestion.Elasticsearch.Test.Controllers.Test
{
    public class PostElasticsearchDataControllerTest
    {
        private readonly PostElasticsearchDataController _controller;
        private readonly Elasticsearch.Business.Contract.IPostData _postData;
        private readonly Mock<IOptions<AppConfiguration>> _config;
        string indexNameExist = "test3";
        string indexNameNotExist = "abcd";
        TestData.TestData testData = new TestData.TestData();

        public PostElasticsearchDataControllerTest()
        {
            _config = new Mock<IOptions<AppConfiguration>>();         
            _controller = new PostElasticsearchDataController(_config.Object);
            _postData = new Elasticsearch.Business.Implementation.PostData(_config.Object);
            
        }
               

        [Fact]
        public void IPostDataToElasticSearch_IndexNameNotExist()
        {
            var data = testData.AssembleData();
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            var response = _controller.PostDataToElasticSearch(data);
            Assert.NotNull(response);
        }


        [Fact]
        public void PostDataToElasticSearch_IndexNameNotExist()
        {
            var data = testData.AssembleData();
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameNotExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            var response = _controller.PostDataToElasticSearch(data);
            Assert.NotNull(response);
        }



        
    }
}
