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
using WindowsFormsApplication2B.Dominio;

namespace WindowsFormsApplication2B.Formularios
{
    public partial class frmCalcularResultados : Form
    {
        PalpiteAplicacao palpiteApp = new PalpiteAplicacao();
        ParticipanteAplicacao participanteApp = new ParticipanteAplicacao();
        PontuacaoPorRodadaAplicacao pontuacaoRodadaApp = new PontuacaoPorRodadaAplicacao();

        public frmCalcularResultados()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string rodada = txtRodada.Text;
                if (string.IsNullOrEmpty(rodada))
                {
                    throw new Exception("Por favor, informe a rodada!"); 
                }
                var palpites = palpiteApp.SelecionarPorRodada(rodada);
                CalculaResultados(palpites, rodada);
                CarregaGrid(rodada);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CalculaResultados(List<Palpite> palpites, string rodada)
        {
            try
            {
                if (palpites.Count < 1)
                {
                    throw new Exception("Nenhum palpite foi encontrado para esta rodada!");
                }

                var reais = palpites.Where(p => p.ParticipanteNome == "REAIS").ToList();

                if (reais.Count < 1)
                {
                    throw new Exception("Não foram encontrados os resultados reais para esta rodada!");
                }

                palpites = palpites.Where(p => p.Computado == false && p.ParticipanteNome != "REAIS").ToList();
                if(palpites.Count < 1)
                {
                    throw new Exception("Todos os palpites para esta rodada já foram calculados!");
                }

                foreach (var p in palpites)
                {
                    if (p.ParticipanteNome == "REAIS")
                    {
                        continue;
                    }

                    var real = reais.FirstOrDefault(r => r.Jogo == p.Jogo);

                    int gmReal = real.GolsMandante;
                    int gvReal = real.GolsVisitante;
                    int gmPalpite = p.GolsMandante;
                    int gvPalpite = p.GolsVisitante;

                    if(gmReal == gmPalpite && gvReal == gvPalpite)
                    {
                        var participante = participanteApp.Select(p.ParticipanteNome);
                        var pontuacaoRodada = pontuacaoRodadaApp.BuscarPorNomeERodada(participante.Nome, rodada);
                        participante.PontuacaoTotal += 10;
                        participante.Exatas++;
                        pontuacaoRodada.Pontuacao += 10;
                        pontuacaoRodada.Exatas++;
                        participanteApp.Save(participante);
                        pontuacaoRodadaApp.Save(pontuacaoRodada);
                    }
                    else if(gmReal > gvReal && gmPalpite > gvPalpite ||
                            gmReal < gvReal && gmPalpite < gvPalpite ||
                            gmReal == gvReal && gmPalpite == gvPalpite)
                    {
                        var participante = participanteApp.Select(p.ParticipanteNome);
                        var pontuacaoRodada = pontuacaoRodadaApp.BuscarPorNomeERodada(participante.Nome, rodada);
                        participante.PontuacaoTotal += 5;
                        pontuacaoRodada.Pontuacao += 5;
                        participanteApp.Save(participante);
                        pontuacaoRodadaApp.Save(pontuacaoRodada);
                    }

                    p.Computado = true;
                }
                palpiteApp.SaveAll(palpites);
                MessageBox.Show("Resultados calculados com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CarregaGrid(string rodada)
        {
            try
            {
                
                var pontuacoesRodada = pontuacaoRodadaApp.BuscarPorRodada(rodada);
                if (pontuacoesRodada.Count < 1)
                {
                    throw new Exception("Não foi possível exibir a classificação da rodada!");
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
                colunaNome.Width = dgvResultadosRodada.Width - (60 + 50 + 50);
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
            catch(Exception ex)
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
