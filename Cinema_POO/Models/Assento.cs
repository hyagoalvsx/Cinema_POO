using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Assento
    {
        public int Id_assento { get; set; }
        public string Poltrona { get; set; }
        public string Status_poltrona { get; set; }
        public int Id_sala { get; set; }
    }
}
