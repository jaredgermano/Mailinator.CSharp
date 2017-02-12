using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    /// <summary>
    /// Parent Email object that contains the data pertaining to the email
    /// </summary>
    public class Email
    {
        [JsonProperty("data")]
        public EmailData Data { get; set; }
    }
}
