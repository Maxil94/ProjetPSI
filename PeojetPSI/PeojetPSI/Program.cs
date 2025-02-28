using PeojetPSI;
using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main()
    {
        Graphe graphe = new Graphe();
        graphe.Fichier("soc-karate.txt");
        Noeud noeud1 = graphe.CreerNoeud(1);
        Noeud noeud2 = graphe.CreerNoeud(2);
        graphe.AjouterLien(noeud1, noeud2);
        graphe.CréationGraphe();

        ///Console.WriteLine("Parcours en profondeur:");
        ///graphe.ParcoursProfondeur(1);

        ///Console.WriteLine("Parcours en largeur:");
        ///graphe.ParcoursLargeur(1);

        ///Console.WriteLine("Le graphe est-il connexe? " + graphe.EstConnexe());
        ///Console.WriteLine("Le graphe contient-il un cycle? " + graphe.ContientCycle());
    }
}
