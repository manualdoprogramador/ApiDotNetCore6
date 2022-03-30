using System;
using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Person.Validations
{
	public class PersonDTOValidator : AbstractValidator<PersonDTO>
	{
		public PersonDTOValidator()
		{
			RuleFor(x => x.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Document deve ser informado!");

			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Name deve ser informado!");

			RuleFor(x => x.Phone)
				.NotEmpty()
				.NotNull()
				.WithMessage("Phone deve ser informado!");
		}
	}
}

