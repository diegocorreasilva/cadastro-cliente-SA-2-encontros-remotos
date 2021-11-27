using System;
using System.Collections.Generic;
using System.IO;

namespace cadastro_clientes
{
    public class Pessoafisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime datanascimento { get; set; }

         public string caminho { get; private set; } = "Database/PessoaFisica.csv";
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


        public string PrepararLinhasCsv(Pessoafisica pf)
        {
            return $"{pf.nome};{pf.cpf}";
        }
         public void Inserir(Pessoafisica pf)
        {
            string[] linhas = { PrepararLinhasCsv(pf) };

            File.AppendAllLines(caminho, linhas);
        }

        public List<Pessoafisica> Ler()
        {
            
            List<Pessoafisica> listaPf = new List<Pessoafisica>();

            string[] linhas = File.ReadAllLines(caminho);
            
            foreach (var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                Pessoafisica cadaPf = new Pessoafisica();

                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];
                

                listaPf.Add(cadaPf);
            }
            return listaPf;
        }

    }
}