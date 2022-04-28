using System;
using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Purchase.Validations
{
	public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
	{
		public PurchaseDTOValidator()
		{
			RuleFor(x => x.CodErp)
				.NotEmpty()
				.NotNull()
				.WithMessage("CodErp deve ser informado!");

			RuleFor(x => x.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Document deve ser informado!");

		}
	}
}

