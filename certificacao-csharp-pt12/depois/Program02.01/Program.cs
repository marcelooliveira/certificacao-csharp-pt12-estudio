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

            var veiculo1 = "van";
            var veiculo2 = "kombi";
            var veiculo3 = "guincho";
            var veiculo4 = "pickup";

            Queue<string> pedagio = new Queue<string>();
            pedagio.Enqueue(veiculo1);
            pedagio.Enqueue(veiculo2);
            pedagio.Enqueue(veiculo3);
            pedagio.Enqueue(veiculo4);

            Console.WriteLine(pedagio.Dequeue());
            Console.WriteLine(pedagio.Dequeue());
            Console.WriteLine(pedagio.Dequeue());
            Console.WriteLine(pedagio.Dequeue());
            Console.WriteLine();

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

            string site0 = "<<vazio>>";
            string site1 = "google.com";
            string site2 = "caelum.com.br";
            string site3 = "alura.com.br";

            Stack<string> historicoNavegador = new Stack<string>();

            historicoNavegador.Push(site0);
            Console.WriteLine("Navegando para: {0}", site1);
            historicoNavegador.Push(site1);
            Console.WriteLine("Navegando para: {0}", site2);
            historicoNavegador.Push(site2);
            Console.WriteLine("Navegando para: {0}", site3);
            historicoNavegador.Push(site3);

            Console.WriteLine("Voltando para: {0}", historicoNavegador.Pop());
            Console.WriteLine("Voltando para: {0}", historicoNavegador.Pop());
            Console.WriteLine("Voltando para: {0}", historicoNavegador.Pop());
            Console.WriteLine("Voltando para: {0}", historicoNavegador.Pop());
            Console.WriteLine();

            //Existe um tipo de coleção, a mais flexível e poderosa de todas: 
            //a `List<T>`, uma implementação do .NET Framework que permite 
            //a inserção de um elemento em qualquer posição da coleção
            //(`Insert()`), ou especificamente no fim(`Add()` e `AddRange()`).

            List<string> meses = new List<string>
            {
                "janeiro","fevereiro","março","abril",
                "abril","maio","junho",
                "julho","agosto"             
            };

            meses.Add("setembro");
            meses.AddRange(new string[] { "novembro", "dezembro", "onzembro" });

            //É possível também remover elementos do meio da coleção, com 
            //`Remove()` ou `RemoveRange()`, limpar a coleção(`Clear()`) ou 
            //reverter sua ordem(`Reverse()`).

            meses.RemoveAt(4);
            meses.RemoveAt(meses.Count - 1);
            meses.Insert(9, "outubro");

            for (int i = 0; i < meses.Count; i++)
            {
                Console.WriteLine("mês {0}: {1}", i + 1, meses[i]);
            }
            Console.WriteLine();

            //Pode -se também ordená-la por 
            //um critério qualquer, com `Sort()`.

            meses.Sort((m1, m2) => m1.CompareTo(m2));

            for (int i = 0; i < meses.Count; i++)
            {
                Console.WriteLine("{0}", meses[i]);
            }
            Console.WriteLine();

            //Caso tenhamos que lidar com arquivos de baixo nível(bytes, 
            //números inteiros, por exemplo) ou tamanho fixo, quase sempre 
            //utilizamos uma **matriz * *, ou* array*, em inglês, uma coleção 
            //de tamanho fixo que facilita o uso através do índice da coleção.

            int[] imagem = new int[65535];

            int x = 31;
            int y = 14;

            const int rgb = 0x9EA3A7;
            imagem[27] = rgb;

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

            LinkedList<string> dias = new LinkedList<string>();
            var d4 = dias.AddFirst("quarta");
            var d2 = dias.AddBefore(d4, "segunda");
            var d3 = dias.AddAfter(d2, "terça");
            var d6 = dias.AddAfter(d4, "sexta");
            var d7 = dias.AddAfter(d6, "sábado");
            var d5 = dias.AddBefore(d6, "quinta");
            var d1 = dias.AddBefore(d2, "domingo");
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
            Console.WriteLine();

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

            var pares = new List<int> { 0, 2, 4, 6, 8, 10 };
            var impares = new List<int> { 1, 3, 5, 7, 9 };
            var primos = new List<int> { 1, 3, 5, 7, 9 };

            HashSet<int> zeroAdez = new HashSet<int>();
            pares.ForEach(n => zeroAdez.Add(n));
            impares.ForEach(n => zeroAdez.Add(n));
            primos.ForEach(n => zeroAdez.Add(n));

            foreach (var n in zeroAdez)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            //Outro tipo de coleção ideal para a busca de um valor a partir de 
            //uma chave a ser armazenada(um cliente por um CPF, por exemplo, ou 
            //uma empresa através do CNPJ) é o **dicionário * *, ou 
            //`Dictionary<TKey,TValue>`, para o qual forneceremos o tipo 
            //da chave e do valor.

            Dictionary<string, string> weekDays = new Dictionary<string, string>
            {
                { "SEG", "Monday" },
                { "TER", "Tuesday" },
                { "QUA", "Wednesday" },
                { "QUI", "Thursday" },
                { "SEX", "Friday" }
            };
            weekDays.Add("SAB", "Saturday");
            weekDays.Add("DOM", "Sunday");

            foreach (var chaveValor in weekDays)
            {
                Console.WriteLine("{0} - {1}", chaveValor.Key, chaveValor.Value);
            }

            Console.ReadLine();
        }
    }
}
