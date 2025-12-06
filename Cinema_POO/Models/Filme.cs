using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Filme
    {
        public int Id_filme { get; set; }
        public int Duracao_minutos { get; set; } // duração em minutos
        public string Classificacao_indicativa { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Id_genero { get; set; }
    }
}
