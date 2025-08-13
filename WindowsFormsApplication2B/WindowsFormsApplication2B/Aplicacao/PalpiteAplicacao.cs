using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2B.Dominio;
using WindowsFormsApplication2B.RepositorioMySql;

namespace WindowsFormsApplication2B.Aplicacao
{
    public class PalpiteAplicacao
    {
        private PalpiteRepositorio palpiteRepositorio;

        public PalpiteAplicacao()
        {
            palpiteRepositorio = new PalpiteRepositorio();
        }

        public void Save(Palpite palpite)
        {
            var existente = palpiteRepositorio.BuscarPorId(palpite.Id);

            if (existente != null)
            {
                palpiteRepositorio.Update(palpite);
            }
            else
            {
                palpiteRepositorio.Insert(palpite);
            }
        }

        public void SaveAll(List<Palpite> palpites)
        {
            foreach (var p in palpites)
            {
                Save(p);
            }
        }

        public Palpite Select(int id)
        {
            return palpiteRepositorio.BuscarPorId(id);
        }

        public List<Palpite> SelecionarPorRodada(string rodada)
        {
            return palpiteRepositorio.BuscarPorRodada(rodada);
        }

        public void Delete(Palpite p)
        {
            palpiteRepositorio.DeletarPorId(p.Id);
        }
    }
}
