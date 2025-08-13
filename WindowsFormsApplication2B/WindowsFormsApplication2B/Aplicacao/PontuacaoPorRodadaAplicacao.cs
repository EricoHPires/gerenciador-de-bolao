using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2B.Dominio;
using WindowsFormsApplication2B.RepositorioMySql;

namespace WindowsFormsApplication2B.Aplicacao
{
    class PontuacaoPorRodadaAplicacao
    {
        private readonly PontuacaoPorRodadaRepositorio repositorio = new PontuacaoPorRodadaRepositorio();

        public void Save(PontuacaoPorRodada p)
        {
            if (p.Id == 0)
            {
                var existente = repositorio.BuscarPorNomeRodada(p.Nome, p.Rodada);
                if (existente == null)
                    repositorio.Insert(p);
                else
                {
                    p.Id = existente.Id; 
                    repositorio.Update(p);
                }
            }
            else
            {
                repositorio.Update(p);
            }
        }

        public List<PontuacaoPorRodada> SelectAll()
        {
            return repositorio.SelectAll();
        }

        public PontuacaoPorRodada BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        public List<PontuacaoPorRodada> BuscarPorRodada(string rodada)
        {
            return repositorio.BuscarPorRodada(rodada);
        }

        public PontuacaoPorRodada BuscarPorNomeERodada(string nome, string rodada)
        {
            return repositorio.BuscarPorNomeRodada(nome, rodada);
        }

        public void DeletarPorId(int id)
        {
            repositorio.DeletarPorId(id);
        }
    }

}
