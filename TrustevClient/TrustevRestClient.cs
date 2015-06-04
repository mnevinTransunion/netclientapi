using System;
using Trustev.Api.Client.Entities;

namespace Trustev.Api.Client
{
	public class TrustevRestClient : TrustevBaseClient
	{
		#region Constructor

		public TrustevRestClient(string baseUrl, string userName, string password, string secret)
			: base(baseUrl, userName, password, secret)
		{
		}

		#endregion

		#region Public methods

		[Action(HttpMethod.Post, "/token")]
		public Token Authenticate()
		{
			var tokenRequest = GetTokenRequest(UserName, Password, Secret, TimeStamp);
			return GetAction<Token>(null, tokenRequest);
		}

		[Action(HttpMethod.Post, "/case")]
		public Case CreateCase(Case caseParam)
		{
			return GetAction<Case>(null, caseParam);
		}

		[Action(HttpMethod.Get, "/case/{0}")]
		public Case GetCase(string caseId)
		{
			return GetAction<Case>(new object[] {caseId});
		}

		[Action(HttpMethod.Put, "/case/{0}")]
		public Case UpdateCase(Case caseParam)
		{
			return GetAction<Case>(new object[] { caseParam.Id }, caseParam);
		}

		[Action(HttpMethod.Get, "/decision/{0}")]
		public Decision GetDecision(Case caseParam)
		{
			return GetAction<Decision>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Get, "/decision/{0}/overall")]
		public Decision GetDecisionOverall(Case caseParam)
		{
			return GetAction<Decision>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Get, "/decision/{0}/login")]
		public Decision GetDecisionLogin(Case caseParam)
		{
			return GetAction<Decision>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Get, "/decision/{0}/createaccount")]
		public Decision GetDecisionCreateAccount(Case caseParam)
		{
			return GetAction<Decision>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/customer/email")]
		public Email AddCustomerEmail(Case caseParam, Email email)
		{
			return GetAction<Email>(new object[] {caseParam.Id}, email);
		}

		[Action(HttpMethod.Put, "/case/{0}/customer/email/{1}")]
		public Email UpdateCustomerEmail(Case caseParam, Email email)
		{
			return GetAction<Email>(new object[] {caseParam.Id, email.Id}, email);
		}

		[Action(HttpMethod.Get, "/case/{0}/customer/email/{1}")]
		public Email GetCustomerEmail(Case caseParam, Guid? emailId)
		{
			return GetAction<Email>(new object[] {caseParam.Id, emailId});
		}

		[Action(HttpMethod.Get, "/case/{0}/customer/email")]
		public Email[] GetCustomerEmails(Case caseParam)
		{
			return GetAction<Email[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/customer")]
		public Customer CreateCustomer(Case caseParam, Customer customer)
		{
			return GetAction<Customer>(new object[] {caseParam.Id}, customer);
		}

		[Action(HttpMethod.Put, "/case/{0}/customer")]
		public Customer UpdateCustomer(Case caseParam, Customer customer)
		{
			return GetAction<Customer>(new object[] {caseParam.Id}, customer);
		}

		[Action(HttpMethod.Get, "/case/{0}/customer")]
		public Customer GetCustomer(Case caseParam)
		{
			return GetAction<Customer>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/transaction/item")]
		public TransactionItem CreateTransactionItem(Case caseParam, TransactionItem item)
		{
			return GetAction<TransactionItem>(new object[] {caseParam.Id}, item);
		}

		[Action(HttpMethod.Put, "/case/{0}/transaction/item/{1}")]
		public TransactionItem UpdateTransactionItem(Case caseParam, TransactionItem item)
		{
			return GetAction<TransactionItem>(new object[] {caseParam.Id, item.Id}, item);
		}

		[Action(HttpMethod.Get, "/case/{0}/transaction/item/{1}")]
		public TransactionItem GetTransactionItem(Case caseParam, Guid? itemId)
		{
			return GetAction<TransactionItem>(new object[] {caseParam.Id, itemId});
		}

		[Action(HttpMethod.Get, "/case/{0}/transaction/item")]
		public TransactionItem[] GetTransactionItems(Case caseParam)
		{
			return GetAction<TransactionItem[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/customer/socialaccount")]
		public SocialAccount AddSocialAccount(Case caseParam, SocialAccount account)
		{
			return GetAction<SocialAccount>(new object[] {caseParam.Id}, account);
		}

		[Action(HttpMethod.Put, "/case/{0}/customer/socialaccount/{1}")]
		public SocialAccount UpdateSocialAccount(Case caseParam, SocialAccount account)
		{
			return GetAction<SocialAccount>(new object[] {caseParam.Id, account.Id}, account);
		}

		[Action(HttpMethod.Get, "/case/{0}/customer/socialaccount/{1}")]
		public SocialAccount GetSocialAccount(Case caseParam, Guid? accountId)
		{
			return GetAction<SocialAccount>(new object[] {caseParam.Id, accountId});
		}

		[Action(HttpMethod.Get, "/case/{0}/customer/socialaccount")]
		public SocialAccount[] GetSocialAccounts(Case caseParam)
		{
			return GetAction<SocialAccount[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/customer/address")]
		public Address CreateCustomerAddress(Case caseParam, Address address)
		{
			return GetAction<Address>(new object[] {caseParam.Id}, address);
		}

		[Action(HttpMethod.Put, "/case/{0}/customer/address/{1}")]
		public Address UpdateCustomerAddress(Case caseParam, Address address)
		{
			return GetAction<Address>(new object[] {caseParam.Id, address.Id}, address);
		}

		[Action(HttpMethod.Get, "/case/{0}/customer/address/{1}")]
		public Address GetCustomerAddress(Case caseParam, Guid? addressId)
		{
			return GetAction<Address>(new object[] {caseParam.Id, addressId});
		}

		[Action(HttpMethod.Get, "/case/{0}/customer/address")]
		public Address[] GetCustomerAddresses(Case caseParam)
		{
			return GetAction<Address[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/transaction")]
		public Transaction CreateTransaction(Case caseParam, Transaction transaction)
		{
			return GetAction<Transaction>(new object[] {caseParam.Id}, transaction);
		}

		[Action(HttpMethod.Put, "/case/{0}/transaction")]
		public Transaction UpdateTransaction(Case caseParam, Transaction transaction)
		{
			return GetAction<Transaction>(new object[] {caseParam.Id}, transaction);
		}

		[Action(HttpMethod.Get, "/case/{0}/transaction")]
		public Transaction GetTransaction(Case caseParam)
		{
			return GetAction<Transaction>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/payment")]
		public Payment CreatePayment(Case caseParam, Payment payment)
		{
			return GetAction<Payment>(new object[] {caseParam.Id}, payment);
		}

		[Action(HttpMethod.Put, "/case/{0}/payment/{1}")]
		public Payment UpdatePayment(Case caseParam, Payment payment)
		{
			return GetAction<Payment>(new object[] {caseParam.Id, payment.Id}, payment);
		}

		[Action(HttpMethod.Get, "/case/{0}/payment")]
		public Payment[] GetPayments(Case caseParam)
		{
			return GetAction<Payment[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Get, "/case/{0}/payment/{1}")]
		public Payment GetPayment(Case caseParam, Guid? paymentId)
		{
			return GetAction<Payment>(new object[] {caseParam.Id, paymentId});
		}

		[Action(HttpMethod.Post, "/case/{0}/transaction/address")]
		public Address AddTransactionAddress(Case caseParam, Address address)
		{
			return GetAction<Address>(new object[] {caseParam.Id}, address);
		}

		[Action(HttpMethod.Put, "/case/{0}/transaction/address/{1}")]
		public Address UpdateTransactionAddress(Case caseParam, Address address)
		{
			return GetAction<Address>(new object[] {caseParam.Id, address.Id}, address);
		}

		[Action(HttpMethod.Get, "/case/{0}/transaction/address/{1}")]
		public Address GetTransactionAddress(Case caseParam, Guid? addressId)
		{
			return GetAction<Address>(new object[] {caseParam.Id, addressId});
		}

		[Action(HttpMethod.Get, "/case/{0}/transaction/address")]
		public Address[] GetTransactionAddresses(Case caseParam)
		{
			return GetAction<Address[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Post, "/case/{0}/status")]
		public CaseStatus AddStatus(Case caseParam, CaseStatus status)
		{
			return GetAction<CaseStatus>(new object[] {caseParam.Id}, status);
		}

		[Action(HttpMethod.Get, "/case/{0}/status/{1}")]
		public CaseStatus GetStatus(Case caseParam, Guid? statusId)
		{
			return GetAction<CaseStatus>(new object[] {caseParam.Id, statusId});
		}

		[Action(HttpMethod.Get, "/case/{0}/status")]
		public CaseStatus[] GetStatuses(Case caseParam)
		{
			return GetAction<CaseStatus[]>(new object[] {caseParam.Id});
		}

		[Action(HttpMethod.Get, "/history/casesummary?CaseNumber={0}&StartDate={1}&EndDate={2}&SortBy={3}&PageNumber={4}")]
		public object GetCaseSummaryHistory(string caseNumber, DateTime startDate, DateTime endDate, CaseSummarySortOptions sortBy,
			int pageNumber)
		{
			return GetAction<object>(new object[] {caseNumber, startDate.ToString("s"), endDate.ToString("s"), sortBy, pageNumber});
		}

		[Action(HttpMethod.Get, "/history/decisionreview/{0}")]
		public object GetCaseDecisionHistory(string caseNumber)
		{
			return GetAction<CaseStatus[]>(new object[] {caseNumber});
		}

		[Action(HttpMethod.Get, "/History?CaseNumber={0}&StartDate={1}&EndDate={2}&SortBy={3}&PageNumber={4}")]
		public object GetCaseHistoryFilter(string caseNumber, DateTime startDate, DateTime endDate, CaseSummarySortOptions sortBy,
			int pageNumber)
		{
			return GetAction<CaseStatus[]>(new object[] { caseNumber, startDate.ToString("s"), endDate.ToString("s"), sortBy, pageNumber });
		}

		[Action(HttpMethod.Get, "/History?caseNumber={0}")]
		public object GetCaseHistory(string caseNumber)
		{
			return GetAction<CaseStatus[]>(new object[] {caseNumber});
		}

		#endregion
	}
}