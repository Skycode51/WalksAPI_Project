using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public interface IWalkRepository
    {

        // Defination
        Task<Walks>CreateAsync(Walks walks);
        Task<List<Walks>> GetAllAsync();
        Task<Walks?> GetByIdAsync(Guid id);
        Task<Walks?> UpdateAsync(Guid id,Walks walks);
        Task<Walks?> DeleteAsync(Guid id);
    }
}
