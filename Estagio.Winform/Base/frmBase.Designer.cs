namespace Estagio.WinForm
{
    partial class frmBase
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
            this.ssBarraDeStatus = new System.Windows.Forms.StatusStrip();
            this.sslMensagem = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ssBarraDeStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ssBarraDeStatus
            // 
            this.ssBarraDeStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslMensagem});
            this.ssBarraDeStatus.Location = new System.Drawing.Point(0, 428);
            this.ssBarraDeStatus.Name = "ssBarraDeStatus";
            this.ssBarraDeStatus.Size = new System.Drawing.Size(640, 22);
            this.ssBarraDeStatus.TabIndex = 1;
            this.ssBarraDeStatus.Text = "ssIMensagem";
            // 
            // sslMensagem
            // 
            this.sslMensagem.Name = "sslMensagem";
            this.sslMensagem.Size = new System.Drawing.Size(79, 17);
            this.sslMensagem.Text = "ssIMensagem";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 329);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Estagio.WinForm.Properties.Resources.images1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ssBarraDeStatus);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ssBarraDeStatus.ResumeLayout(false);
            this.ssBarraDeStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip ssBarraDeStatus;
        private System.Windows.Forms.ToolStripStatusLabel sslMensagem;
        protected System.Windows.Forms.Panel panel1;
    }
}

