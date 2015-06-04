using System;
using Newtonsoft.Json;

namespace Trustev.Api.Client.Entities
{
	public class Token
	{
		public Token(string jsonObject = null)
		{
			if (jsonObject != null)
			{
				var desObj = JsonConvert.DeserializeObject<Token>(jsonObject);
				ExpireAt = desObj.ExpireAt;
				APIToken = desObj.APIToken;
				CredentialType = desObj.CredentialType;
			}
		}

		public DateTime ExpireAt { get; set; }
		public Guid APIToken { get; set; }
		public string CredentialType { get; set; }
	}
}