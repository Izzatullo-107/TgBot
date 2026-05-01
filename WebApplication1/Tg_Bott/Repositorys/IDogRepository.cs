using Tg_Bott.Models;

namespace Tg_Bott.Repositorys
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllAsync();
        Task<Dog?> GetByIdAsync(long dogId);
        Task CreateAsync(Dog dog);
    }
}
