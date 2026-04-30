using TelegramBotWeb.Models;

namespace TelegramBotWeb.Repositorys
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task<User?> GetByIdAsync(long userId);
        Task<User?> GetByTelegramIdAsync(long telegramId);
        Task<List<User>> UserGetAllAsync();
    }
}
