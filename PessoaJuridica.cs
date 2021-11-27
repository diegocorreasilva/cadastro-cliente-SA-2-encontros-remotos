using System.Collections.Generic;
using System.IO;
namespace cadastro_clientes
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";
        public override double PagarImposto(float rendimentos)
        {
            if (rendimentos <= 5000)
            {
                
                return (rendimentos/100) * 6;

            }else if (rendimentos > 5000 && rendimentos <=10000)
            {
                return (rendimentos )/100 * 8;

            }else 
            {
                return (rendimentos/100) * 5;
            }
        }        
        
        
        public bool ValidarCNPJ (string cnpj){
            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 4)== "0001"){
                
                return(true);
            }
            return false;
        
        
        }
        public string PrepararLinhasCsv(PessoaJuridica pj)
        {
            return $"{pj.nome};{pj.cnpj};{pj.RazaoSocial}";
        }
         public void Inserir(PessoaJuridica pj)
        {
            string[] linhas = { PrepararLinhasCsv(pj) };

            File.AppendAllLines(caminho, linhas);
        }

        public List<PessoaJuridica> Ler()
        {
            
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);
            
            foreach (var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.RazaoSocial = atributos[2];

                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
            
        
    }
}