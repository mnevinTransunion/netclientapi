using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trustev_DotNet.Exceptions
{
    /// <summary>
    /// These expcetions are thrown when a Http Error code is returned from the Trustev API
    /// </summary>
    public class TrustevHttpException : Exception
    {
        public HttpStatusCode HttpResponseCode;

        public TrustevHttpException(HttpStatusCode responseCode, string message) :base(message)
        {
            HttpResponseCode = responseCode;
        }
    }
}
