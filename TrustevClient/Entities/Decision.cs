using System;
using Newtonsoft.Json;

namespace Trustev.Api.Client.Entities
{
	public class Decision
	{
		public Decision(string jsonObject = null)
		{
			if (jsonObject != null)
			{
				var desObj = JsonConvert.DeserializeObject<Decision>(jsonObject);
				Id = desObj.Id;
				Version = desObj.Version;
				SessionId = desObj.SessionId;
				Timestamp = desObj.Timestamp;
				Type = desObj.Type;
				Result = desObj.Result;
				Score = desObj.Score;
				Confidence = desObj.Confidence;
				Comment = desObj.Comment;
			}
		}

		#region Public properties

		public string Id { get; set; }
		public int Version { get; set; }
		public string SessionId { get; set; }
		public DateTime Timestamp { get; set; }
		public string Type { get; set; }
		public DecisionResult Result { get; set; }
		public int Score { get; set; }
		public int Confidence { get; set; }
		public string Comment { get; set; }
		#endregion
	}
}