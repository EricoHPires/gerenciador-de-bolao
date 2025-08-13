using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2B.Aplicacao;
using WindowsFormsApplication2B.Dominio;

namespace WindowsFormsApplication2B.Formularios
{
    public partial class frmRegistrarPalpite : Form
    {
        ParticipanteAplicacao participanteApp =  new ParticipanteAplicacao();
        PalpiteAplicacao palpiteApp = new PalpiteAplicacao();
        PontuacaoPorRodadaAplicacao pontuacaoRodadaApp = new PontuacaoPorRodadaAplicacao();

        public frmRegistrarPalpite()
        {
            InitializeComponent();
        }

        private void frmRegistrarPalpite_Load(object sender, EventArgs e)
        {
            var participantes = participanteApp.SelectAll();
            Participante selecione = new Participante();
            selecione.Nome = "SELECIONE";

            List<Participante> participantesComSelecione = new List<Participante>();
            participantesComSelecione.Add(selecione);
            participantesComSelecione.AddRange(participantes);
            cmbParticipantes.DataSource = participantesComSelecione;
            cmbParticipantes.DisplayMember = "Nome";
            cmbParticipantes.ValueMember = "Nome";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbParticipantes.SelectedValue.ToString() == "SELECIONE")
                {
                    throw new Exception("Por favor, selecione o participante!");
                }
                if (string.IsNullOrEmpty(txtRodada.Text))
                {
                    throw new Exception("Por favor, informe a rodada!");
                }
                string participante = cmbParticipantes.SelectedValue.ToString();
                string rodada = txtRodada.Text;
                string palpite = txtPalpite.Text;

                //construir string
                ReceberPalpite(participante, rodada, palpite);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReceberPalpite (string participante, string rodada, string palpite)
        {
            try
            {
                List<Palpite> palpitesVerificacao = palpiteApp.SelecionarPorRodada(rodada);
                var verificacao = palpitesVerificacao.Where(p => p.ParticipanteNome == participante).ToList();
                if(verificacao.Count >= 10)
                {
                    DialogResult resposta = MessageBox.Show("Este participante já possui 10 palpites cadastrados para a rodada! Deseja inserir mais?", 
                        "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(resposta == DialogResult.No)
                    {
                        throw new Exception("Registro cancelado!");
                    }
                }
                string[] jogosSeparados = palpite.Split('\n');

                foreach (var jogo in jogosSeparados)
                {
                    var match = Regex.Match(jogo, @"^(.*?)\s*(\d+)x(\d+)\s*(.*?)$");
                    if (match.Success)
                    {
                        string mandante = match.Groups[1].Value.Replace(" ","").Trim();
                        int golsMandante = int.Parse(match.Groups[2].Value.Replace('\r', ' '));
                        int golsVisitante = int.Parse(match.Groups[3].Value.Replace('\r', ' '));
                        string visitante = match.Groups[4].Value.Replace(" ","").Trim();

                        string partida = mandante + "x" + visitante;

                        Palpite palpiteCompleto = new Palpite();
                        palpiteCompleto.ParticipanteNome = participante;
                        palpiteCompleto.Jogo = partida;
                        palpiteCompleto.Rodada = rodada;
                        palpiteCompleto.GolsMandante = golsMandante;
                        palpiteCompleto.GolsVisitante = golsVisitante;

                        palpiteApp.Save(palpiteCompleto);
                    }
                }
                txtPalpite.Text = "";
                if (!participante.Equals("REAIS"))
                {
                    PontuacaoPorRodada pontuacaoRodada = new PontuacaoPorRodada();
                    pontuacaoRodada.Nome = participante;
                    pontuacaoRodada.Rodada = rodada;
                    pontuacaoRodada.Exatas = 0;
                    pontuacaoRodada.Pontuacao = 0;
                    pontuacaoRodadaApp.Save(pontuacaoRodada);
                }
                MessageBox.Show("Palpites salvos com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
