﻿using System;
using ConsoleApp1;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    internal class Graphe
    {
        private List<Noeud> noeuds;
        public int[,] mat;
        public Graphe(int n)
        {
            this.noeuds = new List<Noeud>();
            this.mat = new int[n, n];
        }
        public List<Noeud> GetNoeuds()
        {
            return noeuds;
        }

        public int[,] GetMat()
        {
            return mat;
        }

        public void AjouterLien(Noeud noeud1, Noeud noeud2)
        {
            if (!noeuds.Contains(noeud1))
            { noeuds.Add(noeud1); }
            if (!noeuds.Contains(noeud2))
            { noeuds.Add(noeud2); }
            int id1 = noeud1.Identifiant;
            int id2 = noeud2.Identifiant;
            mat[id1, id2] = 1;
            mat[id2, id1] = 1;
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
                if (n.Identifiant == a)
                {
                    noeud = n;
                    break;
                }
            }
            if (noeud == null)
            {
                noeud = new Noeud(a, "Membre " + a);
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
        public void MatriceAdjacence()
        {
            for (int i = 0; i < this.mat.GetLength(0); i++)
            {
                for (int j = 0; j < this.mat.GetLength(1); j++)
                {
                    Console.Write(this.mat[i, j]);
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
        public bool EstConnexe()
        {
            if (noeuds.Count == 0)
            {
                return false;
            }
            HashSet<Noeud> visites = new HashSet<Noeud>(); 
            ParcoursProfondeur(noeuds[0], visites); 
        
            return visites.Count == noeuds.Count;
        }
        
        public bool ContientCycle()
        {
            HashSet<Noeud> visites = new HashSet<Noeud>();
            return ContientCycle(noeuds[0], null, visites);
        }
        
        public bool ContientCycle (Noeud noeud, Noeud parent, HashSet <Noeud> visites)
        {
            visites.Add (noeud);
            foreach (var voisin in noeud.Voisin)
            {
                if (!visites.Contains (voisin))
                {
                    if (ContientCycle(voisin, noeud, visites))
                    { return true; }
                }
                else if (voisin != parent )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
