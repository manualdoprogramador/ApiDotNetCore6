using System;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.DTOs
{
	public class PageRequestDTO<T> : PageBaseRequest
    {
        public T Filter { get; set; }
    }
}

