using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Venda
    {
        public int Id_venda { get; set; }
        public string Forma_pagamento { get; set; }
        public decimal Valor_total { get; set; }
        public DateTime Data_hora_venda { get; set; }
        public int Id_cliente { get; set; }
        public int Id_funcionario { get; set; }
    }
}
