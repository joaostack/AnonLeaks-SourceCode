using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnonLeaks.Models
{
    public class EmailModel
    {
        public class LogData
        {
            [JsonPropertyName("document1")]
            public List<Document1Item> Document1 { get; set; }

            [JsonPropertyName("document2")]
            public List<Document2Item> Document2 { get; set; }
        }

        public class Document2Item
        {
            [JsonPropertyName("host")]
            public string Host { get; set; }

            [JsonPropertyName("path")]
            public string Path { get; set; }

            [JsonPropertyName("user")]
            public string User { get; set; }

            [JsonPropertyName("pass")]
            public string Pass { get; set; }
        }

        public class Document1Item
        {
            [JsonPropertyName("user")]
            public string User { get; set; }

            [JsonPropertyName("pass")]
            public string Pass { get; set; }
        }
    }

    public class UrlModel
    {
        public string host { get; set; }
        public string path { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
    }

    public class UrlModelList
    {
        public List<UrlModel> data { get; set; }
    }

    public class ErrorModel
    {
        public class Root
        {
            public string error { get; set; }
            public int code { get; set; }
        }
    }

    public class SubDomainModel
    {
        public class Root
        {
            [JsonPropertyName("document1")]
            public List<Subdomain> Document1 { get; set; }

            [JsonPropertyName("document2")]
            public List<List<Document2Item>> Document2 { get; set; }
        }

        public class Subdomain
        {
            [JsonPropertyName("subdomain")]
            public string SubdomainName { get; set; }
        }

        public class Document2Item
        {
            [JsonPropertyName("host")]
            public string Host { get; set; }

            [JsonPropertyName("path")]
            public string Path { get; set; }

            [JsonPropertyName("user")]
            public string User { get; set; }

            [JsonPropertyName("pass")]
            public string Pass { get; set; }
        }
    }

    public class GetMeModel
    {
        public class Root
        {
            public int queries { get; set; }
            public int total_queries_made { get; set; }
            public string token { get; set; }
        }
    }
}
