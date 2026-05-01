namespace TelegramBotWeb.BotDTOs
{
    public class UserRegisterDTO
    {
        public long TelegramId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
