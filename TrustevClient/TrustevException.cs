using System;

namespace Trustev.Api.Client
{
	public class TrustevException : Exception
	{
		public TrustevException(string message, Exception innerException = null) : base(message, innerException)
		{
		}
	}
}