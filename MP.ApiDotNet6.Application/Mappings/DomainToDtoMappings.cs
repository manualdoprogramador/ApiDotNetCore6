using System;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOs.Person;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Mappings
{
	public class DomainToDtoMappings : Profile
	{
		public DomainToDtoMappings()
		{
			CreateMap<Person, PersonDTO>();
		}
	}
}

