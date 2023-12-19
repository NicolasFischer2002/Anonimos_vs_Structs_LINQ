using System.Globalization;


namespace Anonimos_vs_Structs
{
    // <===== Construtor da Classe =====> //
    public class Filme(long id, string titulo, DateTime dataLancamento, string diretor, string genero, float valor)
    {
        public long Id { get; init; } = id;
        public string Titulo { get; init; } = titulo;
        public DateTime DataLancamento { get; init; } = dataLancamento;
        public string Diretor { get; init; } = diretor;
        public string Genero { get; init; } = genero;
        public float Valor { get; set; } = valor;

        private struct FilmesMaisBaratos
        {
            public string Titulo;
            public float Valor;
        }

        private struct TituloDiretorFilme
        {
            public string Titulo;
            public string Diretor;
        }

        public static Filme[] FilmesCadastrados()
        {
            Filme[] filmes =
            [
                 new (1, "Um Sonho de Liberdade", new DateTime(1994, 9, 23), "Frank Darabont", "Drama", 50.00f),
                 new (2, "Enigma do Outro Mundo", new DateTime(1982, 6, 25), "John Carpenter", "Ficção Científica", 10.00f),
                 new (3, "O Resgate do Soldado Ryan", new DateTime(1998, 7, 24), "Steven Spielberg", "Drama de Guerra",25.00f),
                 new (4, "O Poderoso Chefão", new DateTime(1972, 3, 24), "Francis Ford Coppola", "Crime, Drama", 10.00f),
                 new (5, "Predador", new DateTime(1987, 6, 12), "John McTiernan", "Ação, Ficção Científica", 15.00f),
                 new (6, "Logan", new DateTime(2017, 3, 3), "James Mangold", "Ação, Drama, Ficção Científica", 10.00f),
                 new (7, "A Ilha do Medo", new DateTime(2010, 2, 19), "Martin Scorsese", "Mistério, Suspense", 15.00f),
                 new (8, "Forrest Gump", new DateTime(1994, 7, 6), "Robert Zemeckis", "Comédia, Drama, Romance", 20.00f),
                 new (9, "Pulp Fiction", new DateTime(1994, 10, 14), "Quentin Tarantino", "Crime, Drama", 12.00f),
                 new (10, "Dia de Treinamento", new DateTime(2001, 10, 5), "Antoine Fuqua", "Crime, Drama, Thriller", 12.50f),
                 new (11, "Seven", new DateTime(1995, 9, 22), "David Fincher", "Crime, Drama, Mistério", 22.50f),
                 new (13, "Exterminador do Futuro 2", new DateTime(1991, 7, 3), "James Cameron", "Ação, Ficção Científica", 25.50f),
                 new (14, "Indiana Jones e os Caçadores da Arca Perdida", new DateTime(1981, 6, 12), "Steven Spielberg", "Ação, Aventura", 30.00f),
                 new (15, "O Show de Truman", new DateTime(1998, 6, 5), "Peter Weir", "Comédia, Drama, Ficção Científica", 12.50f),
                 new (16, "O Senhor dos Anéis: As Duas Torres", new DateTime(2002, 12, 18), "Peter Jackson", "Ação, Aventura, Drama", 50.00f),
                 new (17, "O Décimo Terceiro Guerreiro", new DateTime(1999, 8, 27), "John McTiernan, Michael Crichton", "Ação, Aventura, História", 15.00f),
                 new (18, "Rambo: Programado Para Matar", new DateTime(1982, 10, 22), "Ted Kotcheff", "Ação, Aventura, Drama", 30.00f),
                 new (19, "Alien: O Oitavo Passageiro", new DateTime(1979, 5, 25), "Ridley Scott", "Horror, Sci-Fi", 15.50f),
                 new (20, "Toy Story", new DateTime(1995, 11, 22), "John Lasseter", "Animação, Aventura, Comédia", 10.00f)
            ];
            return filmes;
        }

        public static void ExibeFilmesCadastrados(Filme[] filmes)
        {
            Console.WriteLine("<===== Todos os filmes cadastrados =====>");
            foreach (Filme filme in filmes)
                Console.WriteLine($"{filme.Titulo}");
        }

        public static void ExibeFilmesMaisCaros(Filme[] filmes)
        {
            // Exemplo prático de classe anônima, uma List<anônima>
            var filmesMaisCaros = filmes
                .OrderByDescending(f => f.Valor)
                .Where(f => f.Valor == filmes.Max(x => x.Valor))
                .Select(f => new { f.Titulo, f.Valor })
                .ToList();

            Console.WriteLine("<===== Filmes mais caros =====>");
            foreach (var filme in filmesMaisCaros)
                Console.WriteLine($"{filme.Titulo} - {filme.Valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

            // "filmesMaisCaros" é uma lista de objetos anônimos; por consequência, não é possível alterar o tipo da variável "filme" no foreach
            // para um tipo conhecido, pois ele é um tipo anônimo, ou seja, não mapeado dentro da aplicação por uma Classe ou Struct.
            // Tipos anônimos são úteis para quando se precisa de um tipo de objeto ainda não mapeado e que não vai possuir uma vida longa
            // dentro do programa. Utilizar Classes Anônimas agiliza no desenvolvimento e gera menos código, no entanto o código gerado pode ser menos legível,
            // aliado à um consumo maior de memória e de um desempenho inferior, já que por ser uma Classe, o objeto será alocado na Heap da memória;
            // por conta disso, o objeto leverá mais tempo para ser desalocado, sobrevivendo mais do que o tempo de execução do seu escopo onde foi criado,
            // dependendo exclusivamente Garbage Collector para ser limpo da memória, além de ter um desempenho pior, visto que para localizar
            // algo armazenado na Heap, é mais lento do que para localizar algo armazenado na Stack.
        }

        public static void ExibeFilmesMaisBaratos(Filme[] filmes)
        {
            // Extra:
            // Caso fosse necessário acessar índices aleatórios, IReadOnlyList seria adequado; mas como a estrutura está sendo utilizada
            // apenas para uma iteração sequêncial, o IEnumerable atende melhor no que diz respeito à semântica, visto que ele só permite
            // a iteração sequêncial e também não permite a modificação da estrutura.
            //IReadOnlyList<FilmesMaisBaratos> filmesMaisBaratos = filmes
            //    .OrderBy(f => f.Valor)
            //    .Where(f => f.Valor == filmes.Min(x => x.Valor))
            //    .Select(f => new FilmesMaisBaratos { Titulo = f.Titulo, Valor = f.Valor })
            //    .ToList();

            // Abordagem utilizando Structs
            IEnumerable<FilmesMaisBaratos> filmesMaisBaratos = filmes
                  .OrderBy(f => f.Valor)
                  .Where(f => f.Valor == filmes.Min(x => x.Valor))
                  .Select(f => new FilmesMaisBaratos { Titulo = f.Titulo, Valor = f.Valor });

            Console.WriteLine("<===== Filmes mais baratos =====>");
            foreach (FilmesMaisBaratos filme in filmesMaisBaratos)
                Console.WriteLine($"{filme.Titulo} - {filme.Valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");

            // Diferente das Classes Anônimas, o código aqui é mais legível, pois no foreach por exemplo, é possível determinar o tipo da variável "filme",
            // que é uma Struct definida. Características como legibilidade, reaproveitamento de código e eficiência acompanham as Structs;
            // Graças ao uso de Structs é possível: identificar os tipos e melhorar a semântica do código, utilizar as Structs à vontade uma vez que definidas,
            // além de desfrutar de um desempenho superior quando comparado às classes, visto que e as Structs - compactas - são armazenadas na Stack,
            // por serem tipo-valor, e graças à isso possuem um tempo de vida mais curto geralmente se limitando ao tempo de execução do seu escopo
            // - já que como são alocadas na Stack precisam ser desalocadas rapidamente assim que deixarem de ser utilizadas, pois o espaço da
            // memória Stack é muito limitado, muito menor quando comparado com a memória Heap; por conta disso, o acesso aos valores contidos na Stack é
            // mais rápido, pois a localização na Stack dos valores contidos na Struct durante a execução é muito mais veloz do que se o mesmo
            // se encontrasse na Heap, em parte, por conta do tamanho fixo e compacto da memória Stack serem ordens de grandeza
            // menor que o tamanho dinâmico da Heap.
            // Em contra partida, utilizar Structs é mais trabalhoso e gera mais código.
        }

        public static void ExibeValorMedioDosFilmes(Filme[] filmes)
        {
            float valorMedio = filmes.Average(f => f.Valor);

            Console.WriteLine("<===== Valor médio dos filmes =====>");
            Console.WriteLine(valorMedio);
        }

        public static void ExibeFilmesOrdPorPreco(Filme[] filmes)
        {
            IReadOnlyDictionary<string, float> filmesOrdPorPreco = filmes
                .OrderByDescending(f => f.Valor)
                .ToDictionary(f => f.Titulo, f => f.Valor);

            Console.WriteLine("<===== Filmes ordenados por preço =====>");
            foreach (var filme in filmesOrdPorPreco)
                Console.WriteLine($"{filme.Key}, {filme.Value.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
        }

        public static void FilmesOrdPorLancamento(Filme[] filmes)
        {
            // Mais um exemplo de classe anônima
            var filmesOrdPorDataLancamento = filmes.OrderByDescending(f => f.DataLancamento).Select(f => new { f.Titulo, f.DataLancamento });
            
            Console.WriteLine("<===== Filmes ordenados por data de lançamento =====>");
            foreach (var filme in filmesOrdPorDataLancamento)
                Console.WriteLine($"{filme.Titulo}, {filme.DataLancamento.ToString("dd/MM/yyyy")}");
        }

        public static void ExibeFilmesOrdPorID(Filme[] filmes)
        {
            IReadOnlyDictionary<long, string> filmesOrdPorID = filmes
                .OrderBy(f => f.Id)
                .ToDictionary(f => f.Id, f => f.Titulo);

            Console.WriteLine("<===== Filmes ordenados por ID =====>");
            foreach (var filme in filmesOrdPorID)
                Console.WriteLine($"{filme.Key}, {filme.Value}");
        }

        public static void ExibeIdTituloDiretorFilme(Filme[] filmes)
        {
            // Um dicionário de Structs
            IReadOnlyDictionary<long, TituloDiretorFilme> IdTituloDiretorFilme = filmes
                .OrderBy(f => f.Id)
                .ToDictionary(f => f.Id, f => new TituloDiretorFilme { Titulo = f.Titulo, Diretor = f.Diretor });

            Console.WriteLine("<===== Filmes e seus diretores, ordenados por ID =====>");
            foreach (var filme in IdTituloDiretorFilme)
                Console.WriteLine($"{filme.Key} - {filme.Value.Titulo}, {filme.Value.Diretor}");
        }
    }
}
