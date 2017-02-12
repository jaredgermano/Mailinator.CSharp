using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    public class InboxRequest : BaseRequest
    {
        public string To { get; set; }
    }
}
