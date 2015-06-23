using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trustev_DotNet.Exceptions
{
    /// <summary>
    /// This is a general Trustev Exception, inspect the message for more details
    /// </summary>
    public class TrustevGeneralException : Exception
    {
        public TrustevGeneralException(string message) :base(message)
        {
            
        }
    }
}
