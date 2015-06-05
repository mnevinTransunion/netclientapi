using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using Trustev.Api.Client;
using Trustev.Api.Client.Entities;

namespace TrustevClientTests
{
	[TestFixture]
	public class RestClientTests
	{
		[SetUp]
		public void Setup()
		{
			var rootPath = new FileInfo(Assembly.GetExecutingAssembly().FullName).DirectoryName;

			_newCase = JsonConvert.DeserializeObject<Case>(File.ReadAllText(string.Format("{0}\\Data\\Case.json", rootPath)));
			_newCase.CaseNumber = Guid.NewGuid().ToString().Replace("-", "").Substring(0,16).ToUpper();
			_newCase.SessionId = Guid.Parse("1148d785-1ba9-46a6-9767-4d9ab8e0f1fc");

			_newAddress =
				JsonConvert.DeserializeObject<Address>(File.ReadAllText(string.Format("{0}\\Data\\Address.json", rootPath)));
			_newCaseStatus =
				JsonConvert.DeserializeObject<CaseStatus>(File.ReadAllText(string.Format("{0}\\Data\\CaseStatus.json", rootPath)));
			_newCustomer =
				JsonConvert.DeserializeObject<Customer>(File.ReadAllText(string.Format("{0}\\Data\\Customer.json", rootPath)));
			_newEmail = JsonConvert.DeserializeObject<Email>(File.ReadAllText(string.Format("{0}\\Data\\Email.json", rootPath)));
			_newPayment =
				JsonConvert.DeserializeObject<Payment>(File.ReadAllText(string.Format("{0}\\Data\\Payment.json", rootPath)));
			_newSocialAccount =
				JsonConvert.DeserializeObject<SocialAccount>(
					File.ReadAllText(string.Format("{0}\\Data\\SocialAccount.json", rootPath)));
			_newTransaction =
				JsonConvert.DeserializeObject<Transaction>(File.ReadAllText(string.Format("{0}\\Data\\Transaction.json", rootPath)));
			_newTransactionItem =
				JsonConvert.DeserializeObject<TransactionItem>(
					File.ReadAllText(string.Format("{0}\\Data\\TransactionItem.json", rootPath)));
		}

		private readonly string _baseUrl;
		private readonly string _userName;
		private readonly string _password;
		private readonly string _secret;
		private Address _newAddress;
		private Case _newCase;
		private CaseStatus _newCaseStatus;
		private Customer _newCustomer;
		private Email _newEmail;
		private Payment _newPayment;
		private SocialAccount _newSocialAccount;
		private Transaction _newTransaction;
		private TransactionItem _newTransactionItem;

		public RestClientTests()
		{
			_baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
			_userName = ConfigurationManager.AppSettings["UserName"];
			_password = ConfigurationManager.AppSettings["Password"];
			_secret = ConfigurationManager.AppSettings["Secret"];
		}

		[Test]
		public void AddCustomerEmailTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newEmail = cl.AddCustomerEmail(newCase, _newEmail);
			Assert.IsNotNull(newEmail);
		}

		[Test]
		public void AddSocialAccountTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCust = cl.CreateCustomer(newCase, _newCustomer);
			var newSocAcc = cl.AddSocialAccount(newCase, _newSocialAccount);
			Assert.IsNotNull(newSocAcc);
		}

		[Test]
		public void AddStatusTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.AddStatus(newCase, _newCaseStatus);
			Assert.IsNotNull(res);
		}

		[Test]
		public void AddTransactionAddressTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newTransaction = cl.CreateTransaction(newCase, _newTransaction);
			var res = cl.AddTransactionAddress(newCase, _newAddress);
			Assert.IsNotNull(res);
		}

		[Test]
		public void AuthenticateTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var res = cl.Authenticate();
			Assert.IsNotNull(res);
		}

		[Test]
		public void CreateCaseTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			Assert.IsNotNull(newCase);
		}

		[Test]
		public void CreateCustomerAddressTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var res = cl.CreateCustomerAddress(newCase, _newAddress);
			Assert.IsNotNull(res);
		}

		[Test]
		public void CreateCustomerTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCust = cl.CreateCustomer(newCase, _newCustomer);
			Assert.IsNotNull(newCase);
		}

		[Test]
		public void CreatePaymentTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.CreatePayment(newCase, _newPayment);
			Assert.IsNotNull(res);
		}

		[Test]
		public void CreateTransactionItemTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newTrans = cl.CreateTransaction(newCase, _newTransaction);
			var res = cl.CreateTransactionItem(newCase, _newTransactionItem);
			Assert.IsNotNull(res);
		}

		[Test]
		public void CreateTransactionTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.CreateTransaction(newCase, _newTransaction);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCaseDecisionHistoryTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var decision = cl.GetDecision(newCase);
			var res = cl.GetCaseDecisionHistory(newCase.CaseNumber);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCaseHistoryFilterTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetCaseHistoryFilter(newCase.CaseNumber, new DateTime(2015, 1, 1), new DateTime(2015, 1, 1, 1, 0, 0),
				CaseSummarySortOptions.DateDesc, 1);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCaseHistoryTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetCaseHistory(newCase.CaseNumber);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCaseSummaryHistoryTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetCaseSummaryHistory(newCase.CaseNumber, new DateTime(2015, 1, 1), new DateTime(2015, 1, 1, 1, 0, 0),
				CaseSummarySortOptions.DateDesc, 1);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCaseTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetCase(newCase.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCustomerAddressesTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newCustomerAddress = cl.CreateCustomerAddress(newCase, _newAddress);
			var res = cl.GetCustomerAddresses(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCustomerAddressTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newCustomerAddress = cl.CreateCustomerAddress(newCase, _newAddress);
			var res = cl.GetCustomerAddress(newCase, newCustomerAddress.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCustomerEmailsTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newCustomerEmail = cl.AddCustomerEmail(newCase, _newEmail);
			var res = cl.GetCustomerEmails(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCustomerEmailTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newCustomerEmail = cl.AddCustomerEmail(newCase, _newEmail);
			var res = cl.GetCustomerEmail(newCase, newCustomerEmail.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetCustomerTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var res = cl.GetCustomer(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetDecisionCreateAccountTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetDecisionCreateAccount(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetDecisionLoginTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetDecisionLogin(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetDecisionOverallTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetDecisionOverall(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetDecisionTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.GetDecision(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetPaymentsTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newPayment = cl.CreatePayment(newCase, _newPayment);
			var res = cl.GetPayments(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetPaymentTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newPayment = cl.CreatePayment(newCase, _newPayment);
			var res = cl.GetPayment(newCase, newPayment.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetSocialAccountsTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newPayment = cl.AddSocialAccount(newCase, _newSocialAccount);
			var res = cl.GetSocialAccounts(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetSocialAccountTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newSocialAccount = cl.AddSocialAccount(newCase, _newSocialAccount);
			var res = cl.GetSocialAccount(newCase, newSocialAccount.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetStatusesTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newStatus = cl.AddStatus(newCase, _newCaseStatus);
			var res = cl.GetStatuses(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetStatusTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newStatus = cl.AddStatus(newCase, _newCaseStatus);
			var res = cl.GetStatus(newCase, newStatus.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetTransactionAddressesTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newTransaction = cl.CreateTransaction(newCase, _newTransaction);
			var newAddress = cl.AddTransactionAddress(newCase, _newAddress);
			var res = cl.GetTransactionAddresses(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetTransactionAddressTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newTrans = cl.CreateTransaction(newCase, _newTransaction);
			var newAddress = cl.AddTransactionAddress(newCase, _newAddress);
			var res = cl.GetTransactionAddress(newCase, newAddress.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetTransactionItemsTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newtransaction = cl.CreateTransaction(newCase, _newTransaction);
			var newItem = cl.CreateTransactionItem(newCase, _newTransactionItem);
			var res = cl.GetTransactionItems(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetTransactionItemTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newtransaction = cl.CreateTransaction(newCase, _newTransaction);
			var newItem = cl.CreateTransactionItem(newCase, _newTransactionItem);
			var res = cl.GetTransactionItem(newCase, newItem.Id);
			Assert.IsNotNull(res);
		}

		[Test]
		public void GetTransactionTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newtransaction = cl.CreateTransaction(newCase, _newTransaction);
			var res = cl.GetTransaction(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void TokenTest()
		{
			var timeStamp = "2015-06-03T09:54:20.000Z";
			var userName = "ABC";
			var password = "DEF";
			var secret = "GHI";

			var token = TrustevBaseClient.GetTokenRequest(userName, password, secret, timeStamp);
			Assert.IsNotNull(token);
			Assert.IsTrue(token.Timestamp == timeStamp);
			Assert.IsTrue(token.UserName == userName);
			Assert.IsTrue(token.UserNameHash == "0e2d0b1c9c14d9f177e85e05ab8f4cf6a5b710025add3ea78954aad3bcd6a78c");
			Assert.IsTrue(token.PasswordHash == "8559b900f2a784c9a6eb43fa4bd62e6835afe9182427e90748bb76d8f5c6d691");
		}

		[Test]
		public void UpdateCaseTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var res = cl.UpdateCase(newCase);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateCustomerAddressTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustome = cl.CreateCustomer(newCase, _newCustomer);
			var newAddress = cl.CreateCustomerAddress(newCase, _newAddress);
			var res = cl.UpdateCustomerAddress(newCase, newAddress);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateCustomerEmailTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newEmail = cl.AddCustomerEmail(newCase, _newEmail);
			var res = cl.UpdateCustomerEmail(newCase, newEmail);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateCustomerTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newCustomer = cl.CreateCustomer(newCase, _newCustomer);
			var res = cl.UpdateCustomer(newCase, newCustomer);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdatePaymentTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var newPayment = cl.CreatePayment(newCase, _newPayment);
			var res = cl.UpdatePayment(newCase, newPayment);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateSocialAccountTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var ccustomer = cl.CreateCustomer(newCase, _newCustomer);
			var newAccount = cl.AddSocialAccount(newCase, _newSocialAccount);
			var res = cl.UpdateSocialAccount(newCase, newAccount);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateTransactionAddressTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var transaction = cl.CreateTransaction(newCase, _newTransaction);
			var addr = cl.AddTransactionAddress(newCase, _newAddress);
			var res = cl.UpdateTransactionAddress(newCase, addr);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateTransactionItemTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var transaction = cl.CreateTransaction(newCase, _newTransaction);
			var item = cl.CreateTransactionItem(newCase, _newTransactionItem);
			var res = cl.UpdateTransactionItem(newCase, item);
			Assert.IsNotNull(res);
		}

		[Test]
		public void UpdateTransactionTest()
		{
			var cl = new TrustevRestClient(_baseUrl, _userName, _password, _secret);
			var token = cl.Authenticate();
			TrustevBaseClient.Token = token;
			var newCase = cl.CreateCase(_newCase);
			var transaction = cl.CreateTransaction(newCase, _newTransaction);
			var res = cl.UpdateTransaction(newCase, transaction);
			Assert.IsNotNull(res);
		}
	}
}