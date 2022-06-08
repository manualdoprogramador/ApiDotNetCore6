using System;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		Task BeginTransaction();
        Task Commit();
        Task Rollback();
	}
}
