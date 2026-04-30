using Supabase;
using Telegram.Bot;
using TelegramBotWeb.Repositorys;
using TelegramBotWeb.Interfaces;
using TelegramBotWeb.BotServices;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Konfiguratsiyalar ---
var url = builder.Configuration["SupabaseUrl"] ?? throw new ArgumentNullException("SupabaseUrl topilmadi!");
var key = builder.Configuration["SupabaseKey"] ?? throw new ArgumentNullException("SupabaseKey topilmadi!");
var botToken = builder.Configuration["BotToken"] ?? throw new ArgumentNullException("BotToken topilmadi!");

// --- 2. Supabase Client (Singleton tavsiya etiladi) ---
builder.Services.AddSingleton(_ => new Supabase.Client(url, key, new SupabaseOptions
{
    AutoConnectRealtime = false // Agar real-time kerak bo'lmasa
}));

// --- 3. Repository-larni ro'yxatdan o'tkazish ---
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDogRepository, DogRepository>();

// --- 4. Service-larni ro'yxatdan o'tkazish (SIZDA SHU QOLIB KETGAN) ---
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDogService, DogService>();

// --- 5. Telegram Bot Client ---
builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(botToken));

builder.Services.AddControllers();
// Swagger faqat builder tugashidan oldin bo'lishi kerak
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();