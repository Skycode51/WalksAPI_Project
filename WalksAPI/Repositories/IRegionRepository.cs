using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public interface IRegionRepository
    {
        // 5 Methods implemated in the repository

        //GellAll Method defination
        Task<List<Regions>> GetAllAsync();

        // GetById Method defination
        Task<Regions?> GetByIdAsync(Guid id);

        // Create Method defination
        Task<Regions> CreateAsync(Regions region);

        // Update Method defination
        Task<Regions?> UpdateAsync(Guid id,Regions region);

        // Delete Method defination
        Task<Regions?> DeleteAsync(Guid id);
    }
}
