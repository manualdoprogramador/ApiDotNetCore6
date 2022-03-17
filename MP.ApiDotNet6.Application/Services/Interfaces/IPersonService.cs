using System;
using MP.ApiDotNet6.Application.DTOs.Person;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
		Task<ResultService<ICollection<PersonDTO>>> GetAsync();
		Task<ResultService<PersonDTO>> GetByIdAsync(int id);
	}
}

