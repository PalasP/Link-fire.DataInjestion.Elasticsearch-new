using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Models
{
    public class ElasticArtistModel
    {
        //ArtistId
        public long? id { get; set; }

        //Name
        public string name { get; set; }
    }
}
