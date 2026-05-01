using Tg_Bott.BotDTOs;

namespace Tg_Bott.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegisterDTO userDto, long chatId);
        Task<UserRegisterDTO?> GetUserByChatIdAsync(long chatId);
        Task<UserRegisterDTO?> GetUserByIdAsync(long userId);
        Task<bool> UpdateUserAsync(long chatId, UserUpdateDTO updateDto);
        Task<bool> DeleteUserAsync(long? telegramId, long? userId);
        Task<List<UserGetAllDTO>> GetAllUsersAsync();
       
    }
}