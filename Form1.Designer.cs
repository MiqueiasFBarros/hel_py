namespace hel_py;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        pnlShell = new TableLayoutPanel();
        pnlSidebar = new Panel();
        picLogo = new CirclePictureBox();
        lblAppName = new Label();
        lblAppSubtitle = new Label();
        btnNovo = new Button();
        btnAbrir = new Button();
        btnSalvar = new Button();
        btnSalvarComo = new Button();
        btnExecutar = new Button();
        lblSidebarFooter = new Label();
        pnlWorkspace = new TableLayoutPanel();
        pnlTopo = new Panel();
        lblTitulo = new Label();
        lblDescricao = new Label();
        lblBadge = new Label();
        splitContainer = new SplitContainer();
        pnlEditor = new Panel();
        pnlCodigoArea = new Panel();
        pnlNumerosLinhas = new Panel();
        txtCodigo = new RichTextBox();
        pnlEditorHeader = new Panel();
        lblEditorTitulo = new Label();
        lblEditorMeta = new Label();
        pnlCompilacao = new Panel();
        txtCompilacao = new RichTextBox();
        pnlCompilacaoHeader = new Panel();
        lblCompilacaoTitulo = new Label();
        lblCompilacaoMeta = new Label();
        pnlConsole = new Panel();
        txtConsole = new RichTextBox();
        pnlConsoleHeader = new Panel();
        lblConsoleTitulo = new Label();
        lblConsoleMeta = new Label();
        statusStrip = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        pnlShell.SuspendLayout();
        pnlSidebar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
        pnlWorkspace.SuspendLayout();
        pnlTopo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        pnlEditor.SuspendLayout();
        pnlCodigoArea.SuspendLayout();
        pnlEditorHeader.SuspendLayout();
        pnlCompilacao.SuspendLayout();
        pnlCompilacaoHeader.SuspendLayout();
        pnlConsole.SuspendLayout();
        pnlConsoleHeader.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // pnlShell
        // 
        pnlShell.BackColor = Color.FromArgb(24, 28, 30);
        pnlShell.ColumnCount = 2;
        pnlShell.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 214F));
        pnlShell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        pnlShell.Controls.Add(pnlSidebar, 0, 0);
        pnlShell.Controls.Add(pnlWorkspace, 1, 0);
        pnlShell.Dock = DockStyle.Fill;
        pnlShell.Location = new Point(0, 0);
        pnlShell.Name = "pnlShell";
        pnlShell.RowCount = 1;
        pnlShell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        pnlShell.Size = new Size(1180, 760);
        pnlShell.TabIndex = 0;
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(34, 39, 41);
        pnlSidebar.Controls.Add(picLogo);
        pnlSidebar.Controls.Add(lblAppName);
        pnlSidebar.Controls.Add(lblAppSubtitle);
        pnlSidebar.Controls.Add(btnNovo);
        pnlSidebar.Controls.Add(btnAbrir);
        pnlSidebar.Controls.Add(btnSalvar);
        pnlSidebar.Controls.Add(btnSalvarComo);
        pnlSidebar.Controls.Add(btnExecutar);
        pnlSidebar.Controls.Add(lblSidebarFooter);
        pnlSidebar.Dock = DockStyle.Fill;
        pnlSidebar.Location = new Point(14, 14);
        pnlSidebar.Margin = new Padding(14, 14, 8, 14);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Padding = new Padding(18);
        pnlSidebar.Size = new Size(192, 732);
        pnlSidebar.TabIndex = 0;
        // 
        // picLogo
        // 
        picLogo.BackColor = Color.FromArgb(34, 39, 41);
        picLogo.BorderColor = Color.FromArgb(255, 140, 0);
        picLogo.BorderThickness = 0;
        picLogo.Location = new Point(56, 26);
        picLogo.Name = "picLogo";
        picLogo.Size = new Size(80, 80);
        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
        picLogo.TabIndex = 0;
        picLogo.TabStop = false;
        // 
        // lblAppName
        // 
        lblAppName.AutoSize = true;
        lblAppName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblAppName.ForeColor = Color.FromArgb(255, 140, 0);
        lblAppName.Location = new Point(42, 122);
        lblAppName.Name = "lblAppName";
        lblAppName.Size = new Size(99, 37);
        lblAppName.TabIndex = 1;
        lblAppName.Text = "hel_py";
        // 
        // lblAppSubtitle
        // 
        lblAppSubtitle.Font = new Font("Segoe UI", 8.75F);
        lblAppSubtitle.ForeColor = Color.FromArgb(210, 213, 214);
        lblAppSubtitle.Location = new Point(22, 164);
        lblAppSubtitle.Name = "lblAppSubtitle";
        lblAppSubtitle.Size = new Size(150, 44);
        lblAppSubtitle.TabIndex = 2;
        lblAppSubtitle.Text = "IDE visual para interpretar Python didatico";
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Color.FromArgb(43, 49, 52);
        btnNovo.Cursor = Cursors.Hand;
        btnNovo.FlatAppearance.BorderColor = Color.FromArgb(60, 68, 70);
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnNovo.ForeColor = Color.FromArgb(244, 246, 247);
        btnNovo.Location = new Point(18, 246);
        btnNovo.Name = "btnNovo";
        btnNovo.Padding = new Padding(18, 0, 0, 0);
        btnNovo.Size = new Size(156, 40);
        btnNovo.TabIndex = 3;
        btnNovo.Text = "Novo arquivo";
        btnNovo.TextAlign = ContentAlignment.MiddleLeft;
        btnNovo.UseVisualStyleBackColor = false;
        btnNovo.Click += btnNovo_Click;
        // 
        // btnAbrir
        // 
        btnAbrir.BackColor = Color.FromArgb(43, 49, 52);
        btnAbrir.Cursor = Cursors.Hand;
        btnAbrir.FlatAppearance.BorderColor = Color.FromArgb(60, 68, 70);
        btnAbrir.FlatStyle = FlatStyle.Flat;
        btnAbrir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnAbrir.ForeColor = Color.FromArgb(244, 246, 247);
        btnAbrir.Location = new Point(18, 294);
        btnAbrir.Name = "btnAbrir";
        btnAbrir.Padding = new Padding(18, 0, 0, 0);
        btnAbrir.Size = new Size(156, 40);
        btnAbrir.TabIndex = 4;
        btnAbrir.Text = "Abrir .py";
        btnAbrir.TextAlign = ContentAlignment.MiddleLeft;
        btnAbrir.UseVisualStyleBackColor = false;
        btnAbrir.Click += btnAbrir_Click;
        // 
        // btnSalvar
        // 
        btnSalvar.BackColor = Color.FromArgb(43, 49, 52);
        btnSalvar.Cursor = Cursors.Hand;
        btnSalvar.FlatAppearance.BorderColor = Color.FromArgb(60, 68, 70);
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSalvar.ForeColor = Color.FromArgb(244, 246, 247);
        btnSalvar.Location = new Point(18, 342);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Padding = new Padding(18, 0, 0, 0);
        btnSalvar.Size = new Size(156, 40);
        btnSalvar.TabIndex = 5;
        btnSalvar.Text = "Salvar";
        btnSalvar.TextAlign = ContentAlignment.MiddleLeft;
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += btnSalvar_Click;
        // 
        // btnSalvarComo
        // 
        btnSalvarComo.BackColor = Color.FromArgb(43, 49, 52);
        btnSalvarComo.Cursor = Cursors.Hand;
        btnSalvarComo.FlatAppearance.BorderColor = Color.FromArgb(60, 68, 70);
        btnSalvarComo.FlatStyle = FlatStyle.Flat;
        btnSalvarComo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnSalvarComo.ForeColor = Color.FromArgb(244, 246, 247);
        btnSalvarComo.Location = new Point(18, 390);
        btnSalvarComo.Name = "btnSalvarComo";
        btnSalvarComo.Padding = new Padding(18, 0, 0, 0);
        btnSalvarComo.Size = new Size(156, 40);
        btnSalvarComo.TabIndex = 6;
        btnSalvarComo.Text = "Salvar como";
        btnSalvarComo.TextAlign = ContentAlignment.MiddleLeft;
        btnSalvarComo.UseVisualStyleBackColor = false;
        btnSalvarComo.Click += btnSalvarComo_Click;
        // 
        // btnExecutar
        // 
        btnExecutar.BackColor = Color.FromArgb(255, 140, 0);
        btnExecutar.Cursor = Cursors.Hand;
        btnExecutar.FlatAppearance.BorderSize = 0;
        btnExecutar.FlatStyle = FlatStyle.Flat;
        btnExecutar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnExecutar.ForeColor = Color.FromArgb(35, 40, 42);
        btnExecutar.Location = new Point(18, 464);
        btnExecutar.Name = "btnExecutar";
        btnExecutar.Padding = new Padding(18, 0, 0, 0);
        btnExecutar.Size = new Size(156, 48);
        btnExecutar.TabIndex = 7;
        btnExecutar.Text = "Executar hel_py";
        btnExecutar.TextAlign = ContentAlignment.MiddleLeft;
        btnExecutar.UseVisualStyleBackColor = false;
        btnExecutar.Click += btnExecutar_Click;
        // 
        // lblSidebarFooter
        // 
        lblSidebarFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblSidebarFooter.Font = new Font("Segoe UI", 8.5F);
        lblSidebarFooter.ForeColor = Color.FromArgb(174, 179, 181);
        lblSidebarFooter.Location = new Point(20, 690);
        lblSidebarFooter.Name = "lblSidebarFooter";
        lblSidebarFooter.Size = new Size(148, 44);
        lblSidebarFooter.TabIndex = 8;
        lblSidebarFooter.Text = "Windows Forms + C#\nProjeto AV2";
        lblSidebarFooter.Click += lblSidebarFooter_Click;
        // 
        // pnlWorkspace
        // 
        pnlWorkspace.ColumnCount = 1;
        pnlWorkspace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        pnlWorkspace.Controls.Add(pnlTopo, 0, 0);
        pnlWorkspace.Controls.Add(splitContainer, 0, 1);
        pnlWorkspace.Controls.Add(pnlCompilacao, 0, 2);
        pnlWorkspace.Controls.Add(statusStrip, 0, 3);
        pnlWorkspace.Dock = DockStyle.Fill;
        pnlWorkspace.Location = new Point(214, 0);
        pnlWorkspace.Margin = new Padding(0);
        pnlWorkspace.Name = "pnlWorkspace";
        pnlWorkspace.Padding = new Padding(14, 14, 18, 12);
        pnlWorkspace.RowCount = 4;
        pnlWorkspace.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
        pnlWorkspace.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        pnlWorkspace.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
        pnlWorkspace.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        pnlWorkspace.Size = new Size(966, 760);
        pnlWorkspace.TabIndex = 1;
        // 
        // pnlTopo
        // 
        pnlTopo.BackColor = Color.FromArgb(31, 36, 38);
        pnlTopo.Controls.Add(lblTitulo);
        pnlTopo.Controls.Add(lblDescricao);
        pnlTopo.Controls.Add(lblBadge);
        pnlTopo.Dock = DockStyle.Fill;
        pnlTopo.Location = new Point(14, 14);
        pnlTopo.Margin = new Padding(0);
        pnlTopo.Name = "pnlTopo";
        pnlTopo.Size = new Size(934, 86);
        pnlTopo.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(255, 140, 0);
        lblTitulo.Location = new Point(20, 12);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(244, 36);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "hel_py - Sem titulo";
        // 
        // lblDescricao
        // 
        lblDescricao.AutoSize = true;
        lblDescricao.Font = new Font("Segoe UI", 10F);
        lblDescricao.ForeColor = Color.FromArgb(210, 213, 214);
        lblDescricao.Location = new Point(22, 50);
        lblDescricao.Name = "lblDescricao";
        lblDescricao.Size = new Size(354, 19);
        lblDescricao.TabIndex = 1;
        lblDescricao.Text = "Escreva, salve e execute scripts Python dentro do hel_py.";
        // 
        // lblBadge
        // 
        lblBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblBadge.BackColor = Color.FromArgb(31, 36, 38);
        lblBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBadge.ForeColor = Color.FromArgb(255, 179, 71);
        lblBadge.Location = new Point(768, 18);
        lblBadge.Name = "lblBadge";
        lblBadge.Size = new Size(146, 30);
        lblBadge.TabIndex = 2;
        lblBadge.Text = ".py interpreter";
        lblBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // splitContainer
        // 
        splitContainer.BackColor = Color.FromArgb(24, 28, 30);
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(14, 108);
        splitContainer.Margin = new Padding(0, 8, 0, 10);
        splitContainer.Name = "splitContainer";
        // 
        // splitContainer.Panel1
        // 
        splitContainer.Panel1.Controls.Add(pnlEditor);
        splitContainer.Panel1.Padding = new Padding(0, 0, 10, 0);
        // 
        // splitContainer.Panel2
        // 
        splitContainer.Panel2.Controls.Add(pnlConsole);
        splitContainer.Panel2.Padding = new Padding(10, 0, 0, 0);
        splitContainer.Size = new Size(934, 426);
        splitContainer.SplitterDistance = 588;
        splitContainer.SplitterWidth = 1;
        splitContainer.TabIndex = 1;
        // 
        // pnlEditor
        // 
        pnlEditor.BackColor = Color.FromArgb(31, 36, 38);
        pnlEditor.Controls.Add(pnlCodigoArea);
        pnlEditor.Controls.Add(pnlEditorHeader);
        pnlEditor.Dock = DockStyle.Fill;
        pnlEditor.Location = new Point(0, 0);
        pnlEditor.Name = "pnlEditor";
        pnlEditor.Padding = new Padding(1);
        pnlEditor.Size = new Size(578, 426);
        pnlEditor.TabIndex = 0;
        // 
        // pnlEditorHeader
        // 
        pnlEditorHeader.BackColor = Color.FromArgb(31, 36, 38);
        pnlEditorHeader.Controls.Add(lblEditorTitulo);
        pnlEditorHeader.Controls.Add(lblEditorMeta);
        pnlEditorHeader.Dock = DockStyle.Top;
        pnlEditorHeader.Location = new Point(1, 1);
        pnlEditorHeader.Name = "pnlEditorHeader";
        pnlEditorHeader.Size = new Size(576, 42);
        pnlEditorHeader.TabIndex = 0;
        // 
        // lblEditorTitulo
        // 
        lblEditorTitulo.AutoSize = true;
        lblEditorTitulo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblEditorTitulo.ForeColor = Color.FromArgb(244, 246, 247);
        lblEditorTitulo.Location = new Point(16, 11);
        lblEditorTitulo.Name = "lblEditorTitulo";
        lblEditorTitulo.Size = new Size(121, 19);
        lblEditorTitulo.TabIndex = 0;
        lblEditorTitulo.Text = "Editor de codigo";
        // 
        // lblEditorMeta
        // 
        lblEditorMeta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblEditorMeta.Font = new Font("Segoe UI", 9F);
        lblEditorMeta.ForeColor = Color.FromArgb(255, 179, 71);
        lblEditorMeta.Location = new Point(411, 12);
        lblEditorMeta.Name = "lblEditorMeta";
        lblEditorMeta.Size = new Size(150, 18);
        lblEditorMeta.TabIndex = 1;
        lblEditorMeta.Text = "Python subset";
        lblEditorMeta.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlCodigoArea
        // 
        pnlCodigoArea.BackColor = Color.FromArgb(22, 26, 28);
        pnlCodigoArea.Controls.Add(txtCodigo);
        pnlCodigoArea.Controls.Add(pnlNumerosLinhas);
        pnlCodigoArea.Dock = DockStyle.Fill;
        pnlCodigoArea.Location = new Point(1, 43);
        pnlCodigoArea.Name = "pnlCodigoArea";
        pnlCodigoArea.Size = new Size(576, 382);
        pnlCodigoArea.TabIndex = 1;
        // 
        // pnlNumerosLinhas
        // 
        pnlNumerosLinhas.BackColor = Color.FromArgb(18, 22, 24);
        pnlNumerosLinhas.Dock = DockStyle.Left;
        pnlNumerosLinhas.Location = new Point(0, 0);
        pnlNumerosLinhas.Name = "pnlNumerosLinhas";
        pnlNumerosLinhas.Size = new Size(48, 382);
        pnlNumerosLinhas.TabIndex = 0;
        // 
        // txtCodigo
        // 
        txtCodigo.AcceptsTab = true;
        txtCodigo.BackColor = Color.FromArgb(22, 26, 28);
        txtCodigo.BorderStyle = BorderStyle.None;
        txtCodigo.Dock = DockStyle.Fill;
        txtCodigo.Font = new Font("Cascadia Mono", 10.5F);
        txtCodigo.ForeColor = Color.FromArgb(244, 246, 247);
        txtCodigo.Location = new Point(48, 0);
        txtCodigo.Name = "txtCodigo";
        txtCodigo.Size = new Size(528, 382);
        txtCodigo.TabIndex = 1;
        txtCodigo.Text = resources.GetString("txtCodigo.Text");
        txtCodigo.WordWrap = false;
        // 
        // pnlCompilacao
        // 
        pnlCompilacao.BackColor = Color.FromArgb(31, 36, 38);
        pnlCompilacao.Controls.Add(txtCompilacao);
        pnlCompilacao.Controls.Add(pnlCompilacaoHeader);
        pnlCompilacao.Dock = DockStyle.Fill;
        pnlCompilacao.Location = new Point(14, 534);
        pnlCompilacao.Margin = new Padding(0, 0, 0, 10);
        pnlCompilacao.Name = "pnlCompilacao";
        pnlCompilacao.Padding = new Padding(1);
        pnlCompilacao.Size = new Size(934, 160);
        pnlCompilacao.TabIndex = 0;
        // 
        // txtCompilacao
        // 
        txtCompilacao.BackColor = Color.FromArgb(22, 26, 28);
        txtCompilacao.BorderStyle = BorderStyle.None;
        txtCompilacao.Dock = DockStyle.Fill;
        txtCompilacao.Font = new Font("Cascadia Mono", 9.5F);
        txtCompilacao.ForeColor = Color.FromArgb(244, 246, 247);
        txtCompilacao.Location = new Point(1, 43);
        txtCompilacao.Name = "txtCompilacao";
        txtCompilacao.ReadOnly = true;
        txtCompilacao.Size = new Size(932, 116);
        txtCompilacao.TabIndex = 1;
        txtCompilacao.Text = "";
        txtCompilacao.WordWrap = false;
        // 
        // pnlCompilacaoHeader
        // 
        pnlCompilacaoHeader.BackColor = Color.FromArgb(31, 36, 38);
        pnlCompilacaoHeader.Controls.Add(lblCompilacaoTitulo);
        pnlCompilacaoHeader.Controls.Add(lblCompilacaoMeta);
        pnlCompilacaoHeader.Dock = DockStyle.Top;
        pnlCompilacaoHeader.Location = new Point(1, 1);
        pnlCompilacaoHeader.Name = "pnlCompilacaoHeader";
        pnlCompilacaoHeader.Size = new Size(932, 42);
        pnlCompilacaoHeader.TabIndex = 0;
        // 
        // lblCompilacaoTitulo
        // 
        lblCompilacaoTitulo.AutoSize = true;
        lblCompilacaoTitulo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblCompilacaoTitulo.ForeColor = Color.FromArgb(244, 246, 247);
        lblCompilacaoTitulo.Location = new Point(16, 11);
        lblCompilacaoTitulo.Name = "lblCompilacaoTitulo";
        lblCompilacaoTitulo.Size = new Size(143, 19);
        lblCompilacaoTitulo.TabIndex = 0;
        lblCompilacaoTitulo.Text = "Codigo intermediario";
        // 
        // lblCompilacaoMeta
        // 
        lblCompilacaoMeta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblCompilacaoMeta.Font = new Font("Segoe UI", 9F);
        lblCompilacaoMeta.ForeColor = Color.FromArgb(255, 179, 71);
        lblCompilacaoMeta.Location = new Point(816, 12);
        lblCompilacaoMeta.Name = "lblCompilacaoMeta";
        lblCompilacaoMeta.Size = new Size(114, 18);
        lblCompilacaoMeta.TabIndex = 1;
        lblCompilacaoMeta.Text = "aguardando";
        lblCompilacaoMeta.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlConsole
        // 
        pnlConsole.BackColor = Color.FromArgb(31, 36, 38);
        pnlConsole.Controls.Add(txtConsole);
        pnlConsole.Controls.Add(pnlConsoleHeader);
        pnlConsole.Dock = DockStyle.Fill;
        pnlConsole.Location = new Point(10, 0);
        pnlConsole.Name = "pnlConsole";
        pnlConsole.Padding = new Padding(1);
        pnlConsole.Size = new Size(335, 426);
        pnlConsole.TabIndex = 0;
        // 
        // txtConsole
        // 
        txtConsole.BackColor = Color.FromArgb(22, 26, 28);
        txtConsole.BorderStyle = BorderStyle.None;
        txtConsole.Dock = DockStyle.Fill;
        txtConsole.Font = new Font("Cascadia Mono", 10.5F);
        txtConsole.ForeColor = Color.FromArgb(255, 179, 71);
        txtConsole.Location = new Point(1, 43);
        txtConsole.Name = "txtConsole";
        txtConsole.ReadOnly = true;
        txtConsole.Size = new Size(333, 382);
        txtConsole.TabIndex = 1;
        txtConsole.Text = "";
        txtConsole.WordWrap = false;
        // 
        // pnlConsoleHeader
        // 
        pnlConsoleHeader.BackColor = Color.FromArgb(31, 36, 38);
        pnlConsoleHeader.Controls.Add(lblConsoleTitulo);
        pnlConsoleHeader.Controls.Add(lblConsoleMeta);
        pnlConsoleHeader.Dock = DockStyle.Top;
        pnlConsoleHeader.Location = new Point(1, 1);
        pnlConsoleHeader.Name = "pnlConsoleHeader";
        pnlConsoleHeader.Size = new Size(333, 42);
        pnlConsoleHeader.TabIndex = 0;
        // 
        // lblConsoleTitulo
        // 
        lblConsoleTitulo.AutoSize = true;
        lblConsoleTitulo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblConsoleTitulo.ForeColor = Color.FromArgb(244, 246, 247);
        lblConsoleTitulo.Location = new Point(16, 11);
        lblConsoleTitulo.Name = "lblConsoleTitulo";
        lblConsoleTitulo.Size = new Size(109, 19);
        lblConsoleTitulo.TabIndex = 0;
        lblConsoleTitulo.Text = "Console hel_py";
        // 
        // lblConsoleMeta
        // 
        lblConsoleMeta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblConsoleMeta.Font = new Font("Segoe UI", 9F);
        lblConsoleMeta.ForeColor = Color.FromArgb(255, 179, 71);
        lblConsoleMeta.Location = new Point(203, 12);
        lblConsoleMeta.Name = "lblConsoleMeta";
        lblConsoleMeta.Size = new Size(114, 18);
        lblConsoleMeta.TabIndex = 1;
        lblConsoleMeta.Text = "pronto";
        lblConsoleMeta.TextAlign = ContentAlignment.MiddleRight;
        // 
        // statusStrip
        // 
        statusStrip.BackColor = Color.FromArgb(24, 28, 30);
        statusStrip.Dock = DockStyle.Fill;
        statusStrip.GripMargin = new Padding(0);
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip.Location = new Point(14, 714);
        statusStrip.Name = "statusStrip";
        statusStrip.Padding = new Padding(0);
        statusStrip.Size = new Size(934, 34);
        statusStrip.SizingGrip = false;
        statusStrip.TabIndex = 2;
        // 
        // lblStatus
        // 
        lblStatus.ForeColor = Color.FromArgb(210, 213, 214);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(197, 29);
        lblStatus.Text = "Pronto para executar scripts Python.";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(24, 28, 30);
        ClientSize = new Size(1180, 760);
        Controls.Add(pnlShell);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(1040, 660);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "hel_py";
        WindowState = FormWindowState.Maximized;
        pnlShell.ResumeLayout(false);
        pnlSidebar.ResumeLayout(false);
        pnlSidebar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
        pnlWorkspace.ResumeLayout(false);
        pnlWorkspace.PerformLayout();
        pnlTopo.ResumeLayout(false);
        pnlTopo.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        pnlEditor.ResumeLayout(false);
        pnlCodigoArea.ResumeLayout(false);
        pnlEditorHeader.ResumeLayout(false);
        pnlEditorHeader.PerformLayout();
        pnlCompilacao.ResumeLayout(false);
        pnlCompilacaoHeader.ResumeLayout(false);
        pnlCompilacaoHeader.PerformLayout();
        pnlConsole.ResumeLayout(false);
        pnlConsoleHeader.ResumeLayout(false);
        pnlConsoleHeader.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel pnlShell;
    private Panel pnlSidebar;
    private CirclePictureBox picLogo;
    private Label lblAppName;
    private Label lblAppSubtitle;
    private Button btnNovo;
    private Button btnAbrir;
    private Button btnSalvar;
    private Button btnSalvarComo;
    private Button btnExecutar;
    private Label lblSidebarFooter;
    private TableLayoutPanel pnlWorkspace;
    private Panel pnlTopo;
    private Label lblTitulo;
    private Label lblDescricao;
    private Label lblBadge;
    private SplitContainer splitContainer;
    private Panel pnlEditor;
    private Panel pnlCodigoArea;
    private Panel pnlNumerosLinhas;
    private Panel pnlEditorHeader;
    private Label lblEditorTitulo;
    private Label lblEditorMeta;
    private RichTextBox txtCodigo;
    private Panel pnlCompilacao;
    private Panel pnlCompilacaoHeader;
    private Label lblCompilacaoTitulo;
    private Label lblCompilacaoMeta;
    private RichTextBox txtCompilacao;
    private Panel pnlConsole;
    private Panel pnlConsoleHeader;
    private Label lblConsoleTitulo;
    private Label lblConsoleMeta;
    private RichTextBox txtConsole;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatus;
}
