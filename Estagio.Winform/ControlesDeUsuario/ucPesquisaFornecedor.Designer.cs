namespace Estagio.WinForm.ControlesDeUsuario
{
    partial class ucPesquisaFornecedor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucBasePesquisa1 = new Estagio.WinForm.ControlesDeUsuario.ucBasePesquisa();
            this.SuspendLayout();
            // 
            // ucBasePesquisa1
            // 
            this.ucBasePesquisa1.Location = new System.Drawing.Point(0, 0);
            this.ucBasePesquisa1.Name = "ucBasePesquisa1";
            this.ucBasePesquisa1.Size = new System.Drawing.Size(468, 25);
            this.ucBasePesquisa1.TabIndex = 0;
            // 
            // ucPesquisaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucBasePesquisa1);
            this.Name = "ucPesquisaFornecedor";
            this.Size = new System.Drawing.Size(468, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBasePesquisa ucBasePesquisa1;
    }
}
