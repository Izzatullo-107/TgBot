using TelegramBotWeb.Models;     // User modeli qayerda bo'lsa o'sha namespace

namespace TelegramBotWeb.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly Supabase.Client _supabase;

        public UserRepository(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<User?> GetByIdAsync(long userId)
        {
            var result = await _supabase.From<User>()
                .Where(u => u.UserId == userId)
                .Get();
            return result.Model;
        }

        public async Task CreateAsync(User user)
        {
            await _supabase.From<User>().Insert(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _supabase.From<User>().Update(user);
        }

        public async Task DeleteAsync(long userId)
        {
            await _supabase.From<User>().Where(u => u.UserId == userId).Delete();
        }

        public async Task<User?> GetByTelegramIdAsync(long telegramId)
        {
            var result = await _supabase
        .From<User>()
        .Where(x => x.TelegramId == telegramId)
        .Get();

            return result.Model;
        }

        public async Task<List<User>> UserGetAllAsync()
        {
            var result = await _supabase.From<User>().Get();
            return result.Models;
        }
    }
}
