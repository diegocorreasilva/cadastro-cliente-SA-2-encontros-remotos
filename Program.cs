using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace cadastro_clientes
{
    class Program
    {
        static void Main(string[] args)
        {
            //criar a lista aqui


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
|          1 - Add Pessoa Fisica         |
|          2 - visualizar PF             |
|          3 - remover  PF               | 
|                                        |
|          4 - Add Pessoa Juridica       |
|          5 - visualizar PJ             |
|          6 - remover PJ                |
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
         
                        

                        Console.WriteLine($"digite se Nome");
                        npf.nome = Console.ReadLine();
                        Console.WriteLine($"digite seu CPF");
                        npf.cpf = Console.ReadLine();

                        // endereço pessoa fisica inicio
                        Console.Write($"digite o logradouro ");                        
                        endpf.Logradouro = Console.ReadLine();                        
                        Console.Write($"digite o numero ");
                        endpf.numero = int.Parse(Console.ReadLine());
                        Console.Write($"digite o complemento ");
                        endpf.complemento = Console.ReadLine();
                        Console.WriteLine($"endereço comercial ? SIM ou NAO");
                        endpf.enderecomercial = bool.Parse(Console.ReadLine());
                                  
                        // fim endereco pessoa fisica
                        // Nova pessoa fisica
                        npf.endereco = endpf;                           

                        Console.WriteLine($"digite o valor de sua renda mensal");
                        npf.rendimentos = int.Parse(Console.ReadLine());

                        Console.WriteLine(@$"rua: {npf.endereco.Logradouro},{npf.endereco.numero}");
                        
                        // data de nascimento
                        Console.WriteLine($"digite o Dia de seu nascimento");
                        var Dia = int.Parse(Console.ReadLine());                        
                        Console.WriteLine($"digite o Mes de seu nascimento");
                        var Mes = int.Parse(Console.ReadLine());
                        Console.WriteLine($"digite o Ano de seu nascimento");
                        var Ano = int.Parse(Console.ReadLine());
                        // fim data nascimento

                        npf.datanascimento = new DateTime(Ano, Mes, Dia);
                        
                        bool idadevalida = pf.Validardatanasc(npf.datanascimento);

                        if (idadevalida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado");

                        }
                        else
                        {
                            Console.WriteLine($"Cadastro de menores de 18 anos, nao permitido!");
                        }
                        
                        Console.Write(@$"total de imposto a pagar R$ {pf.PagarImposto(npf.rendimentos)},00");
                       // Console.WriteLine(pf.PagarImposto(npf.rendimentos));

                        break;
                    
                    // visualiza a pessoa cadastrada

                    // case "2":
                    //         foreach(var item in listapf)
                    //         {
                                
                    //             Console.WriteLine($"{item.nome},{item.cpf},{item.endereco.numero}");

                    //         }
                    //     break;

                    // case "3":
                    //     Console.WriteLine($"cpf remover");
                    //     string CPFs = Console.ReadLine();
                    //     // listapf é a lista que tem que ser criada la em cima
                        
                    //     Pessoafisica pessoaprocurada = listapf.find(item => item.cpf == CPFs);
                    //     if (pessoaprocurada = null)
                    //     {
                    //        listapf.remove(pessoaprocurada); 
                    //        Console.WriteLine($"cadastro removido");
                           
                    //     }else
                    //     {
                    //         Console.WriteLine($"CPf nao encontrado");
                            
                    //     }
                        
                    //    break;


                    /// 
                    /// 
                    /// 
                
                  

                    case "4":
                        PessoaJuridica pj = new PessoaJuridica();
                        PessoaJuridica npj = new PessoaJuridica();
                        Endereco endpj = new Endereco();
                        
                        Console.WriteLine($"Razao Social:");                        
                        npj.RazaoSocial = Console.ReadLine();
                        Console.WriteLine($"digite seu CNPJ:");                        
                        npj.cnpj = Console.ReadLine();
                        Console.WriteLine($"informe seus rendimentos");                        
                        npj.rendimentos = float.Parse(Console.ReadLine());
                        Console.WriteLine($"logradouro");                        
                        endpj.Logradouro = Console.ReadLine();
                        Console.WriteLine($"numero");
                        endpj.numero = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Complemento");
                        endpj.complemento = Console.ReadLine();
                        Console.WriteLine($"endereço comercial ? SIM ou NAO");
                        endpj.enderecomercial = bool.Parse(Console.ReadLine());
                        
                        npj.endereco = endpj;
                        

                        if (pj.ValidarCNPJ(npj.cnpj))
                        {

                            Console.WriteLine($"CNPJ Valido!");

                        }
                        else
                        {
                            Console.WriteLine($"CNPJ INVALIDO!");

                        }
                        Console.Write(@$"total de imposto a pagar R$ {pj.PagarImposto(npj.rendimentos)},00");

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
