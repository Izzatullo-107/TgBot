using TelegramBotWeb.BotDTOs;
using TelegramBotWeb.Interfaces;
using TelegramBotWeb.Models;
using TelegramBotWeb.Repositorys;

namespace TelegramBotWeb.BotServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterUserAsync(UserRegisterDTO userDto, long chatId)
        {
            // 1. DTO dan Modelga o'tkazish
            var newUser = new User
            {
                TelegramId = chatId, // Xabardan kelgan ChatId
                FullName = userDto.FullName,
                Username = userDto.Username,
                PhoneNumber = userDto.PhoneNumber,
                Role = "user", // Default rol
                RegisterTime = DateTime.UtcNow // Hozirgi vaqt
            };

            // 2. Repository orqali bazaga saqlash
            await _userRepository.CreateAsync(newUser);
        }

        public async Task<UserRegisterDTO?> GetUserByChatIdAsync(long chatId)
        {
            // Repository-dan modelni TelegramId orqali olamiz
            var user = await _userRepository.GetByTelegramIdAsync(chatId);

            if (user == null) return null;

            // Modelni DTO-ga o'giramiz
            return new UserRegisterDTO
            {
                FullName = user.FullName,
                Username = user.Username,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task<UserRegisterDTO?> GetUserByIdAsync(long userId)
        {
            // Repository-dan modelni UserId orqali olamiz
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null) return null;

            // Modelni DTO-ga o'giramiz
            return new UserRegisterDTO
            {
                FullName = user.FullName,
                Username = user.Username,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task<bool> UpdateUserAsync(long chatId, UserUpdateDTO updateDto)
        {
            // Avval foydalanuvchini bazadan topamiz
            var user = await _userRepository.GetByTelegramIdAsync(chatId);

            if (user != null)
            {
                // Faqat kerakli maydonlarni yangilaymiz
                user.FullName = updateDto.FullName;
                user.Username = updateDto.Username;
                user.PhoneNumber = updateDto.PhoneNumber;

                await _userRepository.UpdateAsync(user);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(long? telegramId,long? userId)
        {
           
            User? user = null;

            if (userId != null)
                user = await _userRepository.GetByIdAsync(userId.Value);
            else if (telegramId != null)
                user = await _userRepository.GetByTelegramIdAsync(telegramId.Value);

            if (user != null)
            {
                user.IsBlocked = true; // Mavjud ob'ektning faqat bir maydonini o'zgartiramiz
                await _userRepository.UpdateAsync(user);
                return true;
            }
            return false;

        }

        public async Task<List<UserGetAllDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.UserGetAllAsync();
             
            var activeUsers = users.Where(u => !u.IsBlocked).ToList();

            return activeUsers.Select(u => new UserGetAllDTO
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Username = u.Username,
                PhoneNumber = u.PhoneNumber,
                Role = u.Role,
                RegisterTime = u.RegisterTime
            }).ToList();
        }
    }
}
