using chat;
using chat.domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IChatService, ChatService>();
builder.Services.AddSingleton<IChatRepository, ChatRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ILikeService, LikeService>();
builder.Services.AddSingleton<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

