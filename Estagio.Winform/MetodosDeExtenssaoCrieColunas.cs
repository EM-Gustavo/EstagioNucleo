using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.WinForm
{
    public static class MetodosDeExtenssaoCrieColunas
    {
        public static DataGridViewColumn CrieColuna(this DataGridView dgvGeral, string headerText, string dataPropertyName, int tamanhoDaColuna)
        {
            var coluna = new DataGridViewTextBoxColumn();
            coluna.HeaderText = headerText;
            coluna.DataPropertyName = dataPropertyName;
            coluna.Width = tamanhoDaColuna;
            dgvGeral.Columns.Add(coluna);
            return coluna;
        }

        public static DataGridViewColumn CrieColunaFill(this DataGridView dgvGeral, string headerText, string dataPropertyName)
        {
            var coluna = new DataGridViewTextBoxColumn();
            coluna.HeaderText = headerText;
            coluna.DataPropertyName = dataPropertyName;
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGeral.Columns.Add(coluna);
            return coluna;
        }
    }

}
