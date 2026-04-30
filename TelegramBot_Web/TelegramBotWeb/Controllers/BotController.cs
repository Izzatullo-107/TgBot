using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotWeb.BotDTOs;
using TelegramBotWeb.BotServices;
using TelegramBotWeb.Interfaces;

namespace TelegramBotWeb.Controllers
{
    [ApiController]
    [Route("api/bot")] // Webhook manzili: https://sizning-saytingiz.com/api/bot
    public class BotController : ControllerBase
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IUserService _userService;
        private readonly IDogService _dogService;

        public BotController(ITelegramBotClient botClient, IUserService userService, IDogService dogService)
        {
            _botClient = botClient;
            _userService = userService;
            _dogService = dogService;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            if (update.Message is not { } message) return Ok();
            if (message.Text is not { } messageText) return Ok();

            long chatId = message.Chat.Id;

            // 1. Foydalanuvchini tekshirish yoki ro'yxatdan o'tkazish
            var user = await _userService.GetUserByChatIdAsync(chatId);
            if (user == null)
            {
                await _userService.RegisterUserAsync(new UserRegisterDTO
                {
                    FullName = message.From?.FirstName + " " + message.From?.LastName,
                    Username = message.From?.Username,
                    PhoneNumber = "" // Keyinchalik so'rash mumkin
                }, chatId);
            }

            // 2. Buyruqlarni qayta ishlash
            switch (messageText)
            {
                case "/start":
                    await _botClient.SendMessage(chatId, "Xush kelibsiz! Itlar haqida ma'lumot olish uchun /dogs buyrug'ini bosing.");
                    break;

                case "/dogs":
                    var dogs = await _dogService.GetAllDogsAsync(); // IDogService-da bor deb hisoblaymiz
                    foreach (var dog in dogs)
                    {
                        await _botClient.SendMessage(chatId, $"Zoti: {dog.Name}\nTavsif: {dog.Description}");
                    }
                    break;

                default:
                    await _botClient.SendMessage(chatId, "Noma'lum buyruq. Iltimos, menyudan foydalaning.");
                    break;
            }

            return Ok();
        }
    }
}