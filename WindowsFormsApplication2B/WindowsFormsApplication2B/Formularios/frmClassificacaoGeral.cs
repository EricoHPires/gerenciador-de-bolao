using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2B.Aplicacao;

namespace WindowsFormsApplication2B.Formularios
{
    public partial class frmClassificacaoGeral : Form
    {
        ParticipanteAplicacao participanteApp = new ParticipanteAplicacao();
        PontuacaoPorRodadaAplicacao pontuacaoApp = new PontuacaoPorRodadaAplicacao();

        public frmClassificacaoGeral()
        {
            InitializeComponent();
        }

        private void frmClassificacaoGeral_Load(object sender, EventArgs e)
        {
            CarregaClassificacao();
        }

        public void CarregaClassificacao()
        {
            var participantes = participanteApp.SelectAll();
            #region Configuração DataTable

            //saber quantas rodadas diferentes existem
            var pontuacoesPorRodada = pontuacaoApp.SelectAll();
            var rodadas = pontuacoesPorRodada.Select(p => p.Rodada).Distinct().ToList();
            int numeroRodadas = rodadas.Count;



            DataTable dtTab = new DataTable("sqls");

            dtTab.Clear();
            dtTab.Columns.Add("Id", typeof(string));
            dtTab.Columns.Add("DESCRIÇÃO", typeof(string));

            #endregion

            #region Preenchendo DataTable

            DataRow row;
            foreach (var registro in controle)
            {
                row = dtTab.NewRow();

                row["Id"] = registro.Id;
                row["DESCRIÇÃO"] = registro.Descricao;

                dtTab.Rows.Add(row);
            }

            #endregion

            #region Configuração DataGridView

            this.dataGridViewControlesGenericos.DataSource = dtTab;

            this.dataGridViewControlesGenericos.Columns[0].Visible = false;
            this.dataGridViewControlesGenericos.Columns[1].Width = this.Width - 20;

            this.dataGridViewControlesGenericos.DefaultCellStyle.Font = new Font(new FontFamily("Segoe UI Light"), 13, FontStyle.Regular, GraphicsUnit.Pixel);
            this.dataGridViewControlesGenericos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //Verifica se tem scrollbar e acerta os tamanhos
            if (dataGridViewControlesGenericos.Controls.OfType<VScrollBar>().First().Visible)
            {
                this.dataGridViewControlesGenericos.Columns[1].Width -= 17;
            }

            #endregion
        }
    }
}
