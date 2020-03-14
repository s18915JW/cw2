using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Program
{
    [Serializable]
    public class ActiveStudy : IComparable
    {
        [XmlElement(ElementName = "studiesName")]
        [JsonProperty("studiesName")]
        public string studiesName { get; set; }
        [XmlElement(ElementName = "numberOfStudents")]
        [JsonProperty("numberOfStudents")]
        public int numberOfStudents { get; set; }

        public ActiveStudy() { }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ActiveStudy other = obj as ActiveStudy;

            if (other != null)
                return other.numberOfStudents.CompareTo(this.numberOfStudents);
            else
                throw new ArgumentException("Object is not an ActiveStudy");
         
        }
    }
}
