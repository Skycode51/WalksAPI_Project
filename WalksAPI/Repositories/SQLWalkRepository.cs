using Microsoft.EntityFrameworkCore;
using WalksAPI.Data;
using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private  readonly WalksDbContext dbContext;

        public SQLWalkRepository(WalksDbContext dbContext) 
        { 
               this.dbContext = dbContext;
        
        }
        public async Task<Walks> CreateAsync(Walks walks)
        {
            await  dbContext.walks.AddAsync(walks);
            await  dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<List<Walks>> GetAllAsync()
        {
            return  await dbContext.walks.Include("Difficulty").Include("Regions").ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(Guid id)
        {
           return  await dbContext.walks.Include("Difficulty")
                                        .Include("Regions")
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks?> UpdateAsync(Guid id, Walks walks)
        {
             var existingWalk = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
               return null;

            }

            // Update the existing walk's properties
            existingWalk.Name = walks.Name;
            existingWalk.Description = walks.Description;
            existingWalk.LengthInKm = walks.LengthInKm;
            existingWalk.WalkImageUrl = walks.WalkImageUrl;
            existingWalk.DifficultyId = walks.DifficultyId;
            existingWalk.RegionId = walks.RegionId;

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walks?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            dbContext.walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
