using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    public class BaseRequest
    {
        public string Token { get; set; }
        public bool UsePrivateDomain { get; set; }
    }
}
