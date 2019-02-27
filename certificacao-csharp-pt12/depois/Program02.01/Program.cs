using System;
using System.Collections.Generic;

namespace Program02._01
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://cursos.alura.com.br/course/csharp-collections/task/29512

            //https://docs.google.com/presentation/d/1ICj8giHOiyW1AaHaiAtQyoGpW1LrhuqJ4GiX9BBHZHI/edit#slide=id.p

            //Apresentaremos um pequeno guia para ajudarmos na escolha da 
            //coleção adequada para determinadas situações. 
            //Vamos imaginar uma coleção em que sempre iremos remover o primeiro 
            //elemento colocado, isto é, a remoção será feita na mesma ordem da 
            //entrada dos elementos.

            //Como exemplo, usaremos uma fila de pedágio, ou uma fila de carros 
            //em um estacionamento, em que é necessário manter - se a ordem de 
            //prioridade. Assim, a coleção adequada é uma** fila**, ou 
            //`Queue<T>`, em inglês.

            //var veiculo1 = "van";
            //var veiculo2 = "kombi";
            //var veiculo3 = "guincho";
            //var veiculo4 = "pickup";

            //TIPO_COLECAO<string> pedagio = new TIPO_COLECAO<string>();
            //pedagio.ADICIONAR(veiculo1);
            //pedagio.ADICIONAR(veiculo2);
            //pedagio.ADICIONAR(veiculo3);
            //pedagio.ADICIONAR(veiculo4);

            //Console.WriteLine(pedagio.REMOVER());
            //Console.WriteLine(pedagio.REMOVER());
            //Console.WriteLine(pedagio.REMOVER());
            //Console.WriteLine(pedagio.REMOVER());
            //Console.WriteLine();

            //Trata - se de uma coleção genérica que receberá os elementos 
            //adicionados na fila pelo método `Enqueue()`. Os mesmos serão 
            //removidos usando - se `Dequeue()` e, ao fazermos isto, os 
            //elementos são reposicionados de forma que o segundo passa a 
            //ser o primeiro, e assim sucessivamente.

            //Há também situações em que o elemento removido será sempre o 
            //último que foi adicionado.Isto ocorre com a coleção genérica 
            //**pilha * *, ou `Stack<T>`, em inglês. Nela, os elementos 
            //são adicionados usando - se `Push()`, e removidos com o método 
            //`Pop()`.

            //string site0 = "<<vazio>>";
            //string site1 = "google.com";
            //string site2 = "caelum.com.br";
            //string site3 = "alura.com.br";

            //TIPO_COLECAO<string> historicoNavegador = new TIPO_COLECAO<string>();

            //historicoNavegador.INCLUIR(site0);
            //Console.WriteLine("Navegando para: {0}", site1);
            //historicoNavegador.INCLUIR(site1);
            //Console.WriteLine("Navegando para: {0}", site2);
            //historicoNavegador.INCLUIR(site2);
            //Console.WriteLine("Navegando para: {0}", site3);
            //historicoNavegador.INCLUIR(site3);

            //Console.WriteLine("Voltando para: {0}", historicoNavegador.REMOVER());
            //Console.WriteLine("Voltando para: {0}", historicoNavegador.REMOVER());
            //Console.WriteLine("Voltando para: {0}", historicoNavegador.REMOVER());
            //Console.WriteLine("Voltando para: {0}", historicoNavegador.REMOVER());
            //Console.WriteLine();

            //Existe um tipo de coleção, a mais flexível e poderosa de todas: 
            //a `List<T>`, uma implementação do .NET Framework que permite 
            //a inserção de um elemento em qualquer posição da coleção
            //(`Insert()`), ou especificamente no fim(`Add()` e `AddRange()`).

            //TIPO_COLECAO<string> meses = new TIPO_COLECAO<string>
            //{
            //    "janeiro","fevereiro","março","abril",
            //    "abril","maio","junho",
            //    "julho","agosto"             
            //};

            //meses.INCLUIR("setembro");
            //meses.INCLUIR_FAIXA(new string[] { "novembro", "dezembro", "onzembro" });

            //É possível também remover elementos do meio da coleção, com 
            //`Remove()` ou `RemoveRange()`, limpar a coleção(`Clear()`) ou 
            //reverter sua ordem(`Reverse()`).

            //meses.REMOVER_NO_INDICE(4);
            //meses.REMOVER_NO_INDICE(meses.Count - 1);
            //meses.INCLUIR(9, "outubro");

            //for (int i = 0; i < meses.Count; i++)
            //{
            //    Console.WriteLine("mês {0}: {1}", i + 1, meses[i]);
            //}
            //Console.WriteLine();

            //Pode -se também ordená-la por 
            //um critério qualquer, com `Sort()`.

            //meses.Sort((m1, m2) => m1.CompareTo(m2));

            //for (int i = 0; i < meses.Count; i++)
            //{
            //    Console.WriteLine("{0}", meses[i]);
            //}
            //Console.WriteLine();

            //Caso tenhamos que lidar com arquivos de baixo nível(bytes, 
            //números inteiros, por exemplo) ou tamanho fixo, quase sempre 
            //utilizamos uma **matriz * *, ou* array*, em inglês, uma coleção 
            //de tamanho fixo que facilita o uso através do índice da coleção.

            //TIPO_COLECAO imagem = new TIPO_COLECAO[65535];

            //int x = 31;
            //int y = 14;

            //const int rgb = 0x9EA3A7;
            //imagem.ITEM_NA_POSICAO(27) = rgb;

            //Tomando como exemplo um array cujas informações gráficas, no 
            //caso, uma cor, um pixel sendo lido em uma determinada posição, 
            //são mantidas, é bastante simples acessar os dados de forma 
            //indexada. No entanto, quando precisamos alterar sua dimensão, 
            //é mais recomendado convertê-lo para uma lista.

            //Ainda, há situações em que é necessário inserir ou remover muitos 
            //dados em uma coleção, de forma rápida. Nestes casos, pode-se 
            //considerar utilizar uma** lista ligada * *, ou 
            //`LinkedList<T>`. Com ele, é possível adicionar um elemento 
            //no início(`AddFirst()`), no fim(`AddLast()`), antes(`AddBefore()`)
            //ou depois(`AddAfter()`) de outro elemento da mesma coleção.

            //TIPO_COLECAO<string> dias = new TIPO_COLECAO<string>();
            //var d4 = dias.ADICIONAR_PRIMEIRO("quarta");
            //var d2 = dias.ADICIONAR_ANTES_DE(d4, "segunda");
            //var d3 = dias.ADICIONAR_DEPOIS_DE(d2, "terça");
            //var d6 = dias.ADICIONAR_DEPOIS_DE(d4, "sexta");
            //var d7 = dias.ADICIONAR_DEPOIS_DE(d6, "sábado");
            //var d5 = dias.ADICIONAR_ANTES_DE(d6, "quinta");
            //var d1 = dias.ADICIONAR_ANTES_DE(d2, "domingo");
            //foreach (var dia in dias)
            //{
            //    Console.WriteLine(dia);
            //}
            //Console.WriteLine();

            //O que caracteriza uma lista ligada é que **cada elemento é 
            //chamado de nó * *, remetendo à classe do .NET Framework denominada 
            //`LinkedListNode`. Estes nós possuem dois ponteiros(ou duas 
            //referências) que apontam tanto para o elemento anterior quanto para o 
            //próximo, de forma a manter a ordem de entrada dos elementos 
            //nesta lista, o que possibilida a inserção ou remoção 
            //independentemente de sua posição.

            //As desvantagens de uma lista ligada implicam no acesso a um 
            //elemento de forma indexada, o que é impossível, e na busca de 
            //elementos em uma lista, causando um processo bastante demorado.
            //Nestes casos, recomenda-se o uso de `List<T>`.

            //Em uma situação de operações com conjuntos matemáticos, para 
            //saber se um elemento está contido em uma coleção ou não, ou para 
            //saber se duas coleções possuem um ou mais elementos em comum, 
            //utilizaremos `HashSet<T>`.

            //var pares = new List<int> { 0, 2, 4, 6, 8, 10 };
            //var impares = new List<int> { 1, 3, 5, 7, 9 };
            //var primos = new List<int> { 1, 3, 5, 7, 9 };

            //TIPO_COLECAO<int> zeroAdez = new TIPO_COLECAO<int>();
            //pares.ForEach(n => zeroAdez.INCLUIR(n));
            //impares.ForEach(n => zeroAdez.INCLUIR(n));
            //primos.ForEach(n => zeroAdez.INCLUIR(n));

            //foreach (var n in zeroAdez)
            //{
            //    Console.WriteLine(n);
            //}
            //Console.WriteLine();

            //Outro tipo de coleção ideal para a busca de um valor a partir de 
            //uma chave a ser armazenada(um cliente por um CPF, por exemplo, ou 
            //uma empresa através do CNPJ) é o **dicionário * *, ou 
            //`Dictionary<TKey,TValue>`, para o qual forneceremos o tipo 
            //da chave e do valor.

            //TIPO_COLECAO<string, string> weekDays = new TIPO_COLECAO<string, string>
            //{
            //    { "SEG", "Monday" },
            //    { "TER", "Tuesday" },
            //    { "QUA", "Wednesday" },
            //    { "QUI", "Thursday" },
            //    { "SEX", "Friday" }
            //};
            //weekDays.Add("SAB", "Saturday");
            //weekDays.Add("DOM", "Sunday");

            //foreach (var chaveValor in weekDays)
            //{
            //    Console.WriteLine("{0} - {1}", chaveValor.Key, chaveValor.Value);
            //}

            Console.ReadLine();
        }
    }
}
