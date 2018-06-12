using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.WinForm
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        public frmBase(IContainer components, PictureBox pictureBox1, StatusStrip ssBarraDeStatus, ToolStripStatusLabel toolStripStatusLabel1, Panel panel1)
        {
            this.components = components;
            this.pictureBox1 = pictureBox1;
            this.ssBarraDeStatus = ssBarraDeStatus;
            this.toolStripStatusLabel1 = toolStripStatusLabel1;
            this.panel1 = panel1;
        }
    }
}
