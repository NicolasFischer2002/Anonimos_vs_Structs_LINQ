

using Anonimos_vs_Structs;
using System.Linq.Expressions;

try
{
    Filme[] filmesCadastrados = Filme.FilmesCadastrados();
    do
    {
        Console.WriteLine("<===== Relatórios =====>");
        Console.WriteLine("\n - Digite 1 para vizualizar todos os filmes cadastrados");
        Console.WriteLine(" - Digite 2 para vizualizar o filme mais caro");
        Console.WriteLine(" - Digite 3 para vizualizar o filme mais barato");
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
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\nOpção inválida! Por favor, escolha um número válido!");
                    break;
            }
            Console.WriteLine("\nPrecione enter para obter outro relatório...");
            Console.ReadLine();
            Console.Clear();
        }

    } while (true);

}
catch (Exception e)
{
    throw new Exception("Erro ao trabalhar com Classe Anônima e Struct! " + e.Message);
}
