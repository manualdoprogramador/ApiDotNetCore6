using System;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOs.Person;
using MP.ApiDotNet6.Application.DTOs.Product;
using MP.ApiDotNet6.Application.DTOs.Purchase;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Mappings
{
	public class DomainToDtoMappings : Profile
	{
		public DomainToDtoMappings()
		{
			CreateMap<Person, PersonDTO>();
			CreateMap<Product, ProductDTO>();
			CreateMap<Purchase, PurchaseDetailDTO>()
			.ForMember(x => x.Product, opt => opt.Ignore())
			.ForMember(x => x.Person, opt => opt.Ignore())
			.ConstructUsing((model,context) =>
			{
				var dto = new PurchaseDetailDTO
				{
					Person = model.Person.Name,
					Id = model.Id,
					Product = model.Product.Name,
					Date = model.Date
				};
				return dto;
			});
		}
	}
}

