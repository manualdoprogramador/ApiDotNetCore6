using System;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOs.Person;
using MP.ApiDotNet6.Application.DTOs.Product;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Mappings
{
	public class DtoToDomainMappins : Profile
	{
		public DtoToDomainMappins()
		{
			CreateMap<PersonDTO, Person>();
			CreateMap<ProductDTO, Product>();
		}
	}
}

