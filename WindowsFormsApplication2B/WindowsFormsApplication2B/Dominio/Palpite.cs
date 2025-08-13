using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2B.Dominio
{
    public class Palpite
    {
        public int Id { get; set; }
        public string ParticipanteNome { get; set; }
        public string Rodada { get; set; }
        public string Jogo { get; set; }
        public int GolsMandante { get; set; }
        public int GolsVisitante { get; set; }
        public bool Computado { get; set; } = false;
    }
}
