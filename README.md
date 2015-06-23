#Trustev .NET Libary
- If you are not familiar with Trustev, start with our [Developer Portal](http://www.trustev.com/developers).
- Check out our [API Documentation](http://www.trustev.com/developers#apioverview).

##Installation
- TODO : Detail how to install the NuGet package here

## Usage
```c#
//You need to set-up the ApiClient by providing your Merchant Credentials
ApiClient.SetUp(userName, password, secret);

//Create cyou case object
// SessionId and CaseNumber are compulsory so they must be provided in the constructor
//Every thing else is optional
Guid sessionId = //This is where you will use you Trustev.SessionId
string caseNumber = "CaseNumber1" // This is the caseNumber you want to assign the case. It must be unique!

Case kase = new Case(sessionId, caseNumber)
kase.Customer = new Customer()
{
	FirstName = "John",
    LastName = "Doe",
}

//Post this case to the Truutev Api
Case returnCase = ApiClient.PostCase(kase);

//No you can get you trustev Decision
Decision decision = ApiClient.GetDecision(returnCase.Id);
```

