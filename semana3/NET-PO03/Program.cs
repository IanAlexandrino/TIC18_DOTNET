﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<(int Codigo, string Nome, int Quantidade, double Preco)> estoque = new List<(int, string, int, double)>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto por Código");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Relatórios");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    ConsultarProdutoPorCodigo();
                    break;
                case "3":
                    AtualizarEstoque();
                    break;
                case "4":
                    GerarRelatorios();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço unitário: ");
            double preco = double.Parse(Console.ReadLine());

            estoque.Add((codigo, nome, quantidade, preco));
            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de fornecer valores numéricos corretos.");
        }
    }

    static void ConsultarProdutoPorCodigo()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

            if (produto.Equals(default((int, string, int, double))))
            {
                throw new ProdutoNaoEncontradoException("Produto não encontrado.");
            }

            Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de fornecer um código válido.");
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void AtualizarEstoque()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

            if (produto.Equals(default((int, string, int, double))))
            {
                throw new ProdutoNaoEncontradoException("Produto não encontrado.");
            }

            Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
            int quantidade = int.Parse(Console.ReadLine());

            if (produto.Quantidade + quantidade < 0)
            {
                throw new QuantidadeInsuficienteException("Quantidade insuficiente em estoque.");
            }

            produto.Quantidade += quantidade;
            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de fornecer um código e uma quantidade válidos.");
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (QuantidadeInsuficienteException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void GerarRelatorios()
    {
        Console.Write("Digite o limite de quantidade para o relatório 1: ");
        int limiteQuantidade = int.Parse(Console.ReadLine());

        var relatorio1 = estoque.Where(p => p.Quantidade < limiteQuantidade);
        Console.WriteLine("Relatório 1 - Produtos com quantidade abaixo do limite:");
        ImprimirRelatorio(relatorio1);

        Console.Write("Digite o valor mínimo para o relatório 2: ");
        double minimo = double.Parse(Console.ReadLine());

        Console.Write("Digite o valor máximo para o relatório 2: ");
        double maximo = double.Parse(Console.ReadLine());

        var relatorio2 = estoque.Where(p => p.Preco >= minimo && p.Preco <= maximo);
        Console.WriteLine("Relatório 2 - Produtos com valor entre o mínimo e o máximo:");
        ImprimirRelatorio(relatorio2);

        var relatorio3 = from p in estoque
                         select new
                         {
                             Nome = p.Nome,
                             ValorTotal = p.Quantidade * p.Preco
                         };

        Console.WriteLine("Relatório 3 - Valor total do estoque e valor total de cada produto:");
        foreach (var item in relatorio3)
        {
            Console.WriteLine($"Produto: {item.Nome}, Valor Total: {item.ValorTotal:C}");
        }
    }

    static void ImprimirRelatorio(IEnumerable<(int Codigo, string Nome, int Quantidade, double Preco)> relatorio)
    {
        foreach (var item in relatorio)
        {
            Console.WriteLine($"Código: {item.Codigo}, Nome: {item.Nome}, Quantidade: {item.Quantidade}, Preço: {item.Preco:C}");
        }
    }
}

class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string message) : base(message)
    {
    }
}

class QuantidadeInsuficienteException : Exception
{
    public QuantidadeInsuficienteException(string message) : base(message)
    {
    }
}

