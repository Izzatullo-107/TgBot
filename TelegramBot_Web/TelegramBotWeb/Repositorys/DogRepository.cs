using TelegramBotWeb.Models;

namespace TelegramBotWeb.Repositorys
{
    public class DogRepository : IDogRepository
    {
        private readonly Supabase.Client _supabase;

        public DogRepository(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<Dog>> GetAllAsync()
        {
            var result = await _supabase.From<Dog>().Get();
            return result.Models;
        }

        public async Task CreateAsync(Dog dog)
        {
            await _supabase.From<Dog>().Insert(dog);
        }

        public Task<Dog?> GetByIdAsync(long dogId)
        {
            throw new NotImplementedException();
        }
    }
}