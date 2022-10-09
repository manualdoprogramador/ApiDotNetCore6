using MP.ApiDotNet6.Application.DTOs.PersonImage;
using MP.ApiDotNet6.Application.DTOs.PersonImage.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonImageRepository _personImageRepository;
        private readonly IPersonRepository _personRepository;

        public PersonImageService(IPersonImageRepository personImageRepository, IPersonRepository personRepository)
        {
            _personImageRepository = personImageRepository;
            _personRepository = personRepository;
        }

        public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var result = new PersonImageDTOValidator().Validate(personImageDTO);
            if(!result.IsValid)
                return ResultService.RequestError("Problema de validacao!",result);

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);
            if(person == null)
                return ResultService.Fail("Id pessoa não encontrado");
            
            var personImage = new PersonImage(person.Id,null,personImageDTO.Image);
            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem salva");
        }
    }
}