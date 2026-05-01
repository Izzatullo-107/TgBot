using Tg_Bott.BotDTOs;

namespace Tg_Bott.BotServices
{
    public class DogService : IDogService
    {
        public Task RegisterDogAsync(DogRegisterDTO dogDto, long chatId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DogGetAllDTO>> GetAllDogsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
