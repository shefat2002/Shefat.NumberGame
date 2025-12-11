using System.Numerics;
using Shefat.NumberGame.Hubs;
using Shefat.NumberGame.Services;

var builder = WebApplication.CreateBuilder(args);

var redisConn = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379";

builder.Services.AddSignalR()
    .AddStackExchangeRedis(redisConn, options => {
        options.Configuration.ChannelPrefix = "Number";
    });
//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
        });
});

//Add DI
builder.Services.AddScoped<INumberService, NumberService>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();


app.MapHub<NumberHub>("hubs/number");

app.Run();
