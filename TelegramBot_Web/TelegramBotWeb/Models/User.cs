using Postgrest.Attributes;
using Postgrest.Models; // BU JUDA MUHIM

namespace TelegramBotWeb.Models
{
    [Table("Users")] // Supabase'dagi jadval nomi
    public class User : BaseModel // ': BaseModel' qo'shilishi shart
    {
        [PrimaryKey("UserId", false)]
        public long UserId { get; set; }

        [Column("TelegramId")] // Telegram beradigan ChatId
        public long TelegramId { get; set; }

        [Column("FullName")]
        public string? FullName { get; set; }

        [Column("Username")]
        public string? Username { get; set; }

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("Role")]
        public string Role { get; set; } = "user"; // Default qiymat "User" bo'ladi

        [Column("IsBlocked")]
        public bool IsBlocked { get; set; } = false;

        [Column("RegisterTime")]
        public DateTime RegisterTime { get; set; }
    }
}