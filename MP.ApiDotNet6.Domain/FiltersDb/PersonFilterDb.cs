using System;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Domain.FiltersDb
{
	public class PersonFilterDb : PagedBaseRequest
	{
        public string? Name { get; set; }
    }
}

