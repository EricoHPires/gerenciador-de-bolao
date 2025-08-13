using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2B.Dominio;
using WindowsFormsApplication2B.RepositorioMySql;

namespace WindowsFormsApplication2B.Aplicacao
{
    public class ParticipanteAplicacao
    {
        private ParticipanteRepositorio participanteRepositorio;

        public ParticipanteAplicacao()
        {
            participanteRepositorio = new ParticipanteRepositorio();
        }

        public void Save (Participante participante)
        {
            var existente = participanteRepositorio.BuscarPorNome(participante.Nome);

            if(existente != null)
            {
                participanteRepositorio.Update(participante);
            }
            else
            {
                participanteRepositorio.Insert(participante);
            }

        }

        public Participante Select (string nome)
        {
            return participanteRepositorio.BuscarPorNome(nome);
        }

        public List<Participante> SelectAll ()
        {
            return participanteRepositorio.ListarTodos();
        }

        public void Delete(Participante p)
        {
            participanteRepositorio.DeletarPorNome(p.Nome);
        }
    }
}
