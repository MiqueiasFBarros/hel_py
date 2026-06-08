# hel_py

`hel_py` e um compilador didatico baseado em Python, desenvolvido em C# com Windows Forms. O projeto tambem possui uma interface grafica com caracteristicas de mini IDE, permitindo escrever codigo, abrir e salvar arquivos, compilar/executar algoritmos e visualizar a saida em um console interno.

O objetivo do projeto e demonstrar, de forma academica e pratica, conceitos basicos de compiladores, como leitura de codigo-fonte, validacao de comandos, avaliacao de expressoes, controle de fluxo, tratamento de escopo por indentacao e exibicao de mensagens de erro.

## Grupo

- Arthur da Silva - 01622306
- Gabriel Luan Soares de Oliveira - 01624195
- Joao Victor Florencio - 01605737
- Lucas Enthony Gomes Ferreira - 01576401
- Miqueias Ferreira Barros - 01595460
- Patrick Jose Viana Costa - 01594218

## Sobre o projeto

O compilador reconhece um subconjunto simples da linguagem Python. Ele nao implementa todos os recursos da linguagem original, pois o foco esta nos requisitos da atividade e na demonstracao dos principais conceitos de compilacao e execucao.

A aplicacao possui:

- editor de codigo;
- botoes para criar, abrir, salvar e salvar como;
- area de compilacao;
- console de saida;
- realce visual de sintaxe;
- suporte a arquivos `.py`;
- exemplos prontos para teste e apresentacao.

## Funcionalidades da linguagem

- Execucao de `print()`.
- Atribuicao de variaveis numericas.
- Atualizacao de variaveis, como `x = x + 1`.
- Expressoes aritmeticas com `+`, `-`, `*` e `/`.
- Uso de parenteses e precedencia de operadores.
- Condicional `if`.
- Alternativa condicional `else`.
- Repeticao com `while`.
- Comparadores `>`, `<`, `>=`, `<=`, `==` e `!=`.
- Comentarios com `#`.
- Validacao de blocos por indentacao de 4 espacos.
- Mensagens para erros como comando invalido, indentacao incorreta, variavel nao declarada e divisao por zero.

## Como executar

### Pelo Visual Studio

1. Abra o arquivo `hel_py.csproj` no Visual Studio 2022.
2. Confira se a carga de trabalho "Desenvolvimento para desktop com .NET" esta instalada.
3. Pressione `F5` ou clique em "Iniciar".
4. Digite um algoritmo no editor da esquerda.
5. Clique em `Executar hel_py`.

### Pelo terminal

```powershell
dotnet build
dotnet run
```

## Exemplo simples

```python
x = 0
while x < 5:
    print(x)
    x = x + 1

if x == 5:
    print("Fim do programa")
else:
    print("Contador terminou com valor inesperado")
```

Saida esperada:

```text
0
1
2
3
4
Fim do programa
```

## Exemplos incluidos

- `examples/demo.py`: exemplo principal para apresentacao, com `while`, `if`, `else`, variaveis e `print`.
- `examples/if_else.py`: exemplo curto para demonstrar o requisito de condicional.
- `examples/combate_chefe.py`: exemplo mais completo, combinando laco, condicoes, calculos e mensagens.
- `examples/teste.py`: exemplo adicional para testes de logica e repeticao.

## Estrutura do projeto

- `Form1.cs`: motor de compilacao/execucao, tratamento dos comandos e eventos da interface.
- `Form1.Designer.cs`: organizacao visual da interface grafica.
- `ModernControls.cs`: componentes visuais personalizados.
- `Program.cs`: ponto de entrada da aplicacao.
- `Assets/`: imagens e recursos visuais.
- `docs/relatorio.tex`: relatorio academico em LaTeX.
- `examples/`: codigos de teste usados para validacao e apresentacao.
