using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    [JsonObject]
    public class Inbox
    {
        [JsonProperty("messages")]
        public ICollection<InboxMessageDto> Messages { get; set; }
    }
}
