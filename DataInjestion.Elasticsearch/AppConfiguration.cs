using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Elasticsearch
{
    public class AppConfiguration
    {
        public string indexName { get; set; }
        public string tableName { get; set; }
        public string elasticSearchUrl { get; set; }
    }
}
