using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Trustev.Api.Client.Entities
{
	public class TokenRequest
	{
	public string UserName { get; set; }
	public string Timestamp  { get; set; }
	public string PasswordHash { get; set; }
	public string UserNameHash { get; set; }
	}
}
