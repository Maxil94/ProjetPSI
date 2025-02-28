using System;
using System.Collections.Generic;
using System.IO;

namespace PeojetPSI
{
    internal class Noeud
    {
        private int identifiant;
        private List<Noeud> voisin;

        public Noeud(int identifiant, string nom)
        {
            this.identifiant = identifiant;
            this.voisin = new List<Noeud>();
        }
        public int Identifiant
        {
            get { return identifiant; }
        }

        public List<Noeud> Voisin
        {
            get { return voisin; }
        }
    }
}
