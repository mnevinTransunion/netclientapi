#Trustev .NET Libary
- If you are not familiar with Trustev, start with our [Developer Portal](http://www.trustev.com/developers).
- Check out our [API Documentation](http://www.trustev.com/developers#apioverview).
- If you would like to get some test keys to begin integrating please contact integrationteam@trustev.com

##Requirements
- .NET version 4.0 and later

##Installation
####NuGet
- TODO : Detail how to install the NuGet package here

####Others
- You could also download our solution, build it and simply include the .dll files as you need them.
- Our library can also be used as an example to inspire your own integration to the Trustev Platform.

## Usage
   The stripe API has been designed to allow users complete control over what information they are sending us while still ensuring that integration can be done a couple of simple steps

#### Simple Trustev Integration
This is simple version of the trustev integration. and involes 3 simple steps
```c#

// 1. Set-Up the Trustev Api Client with your user credentials
ApiClient.SetUp(userName, password, secret);


// 2. Create your case.
// You will need two bits of information for this setp
// 		SessionId : This is the SessionId that you have recieved from the trustev JavaScript 
//					and transfered server-side
// 		CaseNumber : This is a number that you use to uniquely identify this case. It must
//					 be unique.
Case kase = new Case(sessionId, caseNumber);

// Now add any further information you have. The more you give us, the more accurate 
// our decisions
kase.Customer = new Customer()
{
	FirstName = "John",
    LastName = "Doe",
}


// 3. Post this Case to the Trustev Api
Case returnCase = ApiClient.PostCase(kase);


// 4. You can now get your Decision from Trustev base on the case you have given us!
Decision decision = ApiClient.GetDecision(returnCase.Id);


// Now its up to you what you do with our decision
```

