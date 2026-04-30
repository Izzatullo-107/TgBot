using TelegramBotWeb.BotDTOs;

namespace TelegramBotWeb.BotServices
{
    public interface IDogService
    {
        Task RegisterDogAsync(DogRegisterDTO dogDto, long chatId);
        Task<List<DogGetAllDTO>> GetAllDogsAsync();
    }
}
