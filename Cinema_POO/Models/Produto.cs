using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Produto
    {
        public int Id_produto { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quant_estoque { get; set; }
        public decimal Preco_unitario { get; set; }
    }
}
