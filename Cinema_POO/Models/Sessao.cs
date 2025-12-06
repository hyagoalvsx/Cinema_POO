using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Sessao
    {
        public int Id_sessao { get; set; }
        public decimal Valor_ingresso { get; set; }
        public DateTime Data_horario_inicio { get; set; }
        public int Id_filme { get; set; }
        public int Id_sala { get; set; }
    }
}
