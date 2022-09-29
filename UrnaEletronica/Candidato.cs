using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica
{
    public class Candidato
    {
        public string? Nome { get; set; }
        public int Votos { get; set; }

        public Candidato(string nome)
        {
            Nome = nome;
            Votos = 0;
        }

        public void AdicionarVoto()
        {
            Votos++;
        }


        public int RetornarVotos()
        {
            return Votos;
        }
    }
}
