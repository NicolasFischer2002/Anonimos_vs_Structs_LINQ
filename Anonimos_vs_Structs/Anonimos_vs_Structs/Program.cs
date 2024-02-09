

using Anonimos_vs_Structs;
using System.Linq.Expressions;


// <===== Observações importantes sobre as intenções deste projeto =====> //
// Este projeto tem por objetivo demonstrar de forma modesta a implementação de Classes Anônimas e Structs, além de suas vantagens e desvantagens.
// Diversas estruturas de dados serão utilizadas como exemplo no decorrer do código, no entanto, no que diz respeito à alocação dessas estruturas
// de dados na memória, indifere se serão preenchidas por Classes Anônimas ou por Structs; pois serão todas armazenadas na Heap da memória.
// Via de regra, estruturas de dados são armazenadas na Heap por serem tipos de referência.
// Um exemplo de estrutura de dados que foge à está regra e que vale ser mencionada seria o Span<T>, mas que não é utilizado no escopo deste projeto.
// Por tanto, as explicações contidas no código são demasiado geréricas e devem ser entendidas desta forma, não se aplicando às estruturas de dados utilizadas,
// mas sim à "Classe" e "Struct" de forma geral e suas interações com a semântica do código e alocação na memória fora das estrutudas de dados.


try
{
    Filme[] filmesCadastrados = Filme.FilmesCadastrados();
    do
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("<===== Relatórios =====>");
        Console.WriteLine("\n - Digite 1 para vizualizar todos os filmes cadastrados");
        Console.WriteLine(" - Digite 2 para vizualizar os filmes mais caros");
        Console.WriteLine(" - Digite 3 para vizualizar os filmes mais baratos");
        Console.WriteLine(" - Digite 4 para vizualizar a média de preço dos filmes");
        Console.WriteLine(" - Digite 5 para vizualizar os filmes ordenados por preço");
        Console.WriteLine(" - Digite 6 para vizualizar os filmes ordenados por data de lançamento");
        Console.WriteLine(" - Digite 7 para vizualizar código e nome do filme");
        Console.WriteLine(" - Digite 8 para vizualizar o código, titulo e o diretor do filme");
        Console.WriteLine(" - Digite 0 para sair do programa");

        Console.Write("\n Digite o número correspondente à opção desejada: ");
        string? codSelecionado = Console.ReadLine();
        if (!string.IsNullOrEmpty(codSelecionado))
        {
            switch (codSelecionado)
            {
                case "1":
                    Console.Clear();
                    Filme.ExibeFilmesCadastrados(filmesCadastrados);
                    break;
                
                case "2":
                    Console.Clear();
                    Filme.ExibeFilmesMaisCaros(filmesCadastrados);
                    break;

                case "3":
                    Console.Clear();
                    Filme.ExibeFilmesMaisBaratos(filmesCadastrados);
                    break;

                case "4":
                    Console.Clear();
                    Filme.ExibeValorMedioDosFilmes(filmesCadastrados);
                    break;
                case "5":
                    Console.Clear();
                    Filme.ExibeFilmesOrdPorPreco(filmesCadastrados);
                    break;

                case "6":
                    Console.Clear();
                    Filme.FilmesOrdPorLancamento(filmesCadastrados);
                    break;
                
                case "7":
                    Console.Clear();
                    Filme.ExibeFilmesOrdPorID(filmesCadastrados);
                    break;

                case "8":
                    Console.Clear();
                    Filme.ExibeIdTituloDiretorFilme(filmesCadastrados);
                    break;

                case "0":
                    Console.Clear();
                    Console.WriteLine("Obrigado por participar! :)");
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\nOpção inválida! Por favor, escolha um número válido!");
                    Console.Clear();
                    break;
            }

            Console.WriteLine("\nPrecione enter para obter outro relatório...");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOpção inválida! Precione enter para obter outro relatório...");
            Console.ReadLine();
        }

    } while (true);

}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    throw new Exception("Erro ao trabalhar com Classe Anônima e Struct! " + e.Message);
}
