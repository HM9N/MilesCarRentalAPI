using MilesCarRentalApi.Context;
using MilesCarRentalApi.Context.MilesCarModels;
using MilesCarRentalApi.Services;
using MilesCarRentalApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext

builder.Services.AddSqlServer<MilesCarRentalDbContext>(builder.Configuration.GetConnectionString("Connection"));

// Service Layer
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IVehicleService,VehicleService>();
builder.Services.AddScoped<IRentalService, RentalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
