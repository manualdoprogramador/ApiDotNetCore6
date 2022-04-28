using System;
using MP.ApiDotNet6.Application.DTOs.Purchase;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
	public interface IPurchaseService
	{
		Task<ResultService<int>> CreateAsync(PurchaseDTO purchaseDTO);
	}
}

