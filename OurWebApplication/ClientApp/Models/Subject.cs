using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Subject
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "Credits")]
        public int Credits { get; set; }
        [JsonProperty(PropertyName = "Hours")]
        public int? Hours { get; set; }
    }
}
