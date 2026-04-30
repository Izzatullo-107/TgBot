using TelegramBotWeb.BotDTOs;

namespace TelegramBotWeb.BotServices
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
