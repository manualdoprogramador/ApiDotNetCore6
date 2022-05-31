using System;
namespace MP.ApiDotNet6.Domain.Repositories
{
	public class PagedBaseResponse<T>
	{
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }
}

