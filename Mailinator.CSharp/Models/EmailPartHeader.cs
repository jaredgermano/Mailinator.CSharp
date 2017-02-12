using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    [JsonObject("headers")]
    public class EmailPartHeader
    {
        [JsonProperty("content-transfer-encoding")]
        public string ContentTransferEncoding { get; set; }

        [JsonProperty("content-type")]
        public string ContentType { get; set; }
    }
}
