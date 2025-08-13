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
    public partial class frmPontuacaoRodada : Form
    {
        PontuacaoPorRodadaAplicacao pontuacaoRodadaApp = new PontuacaoPorRodadaAplicacao();

        public frmPontuacaoRodada()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string rodada = txtRodada.Text;
            CarregaGrid(rodada);
        }

        public void CarregaGrid(string rodada)
        {
            try
            {
                var pontuacoesRodada = pontuacaoRodadaApp.BuscarPorRodada(rodada);
                if (pontuacoesRodada.Count < 1)
                {
                    throw new Exception("Não foram encontradas pontuações para esta rodada!");
                }

                dgvResultadosRodada.Visible = true;

                var pontuacoesOrdenadas = pontuacoesRodada.OrderByDescending(p => p.Pontuacao).ThenByDescending(p => p.Exatas).ToList();

                dgvResultadosRodada.DataSource = pontuacoesOrdenadas;
                dgvResultadosRodada.Columns.Clear();

                DataGridViewTextBoxColumn colunaPosicao = new DataGridViewTextBoxColumn();
                colunaPosicao.HeaderText = "Posição";
                colunaPosicao.Name = "colPosicao";
                colunaPosicao.Width = 60;
                dgvResultadosRodada.Columns.Insert(0, colunaPosicao);

                DataGridViewTextBoxColumn colunaNome = new DataGridViewTextBoxColumn();
                colunaNome.DataPropertyName = "Nome";
                colunaNome.HeaderText = "Nome";
                colunaNome.Name = "colNome";
                colunaNome.Width = colunaNome.Width = dgvResultadosRodada.Width - (60 + 50 + 50);
                dgvResultadosRodada.Columns.Add(colunaNome);

                DataGridViewTextBoxColumn colunaPontos = new DataGridViewTextBoxColumn();
                colunaPontos.DataPropertyName = "Pontuacao";
                colunaPontos.HeaderText = "Pontos";
                colunaPontos.Name = "colPontos";
                colunaPontos.Width = 50;
                dgvResultadosRodada.Columns.Add(colunaPontos);

                DataGridViewTextBoxColumn colunaExatas = new DataGridViewTextBoxColumn();
                colunaExatas.DataPropertyName = "Exatas";
                colunaExatas.HeaderText = "Exatas";
                colunaExatas.Name = "colExatas";
                colunaExatas.Width = 50;
                colunaExatas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvResultadosRodada.Columns.Add(colunaExatas);

                for (int i = 1; i <= pontuacoesOrdenadas.Count; i++)
                {
                    dgvResultadosRodada.Rows[i - 1].Cells["colPosicao"].Value = i + "º";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

