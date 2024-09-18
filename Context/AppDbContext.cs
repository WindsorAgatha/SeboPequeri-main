using Microsoft.EntityFrameworkCore;
using SeboPequeri.Models;

namespace SeboPequeri.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

}