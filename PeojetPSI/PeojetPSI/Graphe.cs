using System;
using System.Collections.Generic;
using System.IO;

namespace PeojetPSI
{
    internal class Graphe
    {
        private List<Noeud> noeuds;
        private List<Lien> liens;

        public Graphe()
        {
            this.noeuds = new List<Noeud>();
            this.liens = new List<Lien>();
        }

        public void AjouterLien(Noeud noeud1, Noeud noeud2)
        {
            if (!noeuds.Contains(noeud1)) 
            { noeuds.Add(noeud1); }
            if(!noeuds.Contains (noeud2)) 
            { noeuds.Add (noeud2); }
            Lien lien = new Lien(noeud1, noeud2);
            this.liens.Add(lien);
            noeud1.Voisin.Add(noeud2);
            noeud2.Voisin.Add(noeud1);
        }

        public void Fichier(string fichier)
        {
            foreach (string ligne in File.ReadLines(fichier))
            {
                string[] parties = ligne.Split('\t'); 
                string[] noeuds = parties[0].Trim().Trim('(', ')').Split(',');

                int a = int.Parse(noeuds[0].Trim());
                int b = int.Parse(noeuds[1].Trim());
                Noeud noeud1 = CreerNoeud(a);
                Noeud noeud2 = CreerNoeud(b);
                AjouterLien(noeud1, noeud2);
            }
        }
            public Noeud CreerNoeud(int a)
            {
            Noeud noeud = null;
            foreach (var n in noeuds)
            {
                if(n.Identifiant == a)
                {
                    noeud = n; 
                    break;
                }
            }
            if(noeud == null)
            {
                noeud = new Noeud(a,"Membre " + a);
                noeuds.Add(noeud);
            }
            return noeud;
            }

        public void CréationGraphe()
        {
            foreach (var noeud in noeuds)
            {
                Console.Write($"{noeud.Identifiant} -> ");
                for (int i = 0; i < noeud.Voisin.Count; i++)
                {
                    Console.Write(noeud.Voisin[i].Identifiant);
                    if (i < noeud.Voisin.Count - 1)
                        Console.Write(" - ");
                }
                Console.WriteLine();
            }
        }
        public void ParcoursProfondeur(Noeud noeud, HashSet<Noeud> visites)
        {
            if (visites.Contains(noeud))
                return;
            Console.Write(noeud.Identifiant + " ");
            visites.Add(noeud);
            foreach (var voisin in noeud.Voisin)
            {
                ParcoursProfondeur(voisin, visites);
            }
        }
        
        public void ParcoursLargeur(Noeud depart)
        {
            Queue<Noeud> file = new Queue<Noeud>();
            HashSet<Noeud> visites = new HashSet<Noeud>();
        
            file.Enqueue(depart);
            visites.Add(depart);
        
            while (file.Count > 0)
            {
                Noeud actuel = file.Dequeue();
                Console.Write(actuel.Identifiant + " ");
        
                foreach (var voisin in actuel.Voisin)
                {
                    if (!visites.Contains(voisin))
                    {
                        file.Enqueue(voisin);
                        visites.Add(voisin);
                    }
                }
            }
        }
    }

    
}
