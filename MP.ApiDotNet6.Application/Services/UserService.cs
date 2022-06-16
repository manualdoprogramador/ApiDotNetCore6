using System;
using MP.ApiDotNet6.Application.DTOs.User;
using MP.ApiDotNet6.Application.DTOs.User.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado");

            var result = new UserDTOValidator().Validate(userDTO);
            if (!result.IsValid)
                return ResultService.RequestError<dynamic>("Problema de validacao!", result);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            if(user == null)
                return ResultService.Fail<dynamic>("Usuário ou senha não encontrado!");

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}

