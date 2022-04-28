using System;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOs.Purchase;
using MP.ApiDotNet6.Application.DTOs.Purchase.Validations;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
	public class PurchaseService : IPurchaseService
	{
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        public PurchaseService(IMapper mapper, IPurchaseRepository purchaseRepository, IProductRepository productRepository, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _personRepository = personRepository;
        }

        public async Task<ResultService<int>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if(purchaseDTO == null)
                return ResultService.Fail<int>("Objeto deve ser informado");

            var result = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!result.IsValid)
                return ResultService.RequestError<int>("Problema de validacao!", result);

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);            
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);                            
            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            return ResultService.Ok<int>(data.Id);
        }
    }
}

