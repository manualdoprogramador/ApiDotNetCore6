using System;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
	public interface IPurchaseRepository
	{
		Task<Purchase> GetByIdAsync(int id);
		Task<ICollection<Purchase>> GetAllAsync();
		Task<Purchase> CreateAsync(Purchase purchase);
		Task EditAsync(Purchase purchase);
		Task DeleteAsync(Purchase purchase);
		Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
		Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
	}
}

