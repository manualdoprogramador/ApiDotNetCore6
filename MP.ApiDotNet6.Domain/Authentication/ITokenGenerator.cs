using System;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Authentication
{
	public interface ITokenGenerator
	{
		dynamic Generator(User user);
	}
}

