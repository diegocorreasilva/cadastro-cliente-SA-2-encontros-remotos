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
            List<Pessoafisica> listpf = new List<Pessoafisica>();
            List<PessoaJuridica> listpj = new List<PessoaJuridica>();

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
|          2 - listar Pessoa Fisica      |
|          3 - remover  PF               | 
|                                        |
|          4 - Add Pessoa Juridica       |
|          5 - Listar Pessea Juridica    |
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

                        
                        Console.Write($"digite o logradouro ");                        
                        endpf.Logradouro = Console.ReadLine();                        
                        Console.Write($"digite o numero ");
                        endpf.numero = int.Parse(Console.ReadLine());
                        Console.Write($"digite o complemento ");
                        endpf.complemento = Console.ReadLine();
                        Console.WriteLine($"endereço comercial ? SIM ou NAO");
                        string endcomercial = Console.ReadLine();
                        
                        if (endcomercial == "sim"){
                             endpf.enderecomercial = true;
                        }  else
                        {
                             endpf.enderecomercial = false;
                        }       
                        
                        npf.endereco = endpf;                           

                        Console.WriteLine($"digite o valor de sua renda mensal");
                        npf.rendimentos = int.Parse(Console.ReadLine());

                        //Console.WriteLine(@$"rua: {npf.endereco.Logradouro},{npf.endereco.numero}");
                        
                        
                        Console.WriteLine($"digite o Dia de seu nascimento");
                        var Dia = int.Parse(Console.ReadLine());                        
                        Console.WriteLine($"digite o Mes de seu nascimento");
                        var Mes = int.Parse(Console.ReadLine());
                        Console.WriteLine($"digite o Ano de seu nascimento");
                        var Ano = int.Parse(Console.ReadLine());
                        
                        npf.datanascimento = new DateTime(Ano, Mes, Dia);
                        
                        bool idadevalida = pf.Validardatanasc(npf.datanascimento);

                        if (idadevalida == true)
                        {
                            listpf.Add(npf);
                            Console.WriteLine(@$"total de imposto a pagar R$ {pf.PagarImposto(npf.rendimentos)},00");
                            Console.WriteLine($"Cadastro Aprovado");
                            
                        }
                        else
                        {
                            Console.WriteLine($"Cadastro de menores de 18 anos, nao permitido!");
                        }

                        // using (StreamWriter sw = new StreamWriter($"{npf.nome}.txt"))
                        // {
                        //     sw.Write($"{npf.nome} | {npf.cpf}");
                        // }

                        // //Para ler o arquivo.txt

                        // using (StreamReader sr = new StreamReader($"{npf.nome}.txt"))
                        // {
                        //     string linha;

                            
                        //     while ((linha = sr.ReadLine()) != null)
                        //     {
                        //         Console.WriteLine($"{linha}");
                        //     }
                        // }

                        pf.VerificarArquivo(pf.caminho);
                        pf.Inserir(npf);

                        break;
                    
                    // Listar Pessoa fisica
                    case "2":                        
                            foreach(Pessoafisica item in listpf)
                            {
                                
                                Console.WriteLine($"{item.nome}, { item.cpf}");

                            }
                        break;

                    // remover pessoa fisica
                    case "3":
                        Console.WriteLine($"cpf a remover");
                        string CPFs = Console.ReadLine();                      
                        Pessoafisica pessoaprocurada = listpf.Find(item => item.cpf == CPFs);
                        if (pessoaprocurada == null)
                        {

                           Console.WriteLine($"CPf nao encontrado");

                        }else
                        {
                           listpf.Remove(pessoaprocurada); 
                           Console.WriteLine($"cadastro removido");                            
                        }
                        
                       break;                                       
                  

                    case "4":
                        PessoaJuridica pj = new PessoaJuridica();
                        PessoaJuridica npj = new PessoaJuridica();
                        Endereco endpj = new Endereco();

                        Console.WriteLine("digite seu nome: ");
                        npj.nome  = Console.ReadLine();

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
                        string Endcomercial = Console.ReadLine();                        
                        if (Endcomercial == "sim"){

                             endpj.enderecomercial = true;

                        }  else
                        {
                             endpj.enderecomercial = false;
                        }       
                                            
                        npj.endereco = endpj;
                        

                        if (pj.ValidarCNPJ(npj.cnpj))
                        {

                            Console.WriteLine($"CNPJ Valido!");
                            Console.Write(@$"total de imposto a pagar R$ {pj.PagarImposto(npj.rendimentos)},00");
                            listpj.Add(npj);
                            Console.WriteLine($"cadastro Aprovado!!!");
                            
                        }
                        else
                        {
                            Console.WriteLine($"CNPJ INVALIDO!");

                        }

                        // // criar arquivo txt com o nome de usuario cadastrado
                        // using (StreamWriter sw = new StreamWriter($"{npj.nome}.txt"))
                        // {
                        //     sw.Write($"{npj.nome} | {npj.cnpj}");
                        // }

                        // //Para ler o arquivo.txt

                        // using (StreamReader sr = new StreamReader($"{npj.nome}.txt"))
                        // {
                        //     string linha;

                            
                        //     while ((linha = sr.ReadLine()) != null)
                        //     {
                        //         Console.WriteLine($"{linha}");
                        //     }
                        // }


                        
                        pj.VerificarArquivo(pj.caminho);
                        pj.Inserir(npj);

                        if (pj.Ler().Count > 0)
                        {
                            foreach (var item in pj.Ler())
                            {
                                Console.WriteLine($"Nome: {item.nome}  - CNPJ: {item.cnpj} - Razao social: {item.RazaoSocial}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista Vazia");
                        }
                        break;

                    case "5":
                        foreach(PessoaJuridica item in listpj)
                            {
                                
                                Console.WriteLine(@$"{item.RazaoSocial}, { item.cnpj}");

                            }
                        break;
                    case "6":
                        Console.WriteLine($"CNPJ a remover");
                        string Cnpj = Console.ReadLine();                      
                        PessoaJuridica Cnpjprocurado = listpj.Find(item => item.cnpj == Cnpj);
                        if (Cnpjprocurado != null)
                        {
                           listpj.Remove(Cnpjprocurado); 
                           Console.WriteLine($"cadastro removido"); 
                           

                        }else
                        {
                           Console.WriteLine($"Cnpj nao encontrado");                           
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