﻿namespace BibliotecaTeca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Descricao { get; set; }

        public bool Emprestado { get; set; }

        public Biblioteca Biblioteca { get; set; }
    }
}
