using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet7.Test.Application.Context
{
    public class TestDatabaseInMemory
    {
        public static ApplicationDbContext GetDatabase()
        {
            var name = $"{Guid.NewGuid()}_{Guid.NewGuid()}";
            return GetDatabase(name);
        }

        private static ApplicationDbContext GetDatabase(string name)
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase($"{name}_{Guid.NewGuid()}").Options;

            return new ApplicationDbContext(inMemoryOptions);
        }
    }
}