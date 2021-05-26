using DataInjestion.Elasticsearch.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataInjestion.Elasticsearch.Test.Controllers.Test
{
    public class GetElasticsearchDataControllerTest
    {
        private readonly GetElasticsearchDataController _controller;
        private readonly Elasticsearch.Business.Contract.IGetData _getData;
        private readonly Mock<IOptions<AppConfiguration>> _config;
        string indexNameExist = "test3";
        string indexNameNotExist = "abcde";

        public GetElasticsearchDataControllerTest()
        {
            _config = new Mock<IOptions<AppConfiguration>>();

            _controller = new GetElasticsearchDataController(_config.Object);
            _getData = new Elasticsearch.Business.Implementation.GetData(_config.Object);
        }

        //controller action method test
        [Fact]
        public async Task Retrieve_GetDataFromElasticSearch()
        {
            //Arrange
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            //mockAppConfiguration
            ActionResult response = _controller.GetDataFromElasticSearch();
            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Retrieve_GetDataFromElasticSearch_IndexNotPresent()
        {
            //Arrange
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameNotExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            //Act
            ActionResult response = _controller.GetDataFromElasticSearch();
            //Assert
            Assert.NotNull(response);
        }


        //GetData Method Test

        [Fact]
        public void Retrieve_GetDataFromElasticSearchMethod()
        {
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            var response = _getData.ReadDataFromElasticSearch();
            Assert.True(response.Count >= 0);
        }

        [Fact]
        public void Retrieve_GetDataFromElasticSearchMethod__IndexNotPresent()
        {
            var mockAppConfiguration = Mock.Of<AppConfiguration>(x => x.elasticSearchUrl == "http://localhost:9200" && x.indexName == indexNameNotExist && x.tableName == "test1");
            _config.Setup(x => x.Value).Returns(mockAppConfiguration);
            var response = _getData.ReadDataFromElasticSearch();
            Nest.CountResponse expectedResponse = null;
            Assert.Equal(response, expectedResponse);
        }
    }
}
