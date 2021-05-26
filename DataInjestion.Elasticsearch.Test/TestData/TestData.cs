using DataInjestion.Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Test.TestData
{
    public class TestData
    {
        public List<ElasticModel> AssembleData()
        {
            List<ElasticArtistModel> elasticArtistModel = new List<ElasticArtistModel>()
            {
                new ElasticArtistModel()
                {
                    id = 44,
                   name="testName"
                },
                new ElasticArtistModel()
                {
                    id = 45,
                   name="testName2"
                }
            };

            List<ElasticModel> elasticModel = new List<ElasticModel>() {
                new ElasticModel()
            {
                artists = elasticArtistModel,
                id = 123,
                name = "testalbum",
                imageUrl = "http://img.com/image/thumb/Music117/v4/92/b8/51/92b85100-13c8-8fa4-0856-bb27276fdf87/191061793557.jpg/170x170bb.jpg",
                url = "http://ms.com/album/nishana-single/1255407551?uo=5",
                upc = "191061793557",
                isCompilation = "false",
                label = "Aark Records",
                releaseDate = DateTime.Now
                        },
                new ElasticModel()
                {
                artists = elasticArtistModel,
                id = 1234,
                name = "testalbum1",
                imageUrl = "http://img.com/image/thumb/Music117/v4/92/b8/51/92b85100-13c8-8fa4-0856-bb27276fdf87/191061793557.jpg/170x170bb.jpg",
                url = "http://ms.com/album/nishana-single/1255407551?uo=5",
                upc = "191061793558",
                isCompilation = "true",
                label = "No Records",
                releaseDate = DateTime.Now
        }
            };
            return elasticModel;
        }

    }
}
