using Bunifu.Framework.UI;

namespace FBackup
{
    partial class frmMain
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConfiguracoes = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnIntegracoes = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnNovoBackup = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2TileButton();
            this.bunifuDragControlForm = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipseForm = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipsePanelControls = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnDashboard = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnNovoBackup = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnIntegracoes = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnConfiguracoes = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersaoAutoFBackup = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.lblMinimizar = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblMQFSYoutube = new System.Windows.Forms.LinkLabel();
            this.lblEdsonGregorio = new System.Windows.Forms.LinkLabel();
            this.lblMQFSFacebook = new System.Windows.Forms.LinkLabel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAutoFBackupWiki = new System.Windows.Forms.LinkLabel();
            this.lblAutoFBackupVersoes = new System.Windows.Forms.LinkLabel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.pnlControls.Location = new System.Drawing.Point(222, 48);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(571, 560);
            this.pnlControls.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.panel2.Controls.Add(this.lblAutoFBackupVersoes);
            this.panel2.Controls.Add(this.lblAutoFBackupWiki);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.bunifuSeparator1);
            this.panel2.Controls.Add(this.lblMQFSFacebook);
            this.panel2.Controls.Add(this.lblEdsonGregorio);
            this.panel2.Controls.Add(this.lblMQFSYoutube);
            this.panel2.Controls.Add(this.btnConfiguracoes);
            this.panel2.Controls.Add(this.btnIntegracoes);
            this.panel2.Controls.Add(this.btnNovoBackup);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 504);
            this.panel2.TabIndex = 1;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.CheckedState.Parent = this.btnConfiguracoes;
            this.btnConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracoes.CustomImages.Parent = this.btnConfiguracoes;
            this.btnConfiguracoes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnConfiguracoes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracoes.HoverState.Parent = this.btnConfiguracoes;
            this.btnConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracoes.Image")));
            this.btnConfiguracoes.Location = new System.Drawing.Point(119, 114);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.ShadowDecoration.Parent = this.btnConfiguracoes;
            this.btnConfiguracoes.Size = new System.Drawing.Size(85, 64);
            this.btnConfiguracoes.TabIndex = 11;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // btnIntegracoes
            // 
            this.btnIntegracoes.CheckedState.Parent = this.btnIntegracoes;
            this.btnIntegracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntegracoes.CustomImages.Parent = this.btnIntegracoes;
            this.btnIntegracoes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnIntegracoes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIntegracoes.ForeColor = System.Drawing.Color.White;
            this.btnIntegracoes.HoverState.Parent = this.btnIntegracoes;
            this.btnIntegracoes.Image = ((System.Drawing.Image)(resources.GetObject("btnIntegracoes.Image")));
            this.btnIntegracoes.Location = new System.Drawing.Point(22, 114);
            this.btnIntegracoes.Name = "btnIntegracoes";
            this.btnIntegracoes.ShadowDecoration.Parent = this.btnIntegracoes;
            this.btnIntegracoes.Size = new System.Drawing.Size(85, 64);
            this.btnIntegracoes.TabIndex = 10;
            this.btnIntegracoes.Text = "Integrações";
            this.btnIntegracoes.Click += new System.EventHandler(this.btnIntegracoes_Click);
            // 
            // btnNovoBackup
            // 
            this.btnNovoBackup.CheckedState.Parent = this.btnNovoBackup;
            this.btnNovoBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovoBackup.CustomImages.Parent = this.btnNovoBackup;
            this.btnNovoBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnNovoBackup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNovoBackup.ForeColor = System.Drawing.Color.White;
            this.btnNovoBackup.HoverState.Parent = this.btnNovoBackup;
            this.btnNovoBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnNovoBackup.Image")));
            this.btnNovoBackup.Location = new System.Drawing.Point(119, 32);
            this.btnNovoBackup.Name = "btnNovoBackup";
            this.btnNovoBackup.ShadowDecoration.Parent = this.btnNovoBackup;
            this.btnNovoBackup.Size = new System.Drawing.Size(85, 64);
            this.btnNovoBackup.TabIndex = 9;
            this.btnNovoBackup.Text = "Novo Backup";
            this.btnNovoBackup.Click += new System.EventHandler(this.btnNovoBackup_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.CheckedState.Parent = this.btnDashboard;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.CustomImages.Parent = this.btnDashboard;
            this.btnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.HoverState.Parent = this.btnDashboard;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.Location = new System.Drawing.Point(22, 32);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.ShadowDecoration.Parent = this.btnDashboard;
            this.btnDashboard.Size = new System.Drawing.Size(85, 64);
            this.btnDashboard.TabIndex = 8;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // bunifuDragControlForm
            // 
            this.bunifuDragControlForm.Fixed = true;
            this.bunifuDragControlForm.Horizontal = true;
            this.bunifuDragControlForm.TargetControl = this;
            this.bunifuDragControlForm.Vertical = true;
            // 
            // bunifuElipseForm
            // 
            this.bunifuElipseForm.ElipseRadius = 5;
            this.bunifuElipseForm.TargetControl = this;
            // 
            // bunifuElipsePanelControls
            // 
            this.bunifuElipsePanelControls.ElipseRadius = 20;
            this.bunifuElipsePanelControls.TargetControl = this.pnlControls;
            // 
            // bunifuElipseBtnDashboard
            // 
            this.bunifuElipseBtnDashboard.ElipseRadius = 10;
            this.bunifuElipseBtnDashboard.TargetControl = this.btnDashboard;
            // 
            // bunifuElipseBtnNovoBackup
            // 
            this.bunifuElipseBtnNovoBackup.ElipseRadius = 10;
            this.bunifuElipseBtnNovoBackup.TargetControl = this.btnNovoBackup;
            // 
            // bunifuElipseBtnIntegracoes
            // 
            this.bunifuElipseBtnIntegracoes.ElipseRadius = 10;
            this.bunifuElipseBtnIntegracoes.TargetControl = this.btnIntegracoes;
            // 
            // bunifuElipseBtnConfiguracoes
            // 
            this.bunifuElipseBtnConfiguracoes.ElipseRadius = 10;
            this.bunifuElipseBtnConfiguracoes.TargetControl = this.btnConfiguracoes;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "AutoFBackup";
            // 
            // lblVersaoAutoFBackup
            // 
            this.lblVersaoAutoFBackup.AutoSize = true;
            this.lblVersaoAutoFBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersaoAutoFBackup.ForeColor = System.Drawing.Color.White;
            this.lblVersaoAutoFBackup.Location = new System.Drawing.Point(8, 73);
            this.lblVersaoAutoFBackup.Name = "lblVersaoAutoFBackup";
            this.lblVersaoAutoFBackup.Size = new System.Drawing.Size(0, 15);
            this.lblVersaoAutoFBackup.TabIndex = 3;
            // 
            // lblSair
            // 
            this.lblSair.AutoSize = true;
            this.lblSair.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.ForeColor = System.Drawing.Color.White;
            this.lblSair.Location = new System.Drawing.Point(763, 9);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(18, 20);
            this.lblSair.TabIndex = 4;
            this.lblSair.Text = "X";
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            // 
            // lblMinimizar
            // 
            this.lblMinimizar.AutoSize = true;
            this.lblMinimizar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimizar.ForeColor = System.Drawing.Color.White;
            this.lblMinimizar.Location = new System.Drawing.Point(732, 9);
            this.lblMinimizar.Name = "lblMinimizar";
            this.lblMinimizar.Size = new System.Drawing.Size(24, 20);
            this.lblMinimizar.TabIndex = 5;
            this.lblMinimizar.Text = "—";
            this.lblMinimizar.Click += new System.EventHandler(this.lblMinimizar_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "Duplo clique para abrir.";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // lblMQFSYoutube
            // 
            this.lblMQFSYoutube.AutoSize = true;
            this.lblMQFSYoutube.LinkColor = System.Drawing.Color.Red;
            this.lblMQFSYoutube.Location = new System.Drawing.Point(0, 481);
            this.lblMQFSYoutube.Name = "lblMQFSYoutube";
            this.lblMQFSYoutube.Size = new System.Drawing.Size(215, 13);
            this.lblMQFSYoutube.TabIndex = 12;
            this.lblMQFSYoutube.TabStop = true;
            this.lblMQFSYoutube.Text = "MQFS - Meu querido Firebird SQL (Youtube)";
            this.lblMQFSYoutube.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMQFSYoutube_LinkClicked);
            // 
            // lblEdsonGregorio
            // 
            this.lblEdsonGregorio.AutoSize = true;
            this.lblEdsonGregorio.Location = new System.Drawing.Point(0, 436);
            this.lblEdsonGregorio.Name = "lblEdsonGregorio";
            this.lblEdsonGregorio.Size = new System.Drawing.Size(137, 13);
            this.lblEdsonGregorio.TabIndex = 13;
            this.lblEdsonGregorio.TabStop = true;
            this.lblEdsonGregorio.Text = "Edson Gregorio (Facebook)";
            this.lblEdsonGregorio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEdsonGregorio_LinkClicked);
            // 
            // lblMQFSFacebook
            // 
            this.lblMQFSFacebook.AutoSize = true;
            this.lblMQFSFacebook.Location = new System.Drawing.Point(0, 458);
            this.lblMQFSFacebook.Name = "lblMQFSFacebook";
            this.lblMQFSFacebook.Size = new System.Drawing.Size(223, 13);
            this.lblMQFSFacebook.TabIndex = 14;
            this.lblMQFSFacebook.TabStop = true;
            this.lblMQFSFacebook.Text = "MQFS - Meu querido Firebird SQL (Facebook)";
            this.lblMQFSFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMQFSFacebook_LinkClicked);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(-2, 368);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(223, 10);
            this.bunifuSeparator1.TabIndex = 15;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Conteúdo Recomendado";
            // 
            // lblAutoFBackupWiki
            // 
            this.lblAutoFBackupWiki.AutoSize = true;
            this.lblAutoFBackupWiki.Location = new System.Drawing.Point(0, 383);
            this.lblAutoFBackupWiki.Name = "lblAutoFBackupWiki";
            this.lblAutoFBackupWiki.Size = new System.Drawing.Size(102, 13);
            this.lblAutoFBackupWiki.TabIndex = 17;
            this.lblAutoFBackupWiki.TabStop = true;
            this.lblAutoFBackupWiki.Text = "AutoFBackup - Wiki";
            this.lblAutoFBackupWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAutoFBackupWiki_LinkClicked);
            // 
            // lblAutoFBackupVersoes
            // 
            this.lblAutoFBackupVersoes.AutoSize = true;
            this.lblAutoFBackupVersoes.LinkColor = System.Drawing.Color.Black;
            this.lblAutoFBackupVersoes.Location = new System.Drawing.Point(0, 403);
            this.lblAutoFBackupVersoes.Name = "lblAutoFBackupVersoes";
            this.lblAutoFBackupVersoes.Size = new System.Drawing.Size(119, 13);
            this.lblAutoFBackupVersoes.TabIndex = 18;
            this.lblAutoFBackupVersoes.TabStop = true;
            this.lblAutoFBackupVersoes.Text = "AutoFBackup - Versões";
            this.lblAutoFBackupVersoes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAutoFBackupVersoes_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(793, 602);
            this.Controls.Add(this.lblMinimizar);
            this.Controls.Add(this.lblSair);
            this.Controls.Add(this.lblVersaoAutoFBackup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel panel2;
        private BunifuDragControl bunifuDragControlForm;
        private BunifuElipse bunifuElipseForm;
        private BunifuElipse bunifuElipsePanelControls;
        private BunifuElipse bunifuElipseBtnDashboard;
        private BunifuElipse bunifuElipseBtnNovoBackup;
        private BunifuElipse bunifuElipseBtnIntegracoes;
        private BunifuElipse bunifuElipseBtnConfiguracoes;
        private Guna.UI2.WinForms.Guna2TileButton btnConfiguracoes;
        private Guna.UI2.WinForms.Guna2TileButton btnIntegracoes;
        private Guna.UI2.WinForms.Guna2TileButton btnNovoBackup;
        private Guna.UI2.WinForms.Guna2TileButton btnDashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersaoAutoFBackup;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label lblMinimizar;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel lblMQFSFacebook;
        private System.Windows.Forms.LinkLabel lblEdsonGregorio;
        private System.Windows.Forms.LinkLabel lblMQFSYoutube;
        private System.Windows.Forms.Label label2;
        private BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.LinkLabel lblAutoFBackupVersoes;
        private System.Windows.Forms.LinkLabel lblAutoFBackupWiki;
    }
}

