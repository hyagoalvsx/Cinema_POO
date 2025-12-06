
namespace Cinema_POO.Models
{
    public static class ValidacaoCPF
    {
        public static void ValidarCPF(string _cpf)
        {
            _cpf = _cpf.Replace(".", "").Replace("-", "");
            _cpf = _cpf.Trim();

            //primeiro digito verificador

            int soma1 = 0;
            int multiplicar1 = 10;
            int resto;
            int digito;

            if (_cpf.Length != 11)
            {
                throw new Exception("CPF tem que ter 11 digitos");
            }

            for (int i = 0; i < 9; i++)
            {
                soma1 += int.Parse(_cpf[i].ToString()) * multiplicar1;
                multiplicar1--;
            }

            resto = soma1 % 11; //calcular o resto da divisão

            if (resto < 2)
            {
                digito = 0;
            }

            else
            {
                digito = 11 - resto;
            }

            if (digito != int.Parse(_cpf[9].ToString()))
                throw new Exception("Primeiro digito está incorreto!");

            //segundo digito verificador

            int soma2 = 0;
            int multiplicar2 = 11;
            int resto2;
            int digito2;

            for (int i = 0; i < 10; i++)
            {

                soma2 += int.Parse(_cpf[i].ToString()) * multiplicar2;
                multiplicar2--;
            }
            resto2 = soma2 % 11; //calcular o resto da divisão

            if (resto2 < 2)
            {
                digito2 = 0;
            }

            else
            {
                digito2 = 11 - resto2;
            }

            if (digito2 != int.Parse(_cpf[10].ToString()))
                throw new Exception("Segundo digito está incorreto!");
        }
    }
}