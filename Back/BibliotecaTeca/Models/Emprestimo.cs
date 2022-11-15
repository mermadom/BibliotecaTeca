namespace BibliotecaTeca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public Livro livro { get; set; }

        public Usuario Usuario { get; set; }
    }
}
