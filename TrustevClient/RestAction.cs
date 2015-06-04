namespace Trustev.Api.Client
{
	public class RestAction
	{
		public RestAction(string url, HttpMethod method)
		{
			Url = url;
			Method = method;
		}

		public string Url { get; set; }
		public HttpMethod Method { get; set; }
	}
}