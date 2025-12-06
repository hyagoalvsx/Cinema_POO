using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_POO.Models
{
    internal class Funcionario
    {
        public int Id_funcionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cargo { get; set; }
        public DateTime Data_admissao { get; set; }

        public decimal Salario { get; set; }


        public Funcionario(string _cpf)
        {
            SetAnalisarCpf(_cpf);
        }


        public Funcionario()
        {


        }

        public void SetAnalisarCpf(string _cpf)
        {
            ValidacaoCPF.ValidarCPF(_cpf);
            Cpf = _cpf;
        }

        public string GetCpf()
        {
            return Cpf;
        }

    }
}
