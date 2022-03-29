namespace FBackup
{
    partial class UCConfiguracoes
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCConfiguracoes));
            this.label4 = new System.Windows.Forms.Label();
            this.tbControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.chbxIniciarComOWindows = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbxBuscaAtualizacoesIni = new Guna.UI2.WinForms.Guna2CheckBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExplicacaoFlags = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.nmUpDownDiasExcluirBackupsAntigos = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chbxExcluirBackupsAntigos = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbArgumentosPosBackup = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDiretorioAppPosBackup = new Guna.UI2.WinForms.Guna2TileButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAplicativoPosBackup = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbArgumentosPreBackup = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDiretorioAppPreBackup = new Guna.UI2.WinForms.Guna2TileButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAplicativoPreBackup = new Guna.UI2.WinForms.Guna2TextBox();
            this.lstBoxFlagsBackup = new System.Windows.Forms.CheckedListBox();
            this.btnDiretorioBackups = new Guna.UI2.WinForms.Guna2TileButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDiretorioBackups = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSalvar = new Guna.UI2.WinForms.Guna2TileButton();
            this.bunifuElipseBtnSalvar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnFechar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnDiretorioBackups = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnAppPreBackup = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnAppPosBackup = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tbControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDownDiasExcluirBackupsAntigos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(22, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Configurações Globais";
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.metroTabPage1);
            this.tbControl.Controls.Add(this.metroTabPage2);
            this.tbControl.ItemSize = new System.Drawing.Size(100, 34);
            this.tbControl.Location = new System.Drawing.Point(8, 61);
            this.tbControl.Multiline = true;
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 1;
            this.tbControl.ShowToolTips = true;
            this.tbControl.Size = new System.Drawing.Size(560, 446);
            this.tbControl.TabIndex = 14;
            this.tbControl.UseCustomForeColor = true;
            this.tbControl.UseSelectable = true;
            this.tbControl.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.chbxIniciarComOWindows);
            this.metroTabPage1.Controls.Add(this.chbxBuscaAtualizacoesIni);
            this.metroTabPage1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(552, 404);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Configurações Gerais  ";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // chbxIniciarComOWindows
            // 
            this.chbxIniciarComOWindows.AutoSize = true;
            this.chbxIniciarComOWindows.BackColor = System.Drawing.Color.Transparent;
            this.chbxIniciarComOWindows.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.chbxIniciarComOWindows.CheckedState.BorderRadius = 2;
            this.chbxIniciarComOWindows.CheckedState.BorderThickness = 0;
            this.chbxIniciarComOWindows.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.chbxIniciarComOWindows.Location = new System.Drawing.Point(9, 54);
            this.chbxIniciarComOWindows.Name = "chbxIniciarComOWindows";
            this.chbxIniciarComOWindows.Size = new System.Drawing.Size(143, 17);
            this.chbxIniciarComOWindows.TabIndex = 3;
            this.chbxIniciarComOWindows.Text = "Iniciar com o Windows";
            this.chbxIniciarComOWindows.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbxIniciarComOWindows.UncheckedState.BorderRadius = 2;
            this.chbxIniciarComOWindows.UncheckedState.BorderThickness = 0;
            this.chbxIniciarComOWindows.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbxIniciarComOWindows.UseVisualStyleBackColor = false;
            // 
            // chbxBuscaAtualizacoesIni
            // 
            this.chbxBuscaAtualizacoesIni.AutoSize = true;
            this.chbxBuscaAtualizacoesIni.BackColor = System.Drawing.Color.Transparent;
            this.chbxBuscaAtualizacoesIni.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.chbxBuscaAtualizacoesIni.CheckedState.BorderRadius = 2;
            this.chbxBuscaAtualizacoesIni.CheckedState.BorderThickness = 0;
            this.chbxBuscaAtualizacoesIni.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.chbxBuscaAtualizacoesIni.Enabled = false;
            this.chbxBuscaAtualizacoesIni.Location = new System.Drawing.Point(9, 31);
            this.chbxBuscaAtualizacoesIni.Name = "chbxBuscaAtualizacoesIni";
            this.chbxBuscaAtualizacoesIni.Size = new System.Drawing.Size(289, 17);
            this.chbxBuscaAtualizacoesIni.TabIndex = 2;
            this.chbxBuscaAtualizacoesIni.Text = "Buscar novas atualizações ao iniciar o AutoFBackup";
            this.chbxBuscaAtualizacoesIni.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbxBuscaAtualizacoesIni.UncheckedState.BorderRadius = 2;
            this.chbxBuscaAtualizacoesIni.UncheckedState.BorderThickness = 0;
            this.chbxBuscaAtualizacoesIni.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbxBuscaAtualizacoesIni.UseVisualStyleBackColor = false;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.label2);
            this.metroTabPage2.Controls.Add(this.lblExplicacaoFlags);
            this.metroTabPage2.Controls.Add(this.label8);
            this.metroTabPage2.Controls.Add(this.nmUpDownDiasExcluirBackupsAntigos);
            this.metroTabPage2.Controls.Add(this.chbxExcluirBackupsAntigos);
            this.metroTabPage2.Controls.Add(this.label6);
            this.metroTabPage2.Controls.Add(this.tbArgumentosPosBackup);
            this.metroTabPage2.Controls.Add(this.btnDiretorioAppPosBackup);
            this.metroTabPage2.Controls.Add(this.label7);
            this.metroTabPage2.Controls.Add(this.tbAplicativoPosBackup);
            this.metroTabPage2.Controls.Add(this.label5);
            this.metroTabPage2.Controls.Add(this.tbArgumentosPreBackup);
            this.metroTabPage2.Controls.Add(this.btnDiretorioAppPreBackup);
            this.metroTabPage2.Controls.Add(this.label3);
            this.metroTabPage2.Controls.Add(this.tbAplicativoPreBackup);
            this.metroTabPage2.Controls.Add(this.lstBoxFlagsBackup);
            this.metroTabPage2.Controls.Add(this.btnDiretorioBackups);
            this.metroTabPage2.Controls.Add(this.label1);
            this.metroTabPage2.Controls.Add(this.tbDiretorioBackups);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(552, 404);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Configurações de Backups";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.Location = new System.Drawing.Point(-3, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 41;
            this.label2.Text = "Opções do Backup:\r\n           (flags)";
            // 
            // lblExplicacaoFlags
            // 
            this.lblExplicacaoFlags.AutoSize = true;
            this.lblExplicacaoFlags.BackColor = System.Drawing.Color.Transparent;
            this.lblExplicacaoFlags.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplicacaoFlags.Location = new System.Drawing.Point(491, 89);
            this.lblExplicacaoFlags.Name = "lblExplicacaoFlags";
            this.lblExplicacaoFlags.Size = new System.Drawing.Size(62, 26);
            this.lblExplicacaoFlags.TabIndex = 35;
            this.lblExplicacaoFlags.TabStop = true;
            this.lblExplicacaoFlags.Text = "O que isso\r\nsignifica?";
            this.lblExplicacaoFlags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExplicacaoFlags.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblExplicacaoFlags_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label8.Location = new System.Drawing.Point(365, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "dia(s) do Diretório de Backups local";
            // 
            // nmUpDownDiasExcluirBackupsAntigos
            // 
            this.nmUpDownDiasExcluirBackupsAntigos.BackColor = System.Drawing.Color.Transparent;
            this.nmUpDownDiasExcluirBackupsAntigos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nmUpDownDiasExcluirBackupsAntigos.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nmUpDownDiasExcluirBackupsAntigos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nmUpDownDiasExcluirBackupsAntigos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nmUpDownDiasExcluirBackupsAntigos.DisabledState.Parent = this.nmUpDownDiasExcluirBackupsAntigos;
            this.nmUpDownDiasExcluirBackupsAntigos.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nmUpDownDiasExcluirBackupsAntigos.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nmUpDownDiasExcluirBackupsAntigos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nmUpDownDiasExcluirBackupsAntigos.FocusedState.Parent = this.nmUpDownDiasExcluirBackupsAntigos;
            this.nmUpDownDiasExcluirBackupsAntigos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmUpDownDiasExcluirBackupsAntigos.ForeColor = System.Drawing.Color.Black;
            this.nmUpDownDiasExcluirBackupsAntigos.Location = new System.Drawing.Point(291, 348);
            this.nmUpDownDiasExcluirBackupsAntigos.Name = "nmUpDownDiasExcluirBackupsAntigos";
            this.nmUpDownDiasExcluirBackupsAntigos.ShadowDecoration.Parent = this.nmUpDownDiasExcluirBackupsAntigos;
            this.nmUpDownDiasExcluirBackupsAntigos.Size = new System.Drawing.Size(68, 26);
            this.nmUpDownDiasExcluirBackupsAntigos.TabIndex = 33;
            this.nmUpDownDiasExcluirBackupsAntigos.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            // 
            // chbxExcluirBackupsAntigos
            // 
            this.chbxExcluirBackupsAntigos.AutoSize = true;
            this.chbxExcluirBackupsAntigos.BackColor = System.Drawing.Color.Transparent;
            this.chbxExcluirBackupsAntigos.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.chbxExcluirBackupsAntigos.CheckedState.BorderRadius = 2;
            this.chbxExcluirBackupsAntigos.CheckedState.BorderThickness = 0;
            this.chbxExcluirBackupsAntigos.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.chbxExcluirBackupsAntigos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxExcluirBackupsAntigos.Location = new System.Drawing.Point(28, 354);
            this.chbxExcluirBackupsAntigos.Name = "chbxExcluirBackupsAntigos";
            this.chbxExcluirBackupsAntigos.Size = new System.Drawing.Size(257, 17);
            this.chbxExcluirBackupsAntigos.TabIndex = 32;
            this.chbxExcluirBackupsAntigos.Text = "Excluir Arquivos de Backup mais antigos que:";
            this.chbxExcluirBackupsAntigos.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbxExcluirBackupsAntigos.UncheckedState.BorderRadius = 2;
            this.chbxExcluirBackupsAntigos.UncheckedState.BorderThickness = 0;
            this.chbxExcluirBackupsAntigos.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbxExcluirBackupsAntigos.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.Location = new System.Drawing.Point(25, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Argumentos²:";
            // 
            // tbArgumentosPosBackup
            // 
            this.tbArgumentosPosBackup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbArgumentosPosBackup.DefaultText = "";
            this.tbArgumentosPosBackup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbArgumentosPosBackup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbArgumentosPosBackup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbArgumentosPosBackup.DisabledState.Parent = this.tbArgumentosPosBackup;
            this.tbArgumentosPosBackup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbArgumentosPosBackup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbArgumentosPosBackup.FocusedState.Parent = this.tbArgumentosPosBackup;
            this.tbArgumentosPosBackup.ForeColor = System.Drawing.Color.Black;
            this.tbArgumentosPosBackup.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbArgumentosPosBackup.HoverState.Parent = this.tbArgumentosPosBackup;
            this.tbArgumentosPosBackup.Location = new System.Drawing.Point(104, 302);
            this.tbArgumentosPosBackup.Name = "tbArgumentosPosBackup";
            this.tbArgumentosPosBackup.PasswordChar = '\0';
            this.tbArgumentosPosBackup.PlaceholderText = "";
            this.tbArgumentosPosBackup.SelectedText = "";
            this.tbArgumentosPosBackup.ShadowDecoration.Parent = this.tbArgumentosPosBackup;
            this.tbArgumentosPosBackup.Size = new System.Drawing.Size(448, 24);
            this.tbArgumentosPosBackup.TabIndex = 30;
            // 
            // btnDiretorioAppPosBackup
            // 
            this.btnDiretorioAppPosBackup.CheckedState.Parent = this.btnDiretorioAppPosBackup;
            this.btnDiretorioAppPosBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiretorioAppPosBackup.CustomImages.Parent = this.btnDiretorioAppPosBackup;
            this.btnDiretorioAppPosBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnDiretorioAppPosBackup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiretorioAppPosBackup.ForeColor = System.Drawing.Color.White;
            this.btnDiretorioAppPosBackup.HoverState.Parent = this.btnDiretorioAppPosBackup;
            this.btnDiretorioAppPosBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnDiretorioAppPosBackup.Image")));
            this.btnDiretorioAppPosBackup.Location = new System.Drawing.Point(496, 272);
            this.btnDiretorioAppPosBackup.Name = "btnDiretorioAppPosBackup";
            this.btnDiretorioAppPosBackup.ShadowDecoration.Parent = this.btnDiretorioAppPosBackup;
            this.btnDiretorioAppPosBackup.Size = new System.Drawing.Size(46, 24);
            this.btnDiretorioAppPosBackup.TabIndex = 29;
            this.btnDiretorioAppPosBackup.Click += new System.EventHandler(this.btnDiretorioAppPosBackup_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label7.Location = new System.Drawing.Point(-4, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 26);
            this.label7.TabIndex = 28;
            this.label7.Text = "Executar Aplicativo\r\nDepois do Backup²:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAplicativoPosBackup
            // 
            this.tbAplicativoPosBackup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAplicativoPosBackup.DefaultText = "";
            this.tbAplicativoPosBackup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAplicativoPosBackup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAplicativoPosBackup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAplicativoPosBackup.DisabledState.Parent = this.tbAplicativoPosBackup;
            this.tbAplicativoPosBackup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAplicativoPosBackup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAplicativoPosBackup.FocusedState.Parent = this.tbAplicativoPosBackup;
            this.tbAplicativoPosBackup.ForeColor = System.Drawing.Color.Black;
            this.tbAplicativoPosBackup.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAplicativoPosBackup.HoverState.Parent = this.tbAplicativoPosBackup;
            this.tbAplicativoPosBackup.Location = new System.Drawing.Point(104, 272);
            this.tbAplicativoPosBackup.Name = "tbAplicativoPosBackup";
            this.tbAplicativoPosBackup.PasswordChar = '\0';
            this.tbAplicativoPosBackup.PlaceholderText = "";
            this.tbAplicativoPosBackup.SelectedText = "";
            this.tbAplicativoPosBackup.ShadowDecoration.Parent = this.tbAplicativoPosBackup;
            this.tbAplicativoPosBackup.Size = new System.Drawing.Size(386, 24);
            this.tbAplicativoPosBackup.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label5.Location = new System.Drawing.Point(25, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Argumentos¹:";
            // 
            // tbArgumentosPreBackup
            // 
            this.tbArgumentosPreBackup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbArgumentosPreBackup.DefaultText = "";
            this.tbArgumentosPreBackup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbArgumentosPreBackup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbArgumentosPreBackup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbArgumentosPreBackup.DisabledState.Parent = this.tbArgumentosPreBackup;
            this.tbArgumentosPreBackup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbArgumentosPreBackup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbArgumentosPreBackup.FocusedState.Parent = this.tbArgumentosPreBackup;
            this.tbArgumentosPreBackup.ForeColor = System.Drawing.Color.Black;
            this.tbArgumentosPreBackup.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbArgumentosPreBackup.HoverState.Parent = this.tbArgumentosPreBackup;
            this.tbArgumentosPreBackup.Location = new System.Drawing.Point(104, 225);
            this.tbArgumentosPreBackup.Name = "tbArgumentosPreBackup";
            this.tbArgumentosPreBackup.PasswordChar = '\0';
            this.tbArgumentosPreBackup.PlaceholderText = "";
            this.tbArgumentosPreBackup.SelectedText = "";
            this.tbArgumentosPreBackup.ShadowDecoration.Parent = this.tbArgumentosPreBackup;
            this.tbArgumentosPreBackup.Size = new System.Drawing.Size(448, 24);
            this.tbArgumentosPreBackup.TabIndex = 25;
            // 
            // btnDiretorioAppPreBackup
            // 
            this.btnDiretorioAppPreBackup.CheckedState.Parent = this.btnDiretorioAppPreBackup;
            this.btnDiretorioAppPreBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiretorioAppPreBackup.CustomImages.Parent = this.btnDiretorioAppPreBackup;
            this.btnDiretorioAppPreBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnDiretorioAppPreBackup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiretorioAppPreBackup.ForeColor = System.Drawing.Color.White;
            this.btnDiretorioAppPreBackup.HoverState.Parent = this.btnDiretorioAppPreBackup;
            this.btnDiretorioAppPreBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnDiretorioAppPreBackup.Image")));
            this.btnDiretorioAppPreBackup.Location = new System.Drawing.Point(496, 195);
            this.btnDiretorioAppPreBackup.Name = "btnDiretorioAppPreBackup";
            this.btnDiretorioAppPreBackup.ShadowDecoration.Parent = this.btnDiretorioAppPreBackup;
            this.btnDiretorioAppPreBackup.Size = new System.Drawing.Size(46, 24);
            this.btnDiretorioAppPreBackup.TabIndex = 24;
            this.btnDiretorioAppPreBackup.Click += new System.EventHandler(this.btnDiretorioAppPreBackup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(-1, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "Executar Aplicativo\r\nAntes do Backup¹:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbAplicativoPreBackup
            // 
            this.tbAplicativoPreBackup.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAplicativoPreBackup.DefaultText = "";
            this.tbAplicativoPreBackup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbAplicativoPreBackup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbAplicativoPreBackup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAplicativoPreBackup.DisabledState.Parent = this.tbAplicativoPreBackup;
            this.tbAplicativoPreBackup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbAplicativoPreBackup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAplicativoPreBackup.FocusedState.Parent = this.tbAplicativoPreBackup;
            this.tbAplicativoPreBackup.ForeColor = System.Drawing.Color.Black;
            this.tbAplicativoPreBackup.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAplicativoPreBackup.HoverState.Parent = this.tbAplicativoPreBackup;
            this.tbAplicativoPreBackup.Location = new System.Drawing.Point(104, 195);
            this.tbAplicativoPreBackup.Name = "tbAplicativoPreBackup";
            this.tbAplicativoPreBackup.PasswordChar = '\0';
            this.tbAplicativoPreBackup.PlaceholderText = "";
            this.tbAplicativoPreBackup.SelectedText = "";
            this.tbAplicativoPreBackup.ShadowDecoration.Parent = this.tbAplicativoPreBackup;
            this.tbAplicativoPreBackup.Size = new System.Drawing.Size(386, 24);
            this.tbAplicativoPreBackup.TabIndex = 22;
            // 
            // lstBoxFlagsBackup
            // 
            this.lstBoxFlagsBackup.CheckOnClick = true;
            this.lstBoxFlagsBackup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxFlagsBackup.FormattingEnabled = true;
            this.lstBoxFlagsBackup.Items.AddRange(new object[] {
            "IgnoreLimbo",
            "IgnoreChecksums",
            "MetaDataOnly",
            "NoDatabaseTriggers",
            "NoGarbageCollect",
            "NonTransportable",
            "OldDescriptions",
            "Compactar"});
            this.lstBoxFlagsBackup.Location = new System.Drawing.Point(104, 43);
            this.lstBoxFlagsBackup.Name = "lstBoxFlagsBackup";
            this.lstBoxFlagsBackup.Size = new System.Drawing.Size(386, 140);
            this.lstBoxFlagsBackup.TabIndex = 20;
            // 
            // btnDiretorioBackups
            // 
            this.btnDiretorioBackups.CheckedState.Parent = this.btnDiretorioBackups;
            this.btnDiretorioBackups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiretorioBackups.CustomImages.Parent = this.btnDiretorioBackups;
            this.btnDiretorioBackups.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnDiretorioBackups.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDiretorioBackups.ForeColor = System.Drawing.Color.White;
            this.btnDiretorioBackups.HoverState.Parent = this.btnDiretorioBackups;
            this.btnDiretorioBackups.Image = ((System.Drawing.Image)(resources.GetObject("btnDiretorioBackups.Image")));
            this.btnDiretorioBackups.Location = new System.Drawing.Point(496, 10);
            this.btnDiretorioBackups.Name = "btnDiretorioBackups";
            this.btnDiretorioBackups.ShadowDecoration.Parent = this.btnDiretorioBackups;
            this.btnDiretorioBackups.Size = new System.Drawing.Size(46, 24);
            this.btnDiretorioBackups.TabIndex = 19;
            this.btnDiretorioBackups.Click += new System.EventHandler(this.btnDiretorioBackups_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(0, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Salvar Backups em:";
            // 
            // tbDiretorioBackups
            // 
            this.tbDiretorioBackups.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDiretorioBackups.DefaultText = "";
            this.tbDiretorioBackups.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDiretorioBackups.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDiretorioBackups.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDiretorioBackups.DisabledState.Parent = this.tbDiretorioBackups;
            this.tbDiretorioBackups.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDiretorioBackups.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDiretorioBackups.FocusedState.Parent = this.tbDiretorioBackups;
            this.tbDiretorioBackups.ForeColor = System.Drawing.Color.Black;
            this.tbDiretorioBackups.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDiretorioBackups.HoverState.Parent = this.tbDiretorioBackups;
            this.tbDiretorioBackups.Location = new System.Drawing.Point(104, 10);
            this.tbDiretorioBackups.Name = "tbDiretorioBackups";
            this.tbDiretorioBackups.PasswordChar = '\0';
            this.tbDiretorioBackups.PlaceholderText = "";
            this.tbDiretorioBackups.ReadOnly = true;
            this.tbDiretorioBackups.SelectedText = "";
            this.tbDiretorioBackups.ShadowDecoration.Parent = this.tbDiretorioBackups;
            this.tbDiretorioBackups.Size = new System.Drawing.Size(386, 24);
            this.tbDiretorioBackups.TabIndex = 17;
            // 
            // btnSalvar
            // 
            this.btnSalvar.CheckedState.Parent = this.btnSalvar;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.CustomImages.Parent = this.btnSalvar;
            this.btnSalvar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.HoverState.Parent = this.btnSalvar;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(506, 513);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ShadowDecoration.Parent = this.btnSalvar;
            this.btnSalvar.Size = new System.Drawing.Size(58, 39);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // bunifuElipseBtnSalvar
            // 
            this.bunifuElipseBtnSalvar.ElipseRadius = 10;
            this.bunifuElipseBtnSalvar.TargetControl = this.btnSalvar;
            // 
            // bunifuElipseBtnFechar
            // 
            this.bunifuElipseBtnFechar.ElipseRadius = 10;
            this.bunifuElipseBtnFechar.TargetControl = this;
            // 
            // bunifuElipseBtnDiretorioBackups
            // 
            this.bunifuElipseBtnDiretorioBackups.ElipseRadius = 10;
            this.bunifuElipseBtnDiretorioBackups.TargetControl = this.btnDiretorioBackups;
            // 
            // bunifuElipseBtnAppPreBackup
            // 
            this.bunifuElipseBtnAppPreBackup.ElipseRadius = 10;
            this.bunifuElipseBtnAppPreBackup.TargetControl = this.btnDiretorioAppPreBackup;
            // 
            // bunifuElipseBtnAppPosBackup
            // 
            this.bunifuElipseBtnAppPosBackup.ElipseRadius = 10;
            this.bunifuElipseBtnAppPosBackup.TargetControl = this.btnDiretorioAppPosBackup;
            // 
            // UCConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tbControl);
            this.Controls.Add(this.label4);
            this.Name = "UCConfiguracoes";
            this.Size = new System.Drawing.Size(571, 560);
            this.Load += new System.EventHandler(this.UCConfiguracoes_Load);
            this.tbControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDownDiasExcluirBackupsAntigos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTabControl tbControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private Guna.UI2.WinForms.Guna2TileButton btnSalvar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnSalvar;
        private Guna.UI2.WinForms.Guna2CheckBox chbxBuscaAtualizacoesIni;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private Guna.UI2.WinForms.Guna2TileButton btnDiretorioBackups;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbDiretorioBackups;
        private System.Windows.Forms.CheckedListBox lstBoxFlagsBackup;
        private Guna.UI2.WinForms.Guna2TileButton btnDiretorioAppPreBackup;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox tbAplicativoPreBackup;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox tbArgumentosPosBackup;
        private Guna.UI2.WinForms.Guna2TileButton btnDiretorioAppPosBackup;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox tbAplicativoPosBackup;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox tbArgumentosPreBackup;
        private Guna.UI2.WinForms.Guna2NumericUpDown nmUpDownDiasExcluirBackupsAntigos;
        private Guna.UI2.WinForms.Guna2CheckBox chbxExcluirBackupsAntigos;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnFechar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnDiretorioBackups;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnAppPreBackup;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnAppPosBackup;
        private System.Windows.Forms.LinkLabel lblExplicacaoFlags;
        private Guna.UI2.WinForms.Guna2CheckBox chbxIniciarComOWindows;
        private System.Windows.Forms.Label label2;
    }
}
