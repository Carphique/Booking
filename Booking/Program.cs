using Booking.Data;
using Booking.Sources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка авторизации
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// Добавляем CORS ДО builder.Build()
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Для разработки разрешаем запросы с любых адресов
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Регистрация сервисов
builder.Services.AddScoped<HotelSource>();
builder.Services.AddScoped<BookingSource>();
builder.Services.AddScoped<RoomSource>();
builder.Services.AddScoped<UserSource>();
builder.Services.AddScoped<ReviewSource>();
builder.Services.AddScoped<FavoriteSource>();
builder.Services.AddScoped<AuthSource>();


// ================= ГРАНИЦА =================
var app = builder.Build();
// ===========================================


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// === МАГИЯ ЗДЕСЬ: Раздача фронтенда ===
app.UseDefaultFiles(); // Сервер будет искать index.html по умолчанию
app.UseStaticFiles();  // Сервер будет отдавать css, js и картинки из wwwroot
// =====================================

// UseCors должен идти ПЕРЕД UseAuthentication и UseAuthorization
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();