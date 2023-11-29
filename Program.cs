using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sklepInternetowy.Dane;
using sklepInternetowy.Interface;
using sklepInternetowy.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUzytkownikRepository, UzytkownikRepository>();

builder.Services.AddScoped<ITransakcjaRepository, TransakcjaRepository>();

builder.Services.AddScoped<IPrzedmiotRepository, PrzedmiotRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("sklepInternetowy");
builder.Services.AddDbContext<DaneContekst>(x => x.UseSqlServer(connectionString));
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
