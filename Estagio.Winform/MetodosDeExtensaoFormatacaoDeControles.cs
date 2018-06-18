using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.WinForm
{
    public static class MetodosDeExtensaoFormatacaoDeControles
    {
        public static void FormatoTexto(this TextBox textbox)
        {
            textbox.TextAlign = HorizontalAlignment.Left;
            textbox.MaxLength = 50;
        }

        public static void FormatoMonetario(this TextBox textbox)
        {
            textbox.TextAlign = HorizontalAlignment.Right;
            textbox.MaxLength = 10;
            textbox.KeyPress += FormatoDecimal_KeyPress;
            textbox.Leave += FormatoDecimal_Leave;
        }

        public static void FormatoInteiro(this TextBox textbox)
        {
            textbox.TextAlign = HorizontalAlignment.Right;
            textbox.MaxLength = 13;
            textbox.KeyPress += FormatoInteiro_KeyPress;
        }

        public static void FormatoCPFCNPJ(this TextBox textbox)
        {
            textbox.Leave += FormatoCPFCNPJ_Leave;
        }

        private static void FormatoCPFCNPJ_Leave(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            if (String.IsNullOrEmpty(textbox.Text)) return;

            if(textbox.Text.Length == 11)
            {
                textbox.Text = Convert.ToDecimal(textbox.Text).ToString(@"000\.000\.000\-00");
            }
            else if(textbox.Text.Length == 14)
            {
                textbox.Text = Convert.ToDecimal(textbox.Text).ToString(@"00\.000\.000\/0000\-00");
            }
            return;
        }

        private const int teclaBackSpace = 8;
        private const int teclaVirgula = 44;

        private static void FormatoInteiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != teclaBackSpace;
        }

        private static void FormatoDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != teclaBackSpace && e.KeyChar != teclaVirgula;
        }

        private static void FormatoDecimal_Leave(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            if (String.IsNullOrEmpty(textbox.Text)) return;
            textbox.Text = Convert.ToDecimal(textbox.Text).ToString("0.00");
        }
    }
}
