using System;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(int id);
		Task<ICollection<Product>> GetProductsAsync();
		Task<Product> CreateAsync(Product product);
		Task EditAsync(Product product);
		Task DeleteAsync(Product product);
		Task<int> GetIdByCodErpAsync(string codErp);
	}
}

