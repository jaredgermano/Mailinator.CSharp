using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    [JsonObject("parts")]
    public class EmailPart
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("headers")]
        public EmailPartHeader Headers { get; set; }
    }
}
