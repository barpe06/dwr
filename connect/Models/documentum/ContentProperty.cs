using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace connect.Models.documentum
{

    public class PropertiesType
    {

        [JsonProperty("r_object_type")]
        public string r_object_type { get; set; }

        [JsonProperty("object_name")]
        public string object_name { get; set; }

        [JsonProperty("author_creator")]
        public string author_creator { get; set; }

        [JsonProperty("author_date")]
        public string author_date { get; set; }

        [JsonProperty("topic_subject")]
        public string topic_subject { get; set; }

        //[JsonProperty("r_full_content_size")]
        //public int r_full_content_size { get; set; }

        //[JsonProperty("format_name")]
        //public string format_name { get; set; }
    }

    public class ContentProperty
    {

        [JsonProperty("properties")]
        public PropertiesType properties { get; set; }
    }
}