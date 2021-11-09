namespace cadastro_clientes
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string RazaoSocial { get; set; }

    
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


            
        
    }
}