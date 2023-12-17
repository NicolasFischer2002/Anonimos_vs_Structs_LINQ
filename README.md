# Anonimos_vs_Structs_LINQ
// <===== Observações importantes sobre as intenções deste projeto =====> //
Este projeto tem por objetivo demonstrar de forma modesta a implementação de Classes Anônimas e Structs, além de suas vantagens e desvantagens.
Diversas estruturas de dados serão utilizadas como exemplo no decorrer do código, no entanto, no que diz respeito à alocação dessas estruturas
de dados na memória, indifere se serão preenchidas por Classes Anônimas ou por Structs; pois serão todas armazenadas na Heap da memória.
Via de regra, estruturas de dados são armazenadas na Heap por serem tipos de referência.
Um exemplo de estrutura de dados que foge à está regra e que vale ser mencionada seria o Span<T>, mas que não é utilizado no escopo deste projeto.
Por tanto, as explicações contidas no código são demasiado geréricas e devem ser entendidas desta forma, não se aplicando às estruturas de dados utilizadas,
mas sim à "Classe" e "Struct" de forma geral e suas interações com a semântica do código e alocação na memória fora das estrutudas de dados.

=> Documentação: 
Tipos de dados em C#: https://medium.com/@jonesroberto/tipos-de-dados-em-c-22531bf454a0
Gerenciamento de memória no C#: stack, heap, value-types e reference-types: https://www.treinaweb.com.br/blog/gerenciamento-de-memoria-no-c-stack-heap-value-types-e-reference-types
Tipos anônimos: https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/anonymous-types
Introdução às consultas LINQ (C#): https://learn.microsoft.com/pt-br/dotnet/csharp/linq/get-started/introduction-to-linq-queries
Medir o uso de memória no Visual Studio: https://learn.microsoft.com/pt-br/visualstudio/profiling/memory-usage?view=vs-2022
Span<T> Estrutura: https://learn.microsoft.com/pt-br/dotnet/api/system.span-1?view=net-8.0
