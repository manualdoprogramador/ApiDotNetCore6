using System;
using MP.ApiDotNet6.Application.DTOs.Product;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
	public interface IProductService
	{
		Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
	}
}

