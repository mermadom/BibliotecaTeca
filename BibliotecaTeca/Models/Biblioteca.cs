namespace BibliotecaTeca.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Livro> Livros { get; set; }

        public List<Emprestimo> Emprestimos { get; set; }
    }
}
