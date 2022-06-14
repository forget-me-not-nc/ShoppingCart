using Microsoft.OpenApi.Models;
using ShoppingCart.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddSingleton<IBasketService, BasketService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(conn =>
    ConnectionMultiplexer.Connect(builder.Configuration["RedisConnectionString"])
);

builder.Services.AddControllers();

#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});
#endregion

var app = builder.Build();
#region Swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket v1");
    });

}
#endregion

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
