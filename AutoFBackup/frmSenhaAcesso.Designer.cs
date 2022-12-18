namespace FBackup
{
    partial class frmSenhaAcesso
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSair = new System.Windows.Forms.Label();
            this.btnProsseguir = new Guna.UI2.WinForms.Guna2TileButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSenha = new Guna.UI2.WinForms.Guna2TextBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.pnlTop.Controls.Add(this.lblSair);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(235, 37);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSair
            // 
            this.lblSair.AutoSize = true;
            this.lblSair.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.ForeColor = System.Drawing.Color.White;
            this.lblSair.Location = new System.Drawing.Point(211, 5);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(18, 20);
            this.lblSair.TabIndex = 12;
            this.lblSair.Text = "X";
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            // 
            // btnProsseguir
            // 
            this.btnProsseguir.CheckedState.Parent = this.btnProsseguir;
            this.btnProsseguir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProsseguir.CustomImages.Parent = this.btnProsseguir;
            this.btnProsseguir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.btnProsseguir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProsseguir.ForeColor = System.Drawing.Color.White;
            this.btnProsseguir.HoverState.Parent = this.btnProsseguir;
            this.btnProsseguir.Location = new System.Drawing.Point(52, 112);
            this.btnProsseguir.Name = "btnProsseguir";
            this.btnProsseguir.ShadowDecoration.Parent = this.btnProsseguir;
            this.btnProsseguir.Size = new System.Drawing.Size(132, 31);
            this.btnProsseguir.TabIndex = 11;
            this.btnProsseguir.Text = "Prosseguir";
            this.btnProsseguir.Click += new System.EventHandler(this.btnProsseguir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label9.Location = new System.Drawing.Point(49, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Senha:";
            // 
            // tbSenha
            // 
            this.tbSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSenha.DefaultText = "";
            this.tbSenha.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSenha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSenha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSenha.DisabledState.Parent = this.tbSenha;
            this.tbSenha.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSenha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSenha.FocusedState.Parent = this.tbSenha;
            this.tbSenha.ForeColor = System.Drawing.Color.Black;
            this.tbSenha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSenha.HoverState.Parent = this.tbSenha;
            this.tbSenha.Location = new System.Drawing.Point(52, 73);
            this.tbSenha.MaxLength = 10;
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '\0';
            this.tbSenha.PlaceholderText = "";
            this.tbSenha.SelectedText = "";
            this.tbSenha.ShadowDecoration.Parent = this.tbSenha;
            this.tbSenha.Size = new System.Drawing.Size(132, 24);
            this.tbSenha.TabIndex = 1;
            this.tbSenha.UseSystemPasswordChar = true;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlTop;
            this.bunifuDragControl1.Vertical = true;
            // 
            // frmSenhaAcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 157);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.btnProsseguir);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSenhaAcesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnlTop;
        private Guna.UI2.WinForms.Guna2TileButton btnProsseguir;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox tbSenha;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}