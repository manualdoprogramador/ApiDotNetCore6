using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Infra.Data.Context
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PagedBaseRequest request)
            where TResponse : PagedBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Ceiling((double)count / request.PageSize);
            response.TotalRegisters = count;
            if (string.IsNullOrEmpty(request.OrderByProperty))
                response.Data = await query.ToListAsync();
            else
            {                
                response.Data = query.OrderByDynamic(request.OrderByProperty)
                    .Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();
            }

            return response;
        }

        public static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }
}

