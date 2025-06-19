using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pam.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Pam.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> TB_USUARIO { get; set; }
        public DbSet<Sugestao> TB_SUGESTAO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIO");

            modelBuilder.Entity<Sugestao>().ToTable("TB_SUGESTAO");

            modelBuilder.Entity<Sugestao>()
                .HasOne(s => s.Usuario)
                .WithMany(u => u.Sugestoes)
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "João Silva", Senha = "senha123", Telefone = "11999999999" },
                new Usuario { Id = 2, Nome = "Maria Oliveira", Senha = "senha456", Telefone = "11988888888" },
                new Usuario { Id = 3, Nome = "Carlos Souza", Senha = "senha789", Telefone = "11977777777" }
            );

            modelBuilder.Entity<Sugestao>().HasData(
                new Sugestao { Id = 1, Text = "Pedir Ifood", UsuarioId = 1 },
                new Sugestao { Id = 2, Text = "Ajuda no Uber", UsuarioId = 1 },
                new Sugestao { Id = 3, Text = "Logar no email", UsuarioId = 2 },
                new Sugestao { Id = 4, Text = "Mandar mensagem no Whatsapp", UsuarioId = 3 },
                new Sugestao { Id = 5, Text = "Navegar pelo Facebook", UsuarioId = 2 }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveColumnType("Varchar")
                .HaveMaxLength(200);
        }

        
    }
}
