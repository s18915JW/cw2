using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Program
{
    [Serializable]
    public class Student
    {
        [XmlElement(ElementName = "fname")]
        [JsonProperty("fname")]
        public string fname { get; set; }
        [XmlElement(ElementName = "lname")]
        [JsonProperty("lname")]
        public string lname { get; set; }
        [XmlAttribute(AttributeName = "indexNumber")]
        [JsonProperty("indexNumber")]
        public string indexNumber { get; set; }
        [XmlElement(ElementName = "birthdate")]
        [JsonProperty("birthdate")]
        public string birthdate { get; set; }
        [XmlElement(ElementName = "email")]
        [JsonProperty("email")]
        public string email { get; set; }
        [XmlElement(ElementName = "mothersName")]
        [JsonProperty("mothersName")]
        public string mothersName { get; set; }
        [XmlElement(ElementName = "fathersName")]
        [JsonProperty("fathersName")]
        public string fathersName { get; set; }
        [XmlElement(ElementName = "studies")]
        [JsonProperty("studies")]
        public Study studies { get; set; }

        public Student() { }
	}
}
