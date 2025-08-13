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
using WindowsFormsApplication2B.Formularios;

namespace WindowsFormsApplication2B
{
    public partial class frmPrincipal : Form
    {
        ParticipanteAplicacao participanteApp = new ParticipanteAplicacao();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarParticipante_Click(object sender, EventArgs e)
        {
            frmCadastrarParticipante cadastrarParticipante = new frmCadastrarParticipante();
            cadastrarParticipante.Show();
        }

        private void btnRegistrarPalpite_Click(object sender, EventArgs e)
        {
            frmRegistrarPalpite registrarPalpite = new frmRegistrarPalpite();
            registrarPalpite.Show();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            frmCalcularResultados calcular = new frmCalcularResultados();
            calcular.Show();
        }

        private void btnPontuacaoRodada_Click(object sender, EventArgs e)
        {
            frmPontuacaoRodada frmPontRodada = new frmPontuacaoRodada();
            frmPontRodada.Show();
        }
    }
}
