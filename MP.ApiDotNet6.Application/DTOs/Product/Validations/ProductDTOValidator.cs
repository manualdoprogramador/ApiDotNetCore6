using System;
using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Product.Validations
{
	public class ProductDTOValidator : AbstractValidator<ProductDTO>
	{
		public ProductDTOValidator()
		{
			RuleFor(x => x.CodErp)
				.NotEmpty()
				.NotNull()
				.WithMessage("CodErp deve ser informado!");

			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Name deve ser informado!");

			RuleFor(x => x.Price)				
				.GreaterThan(0)
				.WithMessage("Price deve ser informado e maior que zero!");
		}
	}
}

