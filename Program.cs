using System;

namespace cadastro_clientes
{
    class Program
    {
        static void Main(string[] args)
        {
            // <    Pessoafisica pf = new Pessoafisica();
            //     Pessoafisica npf = new Pessoafisica();
            //     Endereco end =  new Endereco();

            //     end.Logradouro = "rua B";
            //     end.numero = 666;
            //     end.complemento = "proximo A";
            //     end.enderecomercial = false;

            //     npf.endereco = end;
            //     npf.cpf = "111.111.111-22";
            //     npf.nome = "batatao";
            //     npf.datanascimento = new DateTime(2000,05,23);


            //     bool idadevalida = pf.Validardatanasc(npf.datanascimento);       

            //     if (idadevalida == true){
            //     Console.WriteLine($"Cadastro Aprovado");

            //     } else {
            //     Console.WriteLine($"Cadastro de menores de 18 anos, nao permitido!");
            //     }

            PessoaJuridica pj = new PessoaJuridica();
            PessoaJuridica npj = new PessoaJuridica();
            Endereco end = new Endereco();

            end.Logradouro = "rua cajá";
            end.numero = 64;
            end.complemento = "loja 2";
            end.enderecomercial = true;

            npj.endereco = end;
            npj.RazaoSocial = "xita moda LDTA";
            npj.cnpj = "12345678900001";

            if (pj.ValidarCNPJ(npj.cnpj))
            {

                Console.WriteLine($"Valido!");

            }
            else
            {
                Console.WriteLine($"INVALIDO!");

            }

        }
    }
}
