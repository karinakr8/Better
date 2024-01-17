using Better.Middlewares;
using Better.Repositories;
using Better.Repositories.Interfaces;
using Better.Repositories.Utilities;
using Better.Services;
using Better.Services.Interfaces;
using Better.Services.Utilities;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IRepositoriesValidator, RepositoriesValidator>();
builder.Services.AddScoped<IServicesValidator, ServicesValidator>();
builder.Services.AddScoped<IBetRepository, BetRepository>();
builder.Services.AddScoped<IBetService, BetService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
