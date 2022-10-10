using System;
namespace BibliotecaTeca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public Livro livro { get; set; }

        public Usuario Usuario { get; set; }

        public Biblioteca Biblioteca { get; set; }
        
        public DateTime DataEntrega { get; set; }
    }
}
