using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{

    [JsonObject("headers")]
    public class EmailHeader
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("mime-version")]
        public string MimeVersion { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message-id")]
        public string Id { get; set; }

        [JsonProperty("x-echosign-bounce")]
        public string EchosignBounce { get; set; }

        [JsonProperty("x-echosign-template")]
        public string EchosignTemplate { get; set; }

        [JsonProperty("received")]
        public string Received { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("content-type")]
        public string ContentType { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("reply-to")]
        public string ReplyTo { get; set; }

        [JsonProperty("dkim-signature")]
        public string DkimSignature { get; set; }
    }
}
