using System;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Program
{
    [Serializable]
    public class Study
    {
        [XmlElement(ElementName = "name")]
        [JsonProperty("name")]
        public string name { get; set; }
        [XmlElement(ElementName = "mode")]
        [JsonProperty("mode")]
        public string mode { get; set; }

        public Study() { }
    }
}