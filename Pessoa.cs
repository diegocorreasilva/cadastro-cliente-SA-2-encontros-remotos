namespace cadastro_clientes
{
    public abstract class Pessoa
    {
        public string nome { get; set; }

        public Endereco endereco { get; set; }

        public float rendimentos{get; set;}

        public abstract double PagarImposto(float salario);
        
        
        
        
         
    }
}