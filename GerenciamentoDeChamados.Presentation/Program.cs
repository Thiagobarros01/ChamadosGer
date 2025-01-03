using GerenciamentoDeChamados.Application.Interfaces;
using GerenciamentoDeChamados.Application.Services;
using GerenciamentoDeChamados.Domain.Entities;
using GerenciamentoDeChamados.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//DI
builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IChamadoService, ChamadoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Teste inicial para adicionar um usuário
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!dbContext.Usuarios.Any())
    {
        dbContext.Usuarios.Add(new Usuario
        {
            Nome = "Thiago",
            Email = "thiago@example.com",
            Senha = "senha123" // Apenas para testes, depois vamos usar criptografia!
        });
        dbContext.SaveChanges();
        Console.WriteLine("Usuário inicial criado com sucesso!");
    }
}

app.Run();


