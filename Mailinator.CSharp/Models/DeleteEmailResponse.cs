using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    public class DeleteEmailResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
