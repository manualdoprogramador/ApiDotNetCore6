using System;
using FluentValidation;
using MP.ApiDotNet6.Application.DTOs.Person;

namespace MP.ApiDotNet6.Application.DTOs.User.Validations
{
	public class UserDTOValidator : AbstractValidator<UserDTO>
	{
		public UserDTOValidator() 
		{
			RuleFor(x => x.Email)
				.NotEmpty()
				.NotNull()
				.WithMessage("Email deve ser informado!");

			RuleFor(x => x.Password)
				.NotEmpty()
				.NotNull()
				.WithMessage("Password deve ser informado!");
		}
	}
}

