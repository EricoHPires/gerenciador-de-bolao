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
    public partial class frmCadastrarParticipante : Form
    {
        ParticipanteAplicacao participanteApp = new ParticipanteAplicacao();

        public frmCadastrarParticipante()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Participante participante = new Participante();
                participante.Nome = txtNovoParticipante.Text;
                participante.Exatas = 0;
                participante.PontuacaoTotal = 0;
                var existe = participanteApp.Select(participante.Nome);
                if (string.IsNullOrEmpty(participante.Nome))
                {
                    throw new Exception("Digite o nome do participante!");
                }
                if (existe != null)
                {
                    throw new Exception("Já existe um participante com este nome!");
                }
                participanteApp.Save(participante);
                txtNovoParticipante.Text = "";
                MessageBox.Show("Participante cadastrado com sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
