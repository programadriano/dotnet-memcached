using API.Service;
using Enyim.Caching.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [Memcached]
builder.Services.AddEnyimMemcached(memcachedClientOptions => {
    memcachedClientOptions.Servers.Add(new Server
    {
        Address = "127.0.0.1",
        Port = 11211
    });
});
#endregion

#region [DI]
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
builder.Services.AddTransient<CepService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

#region MyRegion
app.UseEnyimMemcached();
#endregion

app.MapControllers();

app.Run();
