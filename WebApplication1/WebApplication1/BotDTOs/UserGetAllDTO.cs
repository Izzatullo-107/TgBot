using Postgrest.Attributes;

namespace TelegramBotWeb.BotDTOs
{
    public class UserGetAllDTO
    {
        public long UserId { get; set; }

        public string? FullName { get; set; }

        public string? Username { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Role { get; set; }


        public DateTime RegisterTime { get; set; }
    }
}
