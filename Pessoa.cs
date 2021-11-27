using System.IO;

namespace cadastro_clientes
{
    public abstract class Pessoa
    {
        public string nome { get; set; }

        public Endereco endereco { get; set; }

        public float rendimentos{get; set;}

        public abstract double PagarImposto(float salario);
        
        public void VerificarArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];

            
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            
            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
        }
        
         
    }
}