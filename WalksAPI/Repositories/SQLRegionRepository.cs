using Microsoft.EntityFrameworkCore;
using WalksAPI.Data;
using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly WalksDbContext dbContext;

        // Dependency Injection using Constructor
        public SQLRegionRepository(WalksDbContext dbContext) 
        {
            this.dbContext = dbContext;
        
        }
        // Create Method Implementation
        public async Task<Regions> CreateAsync(Regions region)
        {
            await dbContext.regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
          // Delete Method Implementation
        public async Task<Regions?> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) 
            {
                return null;
            }
             dbContext.regions.Remove(existingRegion);
             await dbContext.SaveChangesAsync();
             return existingRegion;

        }


        //GetAll Method Implementation
        public async Task<List<Regions>> GetAllAsync()
        {
           return await dbContext.regions.ToListAsync();
        }

        // GetById Method Implementation
        public async Task<Regions?> GetByIdAsync(Guid id)
        {
           return await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Update Method Implementation
        public async Task<Regions?> UpdateAsync(Guid id, Regions region)
        {
            var existingRegion =  await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
               return null;
            }
             existingRegion.Code = region.Code;
             existingRegion.Name = region.Name;
             existingRegion.RegionImageUrl = region.RegionImageUrl;
           
             await dbContext.SaveChangesAsync();
             return existingRegion;
        }

    }
}
