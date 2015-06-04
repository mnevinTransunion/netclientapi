
// Generated by ApiCrawler

using System;
using Trustev.Api.Client.Entities;
using Newtonsoft.Json;

namespace Trustev.Api.Client.Entities {

		
	/// <summary>
	/// 
	/// </summary>
	public class Address {

		#region Public properties

				
		/// <summary>
		/// This is the Address Id. This Id is returned when Address Information has been added to the Transaction object.		/// This Id is required should you wish to update the Address details after a Trustev Case has been added.		/// Please note: this Id is always returned from the Trustev API as a reference Id to the specific object.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public System.Guid? Id;
		
		/// <summary>
		/// The First Name for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string FirstName;
		
		/// <summary>
		/// The Last Name for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string LastName;
		
		/// <summary>
		/// Address Line 1 for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Address1;
		
		/// <summary>
		/// Address Line 2 for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Address2;
		
		/// <summary>
		/// Address Line 3 for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Address3;
		
		/// <summary>
		/// City for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string City;
		
		/// <summary>
		/// State for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string State;
		
		/// <summary>
		/// The Postal Code for the Standard/Billing/Delivery Address.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string PostalCode;
		
		/// <summary>
		/// The Address Type â€“ Standard (0), Billing (1), or Delivery (2)
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public AddressType Type;
		
		/// <summary>
		/// These are the 2 letter country codes published by ISO.		/// Details can be found at http://www.nationsonline.org/oneworld/countrycodes.htm
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string CountryCode;
		
		/// <summary>
		/// Current Timestamp. Accepted format: yyyy-MM-ddTHH:mm:ss.fffZ		/// See our FAQ section for more information.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public System.DateTime? Timestamp;
		
		/// <summary>
		/// Is this the default address?
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsDefault;

		
		#endregion
		
		#region Constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="jsonObject">JSON string defines object</param>
		public Address(string jsonObject = null) {
		if(jsonObject!=null) {
				var desObj = JsonConvert.DeserializeObject<Address>(jsonObject);
				this.Id = desObj.Id;
				this.FirstName = desObj.FirstName;
				this.LastName = desObj.LastName;
				this.Address1 = desObj.Address1;
				this.Address2 = desObj.Address2;
				this.Address3 = desObj.Address3;
				this.City = desObj.City;
				this.State = desObj.State;
				this.PostalCode = desObj.PostalCode;
				this.Type = desObj.Type;
				this.CountryCode = desObj.CountryCode;
				this.Timestamp = desObj.Timestamp;
				this.IsDefault = desObj.IsDefault;
			}
		}

		#endregion
	}
}
