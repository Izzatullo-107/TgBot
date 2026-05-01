using Tg_Bott.BotDTOs;

namespace Tg_Bott.BotServices
{
    public interface IDogService
    {
        Task RegisterDogAsync(DogRegisterDTO dogDto, long chatId);
        Task<List<DogGetAllDTO>> GetAllDogsAsync();
    }
}
