using BibliotecaTeca.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaTeca.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }

    }
}
