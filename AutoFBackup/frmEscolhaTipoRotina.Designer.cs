namespace FBackup
{
    partial class frmEscolhaTipoRotina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEscolhaTipoRotina));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRotinaReplicacaoDeDados = new System.Windows.Forms.Label();
            this.rdbtnRotinaReplicacaoDados = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.lblRotinaBackups = new System.Windows.Forms.Label();
            this.rdbtnRotinaBackups = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFechar = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnSalvar = new Guna.UI2.WinForms.Guna2TileButton();
            this.bunifuElipseBtnFechar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipseBtnSalvar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 42);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 230);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblRotinaReplicacaoDeDados);
            this.panel3.Controls.Add(this.rdbtnRotinaReplicacaoDados);
            this.panel3.Controls.Add(this.lblRotinaBackups);
            this.panel3.Controls.Add(this.rdbtnRotinaBackups);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnFechar);
            this.panel3.Controls.Add(this.btnSalvar);
            this.panel3.Location = new System.Drawing.Point(1, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 186);
            this.panel3.TabIndex = 0;
            // 
            // lblRotinaReplicacaoDeDados
            // 
            this.lblRotinaReplicacaoDeDados.AutoSize = true;
            this.lblRotinaReplicacaoDeDados.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotinaReplicacaoDeDados.Location = new System.Drawing.Point(30, 91);
            this.lblRotinaReplicacaoDeDados.Name = "lblRotinaReplicacaoDeDados";
            this.lblRotinaReplicacaoDeDados.Size = new System.Drawing.Size(466, 17);
            this.lblRotinaReplicacaoDeDados.TabIndex = 31;
            this.lblRotinaReplicacaoDeDados.Text = "Rotina para o transporte dos arquivos de Replicação de Dados (Firebird 5.0)";
            this.lblRotinaReplicacaoDeDados.Click += new System.EventHandler(this.lblRotinaReplicacaoDeDados_Click);
            // 
            // rdbtnRotinaReplicacaoDados
            // 
            this.rdbtnRotinaReplicacaoDados.AllowBindingControlLocation = false;
            this.rdbtnRotinaReplicacaoDados.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnRotinaReplicacaoDados.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
            this.rdbtnRotinaReplicacaoDados.BorderThickness = 1;
            this.rdbtnRotinaReplicacaoDados.Checked = false;
            this.rdbtnRotinaReplicacaoDados.Location = new System.Drawing.Point(3, 90);
            this.rdbtnRotinaReplicacaoDados.Name = "rdbtnRotinaReplicacaoDados";
            this.rdbtnRotinaReplicacaoDados.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaReplicacaoDados.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaReplicacaoDados.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
            this.rdbtnRotinaReplicacaoDados.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaReplicacaoDados.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaReplicacaoDados.Size = new System.Drawing.Size(21, 21);
            this.rdbtnRotinaReplicacaoDados.TabIndex = 30;
            this.rdbtnRotinaReplicacaoDados.Text = null;
            // 
            // lblRotinaBackups
            // 
            this.lblRotinaBackups.AutoSize = true;
            this.lblRotinaBackups.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotinaBackups.Location = new System.Drawing.Point(30, 66);
            this.lblRotinaBackups.Name = "lblRotinaBackups";
            this.lblRotinaBackups.Size = new System.Drawing.Size(395, 17);
            this.lblRotinaBackups.TabIndex = 29;
            this.lblRotinaBackups.Text = "Rotina para efetuar Arquivos de Backup de um Banco de Dados";
            this.lblRotinaBackups.Click += new System.EventHandler(this.lblRotinaBackups_Click);
            // 
            // rdbtnRotinaBackups
            // 
            this.rdbtnRotinaBackups.AllowBindingControlLocation = false;
            this.rdbtnRotinaBackups.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnRotinaBackups.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
            this.rdbtnRotinaBackups.BorderThickness = 1;
            this.rdbtnRotinaBackups.Checked = true;
            this.rdbtnRotinaBackups.Location = new System.Drawing.Point(3, 65);
            this.rdbtnRotinaBackups.Name = "rdbtnRotinaBackups";
            this.rdbtnRotinaBackups.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaBackups.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaBackups.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
            this.rdbtnRotinaBackups.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaBackups.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.rdbtnRotinaBackups.Size = new System.Drawing.Size(21, 21);
            this.rdbtnRotinaBackups.TabIndex = 28;
            this.rdbtnRotinaBackups.Text = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Qual tipo de Rotina você deseja criar?";
            // 
            // btnFechar
            // 
            this.btnFechar.CheckedState.Parent = this.btnFechar;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.CustomImages.Parent = this.btnFechar;
            this.btnFechar.FillColor = System.Drawing.Color.Red;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.HoverState.Parent = this.btnFechar;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(263, 136);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ShadowDecoration.Parent = this.btnFechar;
            this.btnFechar.Size = new System.Drawing.Size(58, 39);
            this.btnFechar.TabIndex = 26;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
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
            this.btnSalvar.Location = new System.Drawing.Point(193, 136);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ShadowDecoration.Parent = this.btnSalvar;
            this.btnSalvar.Size = new System.Drawing.Size(58, 39);
            this.btnSalvar.TabIndex = 25;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // bunifuElipseBtnFechar
            // 
            this.bunifuElipseBtnFechar.ElipseRadius = 10;
            this.bunifuElipseBtnFechar.TargetControl = this.btnFechar;
            // 
            // bunifuElipseBtnSalvar
            // 
            this.bunifuElipseBtnSalvar.ElipseRadius = 15;
            this.bunifuElipseBtnSalvar.TargetControl = this.btnSalvar;
            // 
            // frmEscolhaTipoRotina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(525, 231);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEscolhaTipoRotina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRotinaReplicacaoDeDados;
        private Bunifu.UI.WinForms.BunifuRadioButton rdbtnRotinaReplicacaoDados;
        private System.Windows.Forms.Label lblRotinaBackups;
        private Bunifu.UI.WinForms.BunifuRadioButton rdbtnRotinaBackups;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TileButton btnFechar;
        private Guna.UI2.WinForms.Guna2TileButton btnSalvar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnFechar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipseBtnSalvar;
    }
}