using GerenciamentoDeChamados.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GerenciamentoDeChamados.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Chamado> Chamados { get; set; }
    public DbSet<Anexo> Anexos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}

