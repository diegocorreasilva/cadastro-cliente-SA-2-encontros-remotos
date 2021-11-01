using System;
using System.IO;
using System.Threading;


namespace cadastro_clientes
{
    class Program
    {

        static void Main(string[] args)

        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@$"
==================================
|            BEM VINDOS          |
| Sistema de cadastro de pessoas |
==================================
");
            Console.ResetColor();
            Thread.Sleep(1000);

            statusLoading("Iniciando");

            Console.Clear();
            string opçao;
            do
            {
                Console.WriteLine(@$"
==========================================
|           Escolha uma opçao            |
|----------------------------------------|
|          1 - Pessoa Fisica             |
|          2 - Pessoa Juridica           |
|                                        |
|          0 - Sair                      |
==========================================
");
                opçao = Console.ReadLine();

                switch (opçao)
                {
                    case "1":
                        Pessoafisica pf = new Pessoafisica();
                        Pessoafisica npf = new Pessoafisica();
                        Endereco endpf = new Endereco();
                        
                        
                        endpf.Logradouro = "rua X";
                        endpf.complemento = "casa 2";
                        endpf.enderecomercial = false;

                        npf.endereco = endpf; 
                        npf.cpf = "123.456.789-01";
                        npf.nome = "chico";
                        npf.datanascimento = new DateTime(2000,06,23);
                        
                        bool idadevalida = pf.Validardatanasc(npf.datanascimento);

                        if (idadevalida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado");

                        }
                        else
                        {
                            Console.WriteLine($"Cadastro de menores de 18 anos, nao permitido!");
                        }
                        break;

                    case "2":
                        PessoaJuridica pj = new PessoaJuridica();
                        PessoaJuridica npj = new PessoaJuridica();
                        Endereco endpj = new Endereco();

                        endpj.Logradouro = "rua cajá";
                        endpj.numero = 64;
                        endpj.complemento = "loja 2";
                        endpj.enderecomercial = true;

                        npj.endereco = endpj;
                        npj.RazaoSocial = "xita moda LDTA";
                        npj.cnpj = "12345678900001";

                        if (pj.ValidarCNPJ(npj.cnpj))
                        {

                            Console.WriteLine($"CNPJ Valido!");

                        }
                        else
                        {
                            Console.WriteLine($"CNPJ INVALIDO!");

                        }
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine($"Obrigado por utilizar nosso Sistema!");

                        statusLoading("Finalizando");

                        break;
                    default:
                        Console.ResetColor();
                        Console.WriteLine($"Opção Inválida. por favor digite uma opçao Valida!");
                        break;
                }

            } while (opçao != "0");

        }

        static void statusLoading(string Loading)
        {

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write(Loading);
            Thread.Sleep(0);

            for (var i = 0; i < 10; i++)
            {
                Console.Write($".");
                Thread.Sleep(100);
            }
            Console.ResetColor();

        }
    }
}
