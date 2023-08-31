using CrudCautus.Data;
using CrudCautus.Repositorios;
using CrudCautus.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a integra��o do SQL Server com a App 'CrudCautus'
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<FuncionarioDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

// Inje��o de Independencia = Quando a Interface for chamada, o FornecedorRepositorio ser� instanciado.
builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();

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
