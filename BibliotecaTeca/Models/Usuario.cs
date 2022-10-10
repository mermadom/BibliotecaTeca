namespace BibliotecaTeca.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        public bool Administrador { get; set; } = false;
    }
}
