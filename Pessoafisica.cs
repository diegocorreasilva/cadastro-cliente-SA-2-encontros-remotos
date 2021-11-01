using System;

namespace cadastro_clientes
{
    public class Pessoafisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime datanascimento { get; set; }

        public override void PagarImposto(float salario)
        {

        }

        public bool Validardatanasc(DateTime datanasc)
        {
            DateTime datatual = DateTime.Today;

            double anos = (datatual - datanasc).TotalDays / 365;

            if (anos >= 18)
            {

                return true;
            }

            return false;
        }




    }
}