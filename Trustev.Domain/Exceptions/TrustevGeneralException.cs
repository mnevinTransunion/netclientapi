using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trustev.Domain.Exceptions
{
    /// <summary>
    /// This is a general TrustevClient Exception, inspect the message for more details
    /// </summary>
    public class TrustevGeneralException : Exception
    {
        public TrustevGeneralException(string message) : base(message)
        { 
        }
    }
}
