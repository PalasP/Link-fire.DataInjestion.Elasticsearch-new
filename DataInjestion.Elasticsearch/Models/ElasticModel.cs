using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch.Models
{
    public class ElasticModel
    {
        //CollectionId
        public long id { get; set; }
        public string name { get; set; }

        //ViewUrl
        public string url { get; set; }

        //Collectionmatch/Upc
        public string upc { get; set; }

        //OriginalReleaseDate
        public DateTime? releaseDate { get; set; }

        //IsCompilation 
        public string isCompilation { get; set; }

        //LabelStudio
        public string label { get; set; }

        //ArtworkUrl
        public string imageUrl { get; set; }

        public List<ElasticArtistModel> artists { get; set; }
    }
}
