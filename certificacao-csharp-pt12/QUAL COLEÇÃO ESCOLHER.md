https://cursos.alura.com.br/course/csharp-collections/task/29512

https://docs.google.com/presentation/d/1ICj8giHOiyW1AaHaiAtQyoGpW1LrhuqJ4GiX9BBHZHI/edit#slide=id.p

Apresentaremos um pequeno guia para ajudarmos na escolha da cole��o adequada para determinadas situa��es. Vamos imaginar uma cole��o em que sempre iremos remover o primeiro elemento colocado, isto �, a remo��o ser� feita na mesma ordem da entrada dos elementos.

Como exemplo, usaremos uma fila de ped�gio, ou uma fila de carros em um estacionamento, em que � necess�rio manter-se a ordem de prioridade. Assim, a cole��o adequada � uma **fila**, ou `Queue<T>`, em ingl�s.

Trata-se de uma cole��o gen�rica que receber� os elementos adicionados na fila pelo m�todo `Enqueue()`. Os mesmos ser�o removidos usando-se `Dequeue()` e, ao fazermos isto, os elementos s�o reposicionados de forma que o segundo passa a ser o primeiro, e assim sucessivamente.

H� tamb�m situa��es em que o elemento removido ser� sempre o �ltimo que foi adicionado. Isto ocorre com a cole��o gen�rica **pilha**, ou `Stack<T>`, em ingl�s. Nela, os elementos s�o adicionados usando-se `Push()`, e removidos com o m�todo `Pop()`.

Existe um tipo de cole��o, a mais flex�vel e poderosa de todas: a `List<T>`, uma implementa��o do .NET Framework que permite a inser��o de um elemento em qualquer posi��o da cole��o (`Insert()`), ou especificamente no fim (`Add()` e `AddRange()`). � poss�vel tamb�m remover elementos do meio da cole��o, com `Remove()` ou `RemoveRange()`, limpar a cole��o (`Clear()`) ou reverter sua ordem (`Reverse()`). Pode-se tamb�m orden�-la por um crit�rio qualquer, com `Sort()`.

Caso tenhamos que lidar com arquivos de baixo n�vel (bytes, n�meros inteiros, por exemplo) ou tamanho fixo, quase sempre utilizamos uma **matriz**, ou *array*, em ingl�s, uma cole��o de tamanho fixo que facilita o uso atrav�s do �ndice da cole��o.

```
data[27] = #9EA3A7
```

Tomando como exemplo um array cujas informa��es gr�ficas, no caso, uma cor, um pixel sendo lido em uma determinada posi��o, s�o mantidas, � bastante simples acessar os dados de forma indexada. No entanto, quando precisamos alterar sua dimens�o, � mais recomendado convert�-lo para uma lista.

Ainda, h� situa��es em que � necess�rio inserir ou remover muitos dados em uma cole��o, de forma r�pida. Nestes casos, pode-se considerar utilizar uma **lista ligada**, ou `LinkedList<T>`. Com ele, � poss�vel adicionar um elemento no in�cio (`AddFirst()`), no fim (`AddLast()`), antes (`AddBefore()`) ou depois (`AddAfter()`) de outro elemento da mesma cole��o.

O que caracteriza uma lista ligada � que **cada elemento � chamado de n�**, remetendo � classe do .NET Framework denominada `LinkedListNode`. Estes n�s possuem dois ponteiros (ou duas refer�ncias) que apontam tanto para o elemento anterior quanto para o pr�ximo, de forma a manter a ordem de entrada dos elementos nesta lista, o que possibilida a inser��o ou remo��o independentemente de sua posi��o.

As desvantagens de uma lista ligada implicam no acesso a um elemento de forma indexada, o que � imposs�vel, e na busca de elementos em uma lista, causando um processo bastante demorado. Nestes casos, recomenda-se o uso de `List<T>`.

Em uma situa��o de opera��es com conjuntos matem�ticos, para saber se um elemento est� contido em uma cole��o ou n�o, ou para saber se duas cole��es possuem um ou mais elementos em comum, utilizaremos `HashSet<T>`.

Outro tipo de cole��o ideal para a busca de um valor a partir de uma chave a ser armazenada (um cliente por um CPF, por exemplo, ou uma empresa atrav�s do CNPJ) � o **dicion�rio**, ou `Dictionary<TKey, TValue>`, para o qual forneceremos o tipo da chave e do valor.

### Para saber mais

Alguns cursos complementares:

* <a href="https://cursos.alura.com.br/course/projetos-de-algoritmos-2" target="_blank">Curso Algoritmos II: MergeSort, QuickSort, Busca Bin�ria e An�lise de Algoritmo</a>

* <a href="https://cursos.alura.com.br/course/csharp-topicos-avancados" target="_blank">Curso C# III: T�picos Avan�ados</a>

* <a href="https://cursos.alura.com.br/course/linq-c-sharp" target="_blank">Curso Entity LinQ parte 1: Crie queries poderosas em C#
</a>