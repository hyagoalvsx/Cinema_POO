using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Item_Venda
    {
        public int Id_item { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco_unitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Id_produto { get; set; }
        public int Id_venda { get; set; }
    }
}
