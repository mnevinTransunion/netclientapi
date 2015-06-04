using System;

namespace Trustev.Api.Client
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ActionAttribute : Attribute
	{
		public ActionAttribute(HttpMethod method, string url)
		{
			Method = method;
			Url = url;
		}

		public string Url { get; private set; }
		public HttpMethod Method { get; private set; }
	}
}