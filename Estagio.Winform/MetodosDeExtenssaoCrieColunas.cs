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
        public static void CrieColuna(this DataGridView dgvGeral, string HeaderText, string DataPropertyName, int tamanhoDaColuna)
        {
            var coluna = new DataGridViewTextBoxColumn();
            coluna.HeaderText = HeaderText;
            coluna.DataPropertyName = DataPropertyName;
            coluna.Width = tamanhoDaColuna;
            dgvGeral.Columns.Add(coluna);
        }

        public static void CrieColuna(this DataGridView dgvGeral, string HeaderText, string DataPropertyName, DataGridViewAutoSizeColumnMode ModoDaColuna)
        {
            var coluna = new DataGridViewTextBoxColumn();
            coluna.HeaderText = HeaderText;
            coluna.DataPropertyName = DataPropertyName;
            coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGeral.Columns.Add(coluna);
        }
    }

}
