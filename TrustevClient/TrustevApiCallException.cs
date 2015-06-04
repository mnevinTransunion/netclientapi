using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trustev.Api.Client
{
	public class TrustevApiCallException : TrustevException
	{
		public ApiError ServerReponse { get; set; }
		public TrustevApiCallException(string message, Exception innerException = null) : base(message, innerException)
		{
		}
	}
}
