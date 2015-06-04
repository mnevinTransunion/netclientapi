using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Trustev.Api.Client.Entities;

namespace Trustev.Api.Client
{
	public class TrustevBaseClient
	{
		#region Private members

		private readonly string _baseUrl;
		private static Dictionary<Type, MethodInfo[]> _implMethods = new Dictionary<Type, MethodInfo[]>();
		private Type _curerntType;
		#endregion

		#region Constructor

		public TrustevBaseClient(string baseUrl, string userName, string password, string secret)
		{
			if (string.IsNullOrEmpty(baseUrl)) throw new ArgumentNullException("baseUrl", "Please specifiy base URL for client");

			_baseUrl = baseUrl;
			UserName = userName;
			Password = password;
			Secret = secret;

			_curerntType = this.GetType();

			if (!_implMethods.ContainsKey(_curerntType))
			{
				_implMethods.Add(_curerntType, _curerntType.GetMethods());
			}
		}

		#endregion

		#region Private methods

		private static string GetSHA256(string text)
		{
			var hashString = new SHA256Managed();
			var hashValue = hashString.ComputeHash(Encoding.Default.GetBytes(text));
			return hashValue.Aggregate("", (current, x) => current + string.Format("{0:x2}", x));
		}

		#endregion

		#region Public properties

		public string Password { get; private set; }
		public string Secret { get; private set; }
		public string UserName { get; private set; }

		public static Token Token { get; set; }

		public static string TimeStamp
		{
			get { return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.000Z"); }
		}

		#endregion

		#region Public and protected methods

		public T CallApi<T>(string url, string method, object postData = null)
		{
			return JsonConvert.DeserializeObject<T>(ProcessRequest(url, method, postData));
		}

		public string ProcessRequest(string url, string method, object postData = null)
		{
			string retVal = null;
			var webReq = WebRequest.Create(string.Format("{0}{1}", _baseUrl, url));
			webReq.Method = method;
			webReq.ContentType = "application/json";

			if (Token != null)
			{
				webReq.Headers.Add("X-Authorization", string.Format("{0} {1}", UserName, Token.APIToken));
			}

			if (postData != null)
			{
				using (var sw = new StreamWriter(webReq.GetRequestStream()))
				{
					sw.Write(JsonConvert.SerializeObject(postData));
					sw.Close();
				}
			}

			try
			{
				using (var resp = (HttpWebResponse) webReq.GetResponse())
				{
					var rss = resp.GetResponseStream();
					if (rss != null)
					{
						using (var sr = new StreamReader(rss))
						{
							retVal = sr.ReadToEnd();
							sr.Close();
						}

						rss.Close();
						rss.Dispose();
					}
					resp.Close();
				}
			}
			catch (WebException e)
			{
				if (e.Status == WebExceptionStatus.ProtocolError)
				{
					var response = (HttpWebResponse) e.Response;
					var serverResponse = new ApiError
					{
						Message = "Server Error. "
					};

					using (var respStr = response.GetResponseStream())
					{
						if (respStr != null)
						{
							using (var sr = new StreamReader(respStr))
							{
								serverResponse = ApiError.ProcessResponse(sr.ReadToEnd());
								sr.Close();
							}
							respStr.Close();
						}
					}

					throw new TrustevApiCallException(string.Format("API Exception [Message]: {0}, [Url]: {1}", serverResponse.Message, url), e)
					{
						ServerReponse = serverResponse
					};
				}
			}

			return retVal;
		}


		public static TokenRequest GetTokenRequest(string userName, string password, string secret, string timeStamp)
		{
			return new TokenRequest
			{
				UserName = userName,
				Timestamp = timeStamp,
				PasswordHash = GetSHA256(GetSHA256(timeStamp + "." + password) + "." + secret),
				UserNameHash = GetSHA256(GetSHA256(timeStamp + "." + userName) + "." + secret)
			};
		}

		protected T GetAction<T>(object[] urlParams = null, object data = null, [CallerMemberName] string actionName = null)
		{
			var action = GetRestAction(actionName);

			if (action == null) throw new TrustevException(string.Format("Action {0} doesn't exists", actionName));

			try
			{
				var url = action.Url;
				if (urlParams != null)
				{
					url = string.Format(url, urlParams);
				}

				return CallApi<T>(url, action.Method.ToString().ToUpper(), data);
			}
			catch (TrustevApiCallException e)
			{
				throw new TrustevException("Trustev API Call Exception. See inner exception", e);
			}
			catch(Exception e)
			{
				throw new TrustevException("Trustev client exception", e);
			}
		}

		private RestAction GetRestAction(string methodName)
		{
			if (_implMethods.ContainsKey(_curerntType))
			{
				var typeMethods = _implMethods[_curerntType];

				var method = typeMethods.SingleOrDefault(m => m.Name == methodName);
				if (method == null) return null;

				var actionAttr = method.GetCustomAttribute<ActionAttribute>();
				if (actionAttr != null)
				{
					return new RestAction(actionAttr.Url, actionAttr.Method);
				}
			}
			return null;
		}

		#endregion
	}
}