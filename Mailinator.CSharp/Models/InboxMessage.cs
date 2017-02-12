using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    public class InboxMessageDto
    {
        [JsonProperty("fromfull")]
        public string FromFull { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("origfrom")]
        public string OrigFrom { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("seconds_ago")]
        public long SecondsAgo { get; set; }
    }
}
