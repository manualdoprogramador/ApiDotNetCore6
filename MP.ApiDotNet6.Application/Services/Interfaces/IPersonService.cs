using System;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.DTOs.Person;
using MP.ApiDotNet6.Domain.FiltersDb;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
		Task<ResultService<ICollection<PersonDTO>>> GetAsync();
		Task<ResultService<PersonDTO>> GetByIdAsync(int id);
		Task<ResultService> UpdateAsync(PersonDTO personDTO);
		Task<ResultService> RemoveAsync(int id);
		Task<ResultService<PagedResponseDTO<PersonDTO>>> GetPaged(PersonFilterDb pageRequestDTO);
	}
}

