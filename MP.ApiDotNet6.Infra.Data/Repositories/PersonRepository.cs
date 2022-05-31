using System;
using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
	public class PersonRepository : IPersonRepository
	{

        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person); 
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person); 
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PageBaseRequest request)
        {
            var people = _db.People.AsQueryable();
            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>,Person>(people, request);
        }
    }
}

