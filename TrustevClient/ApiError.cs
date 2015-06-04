using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Trustev.Api.Client
{
	public class ApiError
	{
		public string Message { get; set; }
		public Dictionary<string, string[]> ModelState { get; set; }

		public string OriginalResponse { get; set; }

		public static ApiError ProcessResponse(string jsonError)
		{
			ApiError retVal = new ApiError();
			try
			{
				var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonError);

				if (dict.ContainsKey("Message"))
				{
					retVal.Message = dict["Message"].ToString();
				}

				if (dict.ContainsKey("ModelState"))
				{
					var val = dict["ModelState"].ToString();
					retVal.ModelState = JsonConvert.DeserializeObject<Dictionary<string, object[]>>(val)
						.ToDictionary(entry => entry.Key, entry => entry.Value.Select(c => c.ToString()).ToArray());
				}

				retVal.OriginalResponse = jsonError;
			}
			catch
			{
				retVal = new ApiError
				{
					OriginalResponse = jsonError
				
				};
			}
			return retVal;
		}
	}
}
