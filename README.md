# hel_py

`hel_py` e um compilador visual/IDE academica em C# Windows Forms para interpretar um subconjunto simples da linguagem Python.

## Funcionalidades

- Editor de codigo com fonte monoespacada.
- Console de saida em estilo terminal.
- Criacao de novo arquivo.
- Abertura de arquivos `.py`.
- Salvamento e "Salvar como" de arquivos `.py`.
- Execucao de `print()`.
- Atribuicao de variaveis numericas.
- Expressoes aritmeticas com `+`, `-`, `*`, `/`, parenteses e precedencia.
- Condicionais `if`.
- Alternativa condicional `else`.
- Repeticoes `while`.
- Comparadores `>`, `<`, `>=`, `<=`, `==` e `!=`.
- Comentarios com `#`.
- Validacao de blocos por indentacao de 4 espacos.

## Como executar

1. Abra `hel_py.csproj` no Visual Studio 2022.
2. Confira se a carga de trabalho "Desenvolvimento para desktop com .NET" esta instalada.
3. Pressione `F5` ou clique em "Iniciar".
4. Digite um algoritmo Python no editor da esquerda e clique em `Executar hel_py`.

Tambem e possivel compilar pelo terminal:

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

## Exemplo completo

O arquivo `examples/combate_chefe.py` contem um teste mais completo com `if`, `while`, variaveis, parenteses e calculos encadeados.

## Estrutura

- `Form1.cs`: motor de interpretacao e eventos da interface.
- `Form1.Designer.cs`: organizacao visual da IDE.
- `docs/relatorio.tex`: modelo de relatorio academico em LaTeX.
- `examples/demo.py`: codigo de teste para apresentar em sala.
- `examples/combate_chefe.py`: codigo de teste completo para validacao do interpretador.
- `examples/if_else.py`: codigo curto para demonstrar o requisito de `if else`.
