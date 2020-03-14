using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Program
{
    [Serializable]
    public class University
    {
        [XmlAttribute(AttributeName = "createdAt")]
        [JsonProperty("createdAt")]
        public string createdAt = DateTime.Today.ToShortDateString();
        [XmlAttribute(AttributeName = "author")]
        [JsonProperty("author")]
        public string name = "Jakub Woźniak";
       
        public HashSet<Student> students;
        public List<ActiveStudy> activeStudies;

        public University() { }
    }
}
