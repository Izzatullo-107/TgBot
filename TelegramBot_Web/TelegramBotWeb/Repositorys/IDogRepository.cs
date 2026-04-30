using TelegramBotWeb.Models;

namespace TelegramBotWeb.Repositorys
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllAsync();
        Task<Dog?> GetByIdAsync(long dogId);
        Task CreateAsync(Dog dog);
    }
}
