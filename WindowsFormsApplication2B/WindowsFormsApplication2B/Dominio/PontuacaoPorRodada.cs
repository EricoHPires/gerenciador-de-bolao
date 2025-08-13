using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2B.Dominio
{
    public class PontuacaoPorRodada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rodada { get; set; }
        public int Pontuacao { get; set; } 
        public int Exatas { get; set; }
    }
}
