using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class PersonImageRepository : IPersonImageRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PersonImage> CreateAsync(PersonImage personImage)
        {
            _db.Add(personImage);
            await _db.SaveChangesAsync();
            return personImage;
        }

        public async Task EditAsync(PersonImage personImage)
        {
            _db.Update(personImage);
            await _db.SaveChangesAsync();
        }

        public async Task<PersonImage?> GetByIdAsync(int id)
        {
            return await _db.PersonImages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId)
        {
            return await _db.PersonImages.AsNoTracking().Where(x => x.PersonId == personId).ToListAsync();
        }
    }
}