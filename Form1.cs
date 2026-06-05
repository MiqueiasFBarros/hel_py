using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace hel_py;

public partial class Form1 : Form
{
    private readonly Dictionary<string, double> tabelaVariaveis = new(StringComparer.OrdinalIgnoreCase);
    private const int LimiteIteracoesWhile = 10000;
    private const int WmSetRedraw = 0x000B;
    private bool aplicandoRealceSintaxe;
    private string? arquivoAtual;
    private int contadorRotulos;

    public Form1()
    {
        InitializeComponent();
        CarregarLogo();
        txtCodigo.TextChanged += txtCodigo_TextChanged;
        txtCodigo.VScroll += (_, _) => pnlNumerosLinhas.Invalidate();
        txtCodigo.Resize += (_, _) => pnlNumerosLinhas.Invalidate();
        pnlNumerosLinhas.Paint += pnlNumerosLinhas_Paint;
        AtualizarTitulo();
        pnlNumerosLinhas.Invalidate();
        AplicarRealceSintaxe();
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    private void btnNovo_Click(object? sender, EventArgs e)
    {
        txtCodigo.Clear();
        txtConsole.Clear();
        txtCompilacao.Clear();
        arquivoAtual = null;
        AtualizarTitulo();
        lblStatus.Text = "Novo arquivo criado.";
        lblConsoleMeta.Text = "pronto";
        lblConsoleMeta.ForeColor = Color.FromArgb(255, 179, 71);
        lblCompilacaoMeta.Text = "aguardando";
        lblCompilacaoMeta.ForeColor = Color.FromArgb(255, 179, 71);
        txtCodigo.Focus();
    }

    private void btnAbrir_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new()
        {
            Title = "Abrir arquivo Python",
            Filter = "Arquivos Python (*.py)|*.py|Todos os arquivos (*.*)|*.*",
            DefaultExt = "py"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        txtCodigo.Text = File.ReadAllText(dialog.FileName, Encoding.UTF8);
        AplicarRealceSintaxe();
        arquivoAtual = dialog.FileName;
        txtConsole.Clear();
        txtCompilacao.Clear();
        AtualizarTitulo();
        lblStatus.Text = $"Arquivo aberto: {Path.GetFileName(dialog.FileName)}";
        lblConsoleMeta.Text = "pronto";
        lblConsoleMeta.ForeColor = Color.FromArgb(255, 179, 71);
        lblCompilacaoMeta.Text = "aguardando";
        lblCompilacaoMeta.ForeColor = Color.FromArgb(255, 179, 71);
    }

    private void btnSalvar_Click(object? sender, EventArgs e)
    {
        SalvarArquivo(arquivoAtual);
    }

    private void btnSalvarComo_Click(object? sender, EventArgs e)
    {
        SalvarArquivo(null);
    }

    private void txtCodigo_TextChanged(object? sender, EventArgs e)
    {
        AplicarRealceSintaxe();
        pnlNumerosLinhas.Invalidate();
    }

    private void pnlNumerosLinhas_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.Clear(pnlNumerosLinhas.BackColor);

        int primeiroCaractere = txtCodigo.GetCharIndexFromPosition(new Point(0, 0));
        int primeiraLinha = txtCodigo.GetLineFromCharIndex(primeiroCaractere);
        int ultimoCaractere = txtCodigo.GetCharIndexFromPosition(new Point(0, txtCodigo.ClientSize.Height));
        int ultimaLinha = txtCodigo.GetLineFromCharIndex(ultimoCaractere);

        using SolidBrush pincel = new(Color.FromArgb(132, 142, 145));
        using StringFormat formato = new()
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Near
        };

        for (int linha = primeiraLinha; linha <= ultimaLinha + 1 && linha < txtCodigo.Lines.Length; linha++)
        {
            int primeiroIndiceDaLinha = txtCodigo.GetFirstCharIndexFromLine(linha);
            if (primeiroIndiceDaLinha < 0)
            {
                continue;
            }

            Point posicao = txtCodigo.GetPositionFromCharIndex(primeiroIndiceDaLinha);
            Rectangle area = new(0, posicao.Y + 1, pnlNumerosLinhas.Width - 8, txtCodigo.Font.Height);
            e.Graphics.DrawString((linha + 1).ToString(CultureInfo.InvariantCulture), txtCodigo.Font, pincel, area, formato);
        }
    }

    private void btnExecutar_Click(object? sender, EventArgs e)
    {
        txtConsole.Clear();
        txtCompilacao.Clear();
        tabelaVariaveis.Clear();
        lblStatus.Text = "Compilando script...";
        lblCompilacaoMeta.Text = "compilando";
        lblCompilacaoMeta.ForeColor = Color.FromArgb(255, 179, 71);
        lblConsoleMeta.Text = "executando";
        lblConsoleMeta.ForeColor = Color.FromArgb(255, 179, 71);

        string[] linhas = txtCodigo.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        try
        {
            txtCompilacao.Text = CompilarCodigoIntermediario(linhas);
            lblCompilacaoMeta.Text = "compilado";
            lblStatus.Text = "Executando codigo intermediario...";

            InterpretarBloco(linhas, 0, linhas.Length, 0);
            txtConsole.AppendText($"{Environment.NewLine}[hel_py]: Programa finalizado com sucesso.{Environment.NewLine}");
            lblStatus.Text = "Execucao finalizada com sucesso.";
            lblConsoleMeta.Text = "sucesso";
            lblConsoleMeta.ForeColor = Color.FromArgb(255, 179, 71);
        }
        catch (Exception ex)
        {
            if (txtCompilacao.TextLength == 0)
            {
                txtCompilacao.AppendText($"[Erro de Compilacao hel_py]: {ex.Message}{Environment.NewLine}");
                lblCompilacaoMeta.Text = "erro";
                lblCompilacaoMeta.ForeColor = Color.FromArgb(255, 96, 96);
            }

            txtConsole.AppendText($"[Erro de Runtime hel_py]: {ex.Message}{Environment.NewLine}");
            lblStatus.Text = "Execucao interrompida por erro.";
            lblConsoleMeta.Text = "erro";
            lblConsoleMeta.ForeColor = Color.FromArgb(255, 96, 96);
        }
    }

    private void SalvarArquivo(string? caminho)
    {
        if (string.IsNullOrWhiteSpace(caminho))
        {
            using SaveFileDialog dialog = new()
            {
                Title = "Salvar arquivo Python",
                Filter = "Arquivos Python (*.py)|*.py|Todos os arquivos (*.*)|*.*",
                DefaultExt = "py",
                AddExtension = true,
                FileName = "programa.py"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            caminho = dialog.FileName;
        }

        File.WriteAllText(caminho, txtCodigo.Text, Encoding.UTF8);
        arquivoAtual = caminho;
        AtualizarTitulo();
        txtConsole.AppendText($"[hel_py]: Arquivo salvo em {caminho}{Environment.NewLine}");
        lblStatus.Text = $"Arquivo salvo: {Path.GetFileName(caminho)}";
    }

    private void AtualizarTitulo()
    {
        string nomeArquivo = arquivoAtual is null ? "Sem titulo" : Path.GetFileName(arquivoAtual);
        Text = $"hel_py - {nomeArquivo}";
        lblTitulo.Text = $"hel_py - {nomeArquivo}";
    }

    private void CarregarLogo()
    {
        string caminhoIcone = Path.Combine(AppContext.BaseDirectory, "Assets", "app.ico");
        if (File.Exists(caminhoIcone))
        {
            Icon = new Icon(caminhoIcone);
        }

        string caminhoLogo = Path.Combine(AppContext.BaseDirectory, "Assets", "logo-circle.png");
        if (File.Exists(caminhoLogo))
        {
            picLogo.Image = Image.FromFile(caminhoLogo);
        }
    }

    private string CompilarCodigoIntermediario(string[] linhas)
    {
        contadorRotulos = 0;
        StringBuilder codigo = new();

        codigo.AppendLine("; codigo intermediario gerado pelo hel_py");
        codigo.AppendLine("INICIO_PROGRAMA");
        CompilarBloco(linhas, 0, linhas.Length, 0, codigo);
        codigo.AppendLine("FIM_PROGRAMA");

        return codigo.ToString();
    }

    private void CompilarBloco(string[] linhas, int inicio, int fim, int indentacaoEsperada, StringBuilder codigo)
    {
        int i = inicio;

        while (i < fim)
        {
            string originalLine = linhas[i];
            if (string.IsNullOrWhiteSpace(originalLine))
            {
                i++;
                continue;
            }

            int indentacaoReal = CalcularIndentacao(originalLine);
            string linha = RemoverComentario(originalLine.Trim());

            if (string.IsNullOrWhiteSpace(linha))
            {
                i++;
                continue;
            }

            if (indentacaoReal < indentacaoEsperada)
            {
                return;
            }

            if (indentacaoReal > indentacaoEsperada)
            {
                throw new InvalidOperationException($"Indentacao inesperada na linha {i + 1}. Use blocos com 4 espacos.");
            }

            if (linha.StartsWith("if ", StringComparison.Ordinal) && linha.EndsWith(':'))
            {
                string condicao = linha[3..^1].Trim();
                int fimDoBlocoIf = EncontrarFimDoBloco(linhas, i + 1, indentacaoReal + 4);
                int linhaElse = EncontrarElseDoIf(linhas, fimDoBlocoIf, indentacaoReal);
                int fimDoBlocoElse = linhaElse >= 0
                    ? EncontrarFimDoBloco(linhas, linhaElse + 1, indentacaoReal + 4)
                    : fimDoBlocoIf;

                string rotuloFalso = NovoRotulo(linhaElse >= 0 ? "else" : "fim_if");
                string rotuloFim = linhaElse >= 0 ? NovoRotulo("fim_if") : rotuloFalso;

                codigo.AppendLine($"IF_FALSE {condicao} GOTO {rotuloFalso}");
                CompilarBloco(linhas, i + 1, fimDoBlocoIf, indentacaoReal + 4, codigo);

                if (linhaElse >= 0)
                {
                    codigo.AppendLine($"GOTO {rotuloFim}");
                    codigo.AppendLine($"LABEL {rotuloFalso}");
                    CompilarBloco(linhas, linhaElse + 1, fimDoBlocoElse, indentacaoReal + 4, codigo);
                }

                codigo.AppendLine($"LABEL {rotuloFim}");

                i = fimDoBlocoElse;
                continue;
            }

            if (linha == "else:")
            {
                throw new InvalidOperationException($"Comando else sem if correspondente na linha {i + 1}.");
            }

            if (linha.StartsWith("while ", StringComparison.Ordinal) && linha.EndsWith(':'))
            {
                string condicao = linha[6..^1].Trim();
                int fimDoBlocoWhile = EncontrarFimDoBloco(linhas, i + 1, indentacaoReal + 4);
                string rotuloInicio = NovoRotulo("while");
                string rotuloFim = NovoRotulo("fim_while");

                codigo.AppendLine($"LABEL {rotuloInicio}");
                codigo.AppendLine($"IF_FALSE {condicao} GOTO {rotuloFim}");
                CompilarBloco(linhas, i + 1, fimDoBlocoWhile, indentacaoReal + 4, codigo);
                codigo.AppendLine($"GOTO {rotuloInicio}");
                codigo.AppendLine($"LABEL {rotuloFim}");

                i = fimDoBlocoWhile;
                continue;
            }

            if (linha.StartsWith("print(", StringComparison.Ordinal) && linha.EndsWith(')'))
            {
                string conteudo = linha[6..^1].Trim();
                codigo.AppendLine($"PRINT {conteudo}");
                i++;
                continue;
            }

            if (EhAtribuicao(linha))
            {
                string[] partes = linha.Split('=', 2);
                string nome = partes[0].Trim();
                string expressao = partes[1].Trim();

                if (!EhIdentificadorValido(nome))
                {
                    throw new InvalidOperationException($"Nome de variavel invalido na linha {i + 1}: {nome}");
                }

                codigo.AppendLine($"SET {nome}, {expressao}");
                i++;
                continue;
            }

            throw new InvalidOperationException($"Comando nao reconhecido na linha {i + 1}: {linha}");
        }
    }

    private string NovoRotulo(string prefixo)
    {
        contadorRotulos++;
        return $"{prefixo}_{contadorRotulos}";
    }

    private void AplicarRealceSintaxe()
    {
        if (aplicandoRealceSintaxe || txtCodigo.TextLength == 0)
        {
            return;
        }

        aplicandoRealceSintaxe = true;

        int selecaoInicio = txtCodigo.SelectionStart;
        int selecaoTamanho = txtCodigo.SelectionLength;

        SendMessage(txtCodigo.Handle, WmSetRedraw, IntPtr.Zero, IntPtr.Zero);

        txtCodigo.SelectAll();
        txtCodigo.SelectionColor = Color.FromArgb(244, 246, 247);

        Color palavraChave = Color.FromArgb(255, 140, 0);
        Color texto = Color.FromArgb(255, 190, 96);
        Color comentario = Color.FromArgb(132, 142, 145);
        Color numero = Color.FromArgb(255, 214, 140);
        Color funcao = Color.FromArgb(255, 179, 71);

        ColorirRegex(@"\b(if|else|while)\b", palavraChave, RegexOptions.None);
        ColorirRegex(@"\b(print)\b(?=\s*\()", funcao, RegexOptions.None);
        ColorirRegex(@"\b\d+(\.\d+)?\b", numero, RegexOptions.None);
        ColorirRegex("\"([^\"\\\\]|\\\\.)*\"|'([^'\\\\]|\\\\.)*'", texto, RegexOptions.None);
        ColorirRegex(@"#.*$", comentario, RegexOptions.Multiline);

        txtCodigo.Select(selecaoInicio, selecaoTamanho);
        txtCodigo.SelectionColor = Color.FromArgb(244, 246, 247);

        SendMessage(txtCodigo.Handle, WmSetRedraw, new IntPtr(1), IntPtr.Zero);
        txtCodigo.Invalidate();

        aplicandoRealceSintaxe = false;
    }

    private void ColorirRegex(string padrao, Color cor, RegexOptions opcoes)
    {
        foreach (Match match in Regex.Matches(txtCodigo.Text, padrao, opcoes))
        {
            txtCodigo.Select(match.Index, match.Length);
            txtCodigo.SelectionColor = cor;
        }
    }

    private void InterpretarBloco(string[] linhas, int inicio, int fim, int indentacaoEsperada)
    {
        int i = inicio;

        while (i < fim)
        {
            string originalLine = linhas[i];
            if (string.IsNullOrWhiteSpace(originalLine))
            {
                i++;
                continue;
            }

            int indentacaoReal = CalcularIndentacao(originalLine);
            string linha = RemoverComentario(originalLine.Trim());

            if (string.IsNullOrWhiteSpace(linha))
            {
                i++;
                continue;
            }

            if (indentacaoReal < indentacaoEsperada)
            {
                return;
            }

            if (indentacaoReal > indentacaoEsperada)
            {
                throw new InvalidOperationException($"Indentacao inesperada na linha {i + 1}. Use blocos com 4 espacos.");
            }

            if (linha.StartsWith("if ", StringComparison.Ordinal) && linha.EndsWith(':'))
            {
                string condicao = linha[3..^1].Trim();
                int fimDoBlocoIf = EncontrarFimDoBloco(linhas, i + 1, indentacaoReal + 4);
                int linhaElse = EncontrarElseDoIf(linhas, fimDoBlocoIf, indentacaoReal);
                int fimDoBlocoElse = linhaElse >= 0
                    ? EncontrarFimDoBloco(linhas, linhaElse + 1, indentacaoReal + 4)
                    : fimDoBlocoIf;

                if (AvaliarExpressaoBooleana(condicao))
                {
                    InterpretarBloco(linhas, i + 1, fimDoBlocoIf, indentacaoReal + 4);
                }
                else if (linhaElse >= 0)
                {
                    InterpretarBloco(linhas, linhaElse + 1, fimDoBlocoElse, indentacaoReal + 4);
                }

                i = fimDoBlocoElse;
                continue;
            }

            if (linha == "else:")
            {
                throw new InvalidOperationException($"Comando else sem if correspondente na linha {i + 1}.");
            }

            if (linha.StartsWith("while ", StringComparison.Ordinal) && linha.EndsWith(':'))
            {
                string condicao = linha[6..^1].Trim();
                int fimDoBlocoWhile = EncontrarFimDoBloco(linhas, i + 1, indentacaoReal + 4);
                int iteracoes = 0;

                while (AvaliarExpressaoBooleana(condicao))
                {
                    if (++iteracoes > LimiteIteracoesWhile)
                    {
                        throw new InvalidOperationException("Loop while interrompido por limite de seguranca.");
                    }

                    InterpretarBloco(linhas, i + 1, fimDoBlocoWhile, indentacaoReal + 4);
                }

                i = fimDoBlocoWhile;
                continue;
            }

            if (linha.StartsWith("print(", StringComparison.Ordinal) && linha.EndsWith(')'))
            {
                string conteudo = linha[6..^1].Trim();
                txtConsole.AppendText(ObterValorExpressao(conteudo) + Environment.NewLine);
                i++;
                continue;
            }

            if (EhAtribuicao(linha))
            {
                ExecutarAtribuicao(linha, i + 1);
                i++;
                continue;
            }

            throw new InvalidOperationException($"Comando nao reconhecido na linha {i + 1}: {linha}");
        }
    }

    private static int EncontrarFimDoBloco(string[] linhas, int linhaInicial, int indentacaoDoBloco)
    {
        int j = linhaInicial;

        while (j < linhas.Length)
        {
            if (string.IsNullOrWhiteSpace(linhas[j]))
            {
                j++;
                continue;
            }

            string linha = RemoverComentario(linhas[j].Trim());
            if (string.IsNullOrWhiteSpace(linha))
            {
                j++;
                continue;
            }

            int indentacaoReal = CalcularIndentacao(linhas[j]);
            if (indentacaoReal < indentacaoDoBloco)
            {
                return j;
            }

            j++;
        }

        return j;
    }

    private static int EncontrarElseDoIf(string[] linhas, int linhaAposIf, int indentacaoDoIf)
    {
        int j = linhaAposIf;

        while (j < linhas.Length)
        {
            if (string.IsNullOrWhiteSpace(linhas[j]))
            {
                j++;
                continue;
            }

            string linha = RemoverComentario(linhas[j].Trim());
            if (string.IsNullOrWhiteSpace(linha))
            {
                j++;
                continue;
            }

            int indentacaoReal = CalcularIndentacao(linhas[j]);
            if (indentacaoReal != indentacaoDoIf)
            {
                return -1;
            }

            return linha == "else:" ? j : -1;
        }

        return -1;
    }

    private void ExecutarAtribuicao(string linha, int numeroLinha)
    {
        string[] partes = linha.Split('=', 2);
        string nome = partes[0].Trim();
        string expressao = partes[1].Trim();

        if (!EhIdentificadorValido(nome))
        {
            throw new InvalidOperationException($"Nome de variavel invalido na linha {numeroLinha}: {nome}");
        }

        tabelaVariaveis[nome] = AvaliarExpressaoAritmetica(expressao);
    }

    private bool AvaliarExpressaoBooleana(string expressao)
    {
        foreach (string operador in new[] { "==", "!=", ">=", "<=", ">", "<" })
        {
            int posicao = EncontrarOperadorComparacao(expressao, operador);
            if (posicao < 0)
            {
                continue;
            }

            double esquerda = AvaliarExpressaoAritmetica(expressao[..posicao].Trim());
            double direita = AvaliarExpressaoAritmetica(expressao[(posicao + operador.Length)..].Trim());

            return operador switch
            {
                "==" => Math.Abs(esquerda - direita) < 0.000001,
                "!=" => Math.Abs(esquerda - direita) >= 0.000001,
                ">=" => esquerda >= direita,
                "<=" => esquerda <= direita,
                ">" => esquerda > direita,
                "<" => esquerda < direita,
                _ => false
            };
        }

        throw new InvalidOperationException($"Expressao booleana invalida: {expressao}");
    }

    private double AvaliarExpressaoAritmetica(string expressao)
    {
        ExpressionParser parser = new(expressao, tabelaVariaveis);
        return parser.Parse();
    }

    private string ObterValorExpressao(string token)
    {
        if ((token.StartsWith('"') && token.EndsWith('"')) || (token.StartsWith('\'') && token.EndsWith('\'')))
        {
            return token[1..^1];
        }

        return FormatarNumero(AvaliarExpressaoAritmetica(token));
    }

    private static bool EhAtribuicao(string linha)
    {
        int nivelParenteses = 0;
        for (int i = 0; i < linha.Length; i++)
        {
            char c = linha[i];
            if (c == '(')
            {
                nivelParenteses++;
            }
            else if (c == ')')
            {
                nivelParenteses--;
            }
            else if (c == '=' && nivelParenteses == 0)
            {
                bool anteriorComparador = i > 0 && (linha[i - 1] == '=' || linha[i - 1] == '!' || linha[i - 1] == '<' || linha[i - 1] == '>');
                bool proximoComparador = i + 1 < linha.Length && linha[i + 1] == '=';
                return !anteriorComparador && !proximoComparador;
            }
        }

        return false;
    }

    private static int EncontrarOperadorComparacao(string expressao, string operador)
    {
        int nivelParenteses = 0;

        for (int i = 0; i <= expressao.Length - operador.Length; i++)
        {
            char c = expressao[i];
            if (c == '(')
            {
                nivelParenteses++;
                continue;
            }

            if (c == ')')
            {
                nivelParenteses--;
                continue;
            }

            if (nivelParenteses == 0 && expressao.AsSpan(i, operador.Length).SequenceEqual(operador))
            {
                return i;
            }
        }

        return -1;
    }

    private static int CalcularIndentacao(string linha)
    {
        int indentacao = 0;

        foreach (char caractere in linha)
        {
            if (caractere == ' ')
            {
                indentacao++;
                continue;
            }

            if (caractere == '\t')
            {
                indentacao += 4;
                continue;
            }

            break;
        }

        return indentacao;
    }

    private static string RemoverComentario(string linha)
    {
        bool emAspasDuplas = false;
        bool emAspasSimples = false;

        for (int i = 0; i < linha.Length; i++)
        {
            char c = linha[i];
            if (c == '"' && !emAspasSimples)
            {
                emAspasDuplas = !emAspasDuplas;
            }
            else if (c == '\'' && !emAspasDuplas)
            {
                emAspasSimples = !emAspasSimples;
            }
            else if (c == '#' && !emAspasDuplas && !emAspasSimples)
            {
                return linha[..i].TrimEnd();
            }
        }

        return linha;
    }

    private static string FormatarNumero(double valor)
    {
        if (Math.Abs(valor % 1) < 0.000001)
        {
            return ((long)Math.Round(valor)).ToString(CultureInfo.InvariantCulture);
        }

        return valor.ToString("0.######", CultureInfo.InvariantCulture);
    }

    private static bool EhIdentificadorValido(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome) || (!char.IsLetter(nome[0]) && nome[0] != '_'))
        {
            return false;
        }

        return nome.All(c => char.IsLetterOrDigit(c) || c == '_');
    }

    private sealed class ExpressionParser
    {
        private readonly string expressao;
        private readonly Dictionary<string, double> variaveis;
        private int posicao;

        public ExpressionParser(string expressao, Dictionary<string, double> variaveis)
        {
            this.expressao = expressao;
            this.variaveis = variaveis;
        }

        public double Parse()
        {
            double valor = ParseSomaSubtracao();
            PularEspacos();

            if (posicao < expressao.Length)
            {
                throw new InvalidOperationException($"Token inesperado em: {expressao[posicao..]}");
            }

            return valor;
        }

        private double ParseSomaSubtracao()
        {
            double valor = ParseMultiplicacaoDivisao();

            while (true)
            {
                PularEspacos();
                if (Consumir('+'))
                {
                    valor += ParseMultiplicacaoDivisao();
                }
                else if (Consumir('-'))
                {
                    valor -= ParseMultiplicacaoDivisao();
                }
                else
                {
                    return valor;
                }
            }
        }

        private double ParseMultiplicacaoDivisao()
        {
            double valor = ParseFator();

            while (true)
            {
                PularEspacos();
                if (Consumir('*'))
                {
                    valor *= ParseFator();
                }
                else if (Consumir('/'))
                {
                    double divisor = ParseFator();
                    if (Math.Abs(divisor) < 0.000001)
                    {
                        throw new DivideByZeroException("Divisao por zero.");
                    }

                    valor /= divisor;
                }
                else
                {
                    return valor;
                }
            }
        }

        private double ParseFator()
        {
            PularEspacos();

            if (Consumir('+'))
            {
                return ParseFator();
            }

            if (Consumir('-'))
            {
                return -ParseFator();
            }

            if (Consumir('('))
            {
                double valor = ParseSomaSubtracao();
                PularEspacos();

                if (!Consumir(')'))
                {
                    throw new InvalidOperationException($"Parenteses nao fechado em: {expressao}");
                }

                return valor;
            }

            if (posicao < expressao.Length && (char.IsDigit(expressao[posicao]) || expressao[posicao] == '.'))
            {
                return ParseNumero();
            }

            if (posicao < expressao.Length && (char.IsLetter(expressao[posicao]) || expressao[posicao] == '_'))
            {
                string nome = ParseIdentificador();
                if (variaveis.TryGetValue(nome, out double valor))
                {
                    return valor;
                }

                throw new InvalidOperationException($"Variavel nao declarada: {nome}");
            }

            throw new InvalidOperationException($"Expressao invalida: {expressao}");
        }

        private double ParseNumero()
        {
            int inicio = posicao;
            while (posicao < expressao.Length && (char.IsDigit(expressao[posicao]) || expressao[posicao] == '.'))
            {
                posicao++;
            }

            string texto = expressao[inicio..posicao];
            if (double.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out double valor))
            {
                return valor;
            }

            throw new InvalidOperationException($"Numero invalido: {texto}");
        }

        private string ParseIdentificador()
        {
            int inicio = posicao;
            while (posicao < expressao.Length && (char.IsLetterOrDigit(expressao[posicao]) || expressao[posicao] == '_'))
            {
                posicao++;
            }

            return expressao[inicio..posicao];
        }

        private bool Consumir(char caractere)
        {
            PularEspacos();
            if (posicao >= expressao.Length || expressao[posicao] != caractere)
            {
                return false;
            }

            posicao++;
            return true;
        }

        private void PularEspacos()
        {
            while (posicao < expressao.Length && char.IsWhiteSpace(expressao[posicao]))
            {
                posicao++;
            }
        }
    }

    private void lblSidebarFooter_Click(object sender, EventArgs e)
    {

    }
}
