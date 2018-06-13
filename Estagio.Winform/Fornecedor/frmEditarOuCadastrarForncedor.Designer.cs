namespace Estagio.WinForm
{
    partial class frmEditarOuCadastrarForncedor
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbCNPJ = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbNome);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.txtCNPJ);
            this.panel1.Controls.Add(this.lbCNPJ);
            this.panel1.Size = new System.Drawing.Size(510, 213);
            this.panel1.Controls.SetChildIndex(this.lbCNPJ, 0);
            this.panel1.Controls.SetChildIndex(this.txtCNPJ, 0);
            this.panel1.Controls.SetChildIndex(this.txtNome, 0);
            this.panel1.Controls.SetChildIndex(this.lbNome, 0);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(148, 33);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(130, 20);
            this.txtNome.TabIndex = 29;
            // 
            // lbCNPJ
            // 
            this.lbCNPJ.AutoSize = true;
            this.lbCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCNPJ.Location = new System.Drawing.Point(36, 71);
            this.lbCNPJ.Name = "lbCNPJ";
            this.lbCNPJ.Size = new System.Drawing.Size(53, 20);
            this.lbCNPJ.TabIndex = 33;
            this.lbCNPJ.Text = "CNPJ:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(148, 73);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(128, 20);
            this.txtCNPJ.TabIndex = 30;
            this.txtCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.Location = new System.Drawing.Point(36, 31);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(55, 20);
            this.lbNome.TabIndex = 35;
            this.lbNome.Text = "Nome:";
            // 
            // frmEditarOuCadastrarForncedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 334);
            this.Name = "frmEditarOuCadastrarForncedor";
            this.Text = "frmEditarOuCadastrarForncedor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbCNPJ;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label lbNome;
    }
}