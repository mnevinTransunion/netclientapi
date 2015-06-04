namespace Trustev.Api.Client.Entities
{
	public enum DecisionResult
	{
		/// <summary>
		///   This result should not be returned to you. It means that an error has occurred and a Trustev Decision has not been
		///   made on your Trustev Case. Please contact support@trustev.com should this occur. Please provide the Case Number and
		///   Case Id when sending this request.
		/// </summary>
		Unknown = 0,

		/// <summary>
		///   This result indicates that the Trustev Case shows no signs for suspicion and the 'transaction' should be accepted.
		/// </summary>
		Pass = 1,

		/// <summary>
		///   This result indicates that the Trustev Case contains elements for suspicion which should be reviewed before a final
		///   decision is made.
		/// </summary>
		Flag = 2,

		/// <summary>
		///   This result indicates that the Trustev Case contains a number of fraudulent features and the 'transaction' should be
		///   rejected.
		/// </summary>
		Fail = 3
	}
}