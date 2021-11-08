using System;

namespace cadastro_clientes
{
    public class Pessoafisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime datanascimento { get; set; }

        public override double PagarImposto(float rendimentos)
        {
            if (rendimentos <= 1500)
            {
                return 0;

            }else if (rendimentos > 1500 && rendimentos <=5000)
            {
                return (rendimentos )/100 * 3;

            }else 
            {
                return (rendimentos/100) * 5;
            }
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