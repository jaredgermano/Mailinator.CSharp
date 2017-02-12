using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    [JsonObject("data")]
    public class EmailData
    {
        [JsonProperty("fromfull")]
        public string FromFull { get; set; }

        [JsonProperty("headers")]
        public EmailHeader Headers { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

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

        [JsonProperty("parts")]
        public ICollection<EmailPart> Parts { get; set; }
    }
}
