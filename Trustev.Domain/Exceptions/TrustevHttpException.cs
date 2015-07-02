using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trustev.Domain.Exceptions
{
    /// <summary>
    /// These Exceptions are thrown when a Http Error code is returned from the TrustevClient API
    /// </summary>
    public class TrustevHttpException : Exception
    {
        public TrustevHttpException(HttpStatusCode responseCode, string message) : base(message)
        {
            this.HttpResponseCode = responseCode;
        }

        public HttpStatusCode HttpResponseCode { get; set; }
    }
}
