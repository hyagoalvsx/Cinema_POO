using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Ingresso
    {
        public int Id_ingresso { get; set; }
        public string Tipo_ingresso { get; set; }
        public decimal Valor_pago { get; set; }
        public int Id_venda { get; set; }
        public int Id_sessao { get; set; }
    }
}
