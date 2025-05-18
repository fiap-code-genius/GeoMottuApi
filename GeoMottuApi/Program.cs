using GeoMottuApi.Application.Interfaces;
using GeoMottuApi.Application.Services;
using GeoMottuApi.Domain.Interfaces;
using GeoMottuApi.Infrastructure.Data.AppData;
using GeoMottuApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x =>
{
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IFilialRepository, FilialRepository>();
builder.Services.AddTransient<IMotoRepository, MotoRepository>();
builder.Services.AddTransient<IPatioRepository, PatioRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddTransient<IFilialApplicationService, FilialApplicationService>();
builder.Services.AddTransient<IMotoApplicationService, MotoApplicationService>();
builder.Services.AddTransient<IPatioApplicationService, PatioApplicationService>();
builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();




// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Urls.Clear();
app.Urls.Add("http://0.0.0.0:80");


app.Run();
