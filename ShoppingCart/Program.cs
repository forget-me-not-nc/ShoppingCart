using ShoppingCart.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddSingleton<IBasketService, BasketService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(conn =>
    ConnectionMultiplexer.Connect(builder.Configuration["RedisConnectionString"])
);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
