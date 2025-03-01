using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using ConsoleApp1;

class Program
{
    static void Main()
    {
        int nombreDeNoeuds = 34;
        Graphe graphe = new Graphe(nombreDeNoeuds);
        graphe.Fichier("soc-karate.txt");
        Console.WriteLine("Affichage du graphe sous forme de liste d'adjacence:");
        graphe.CréationGraphe();
        Console.WriteLine("\nMatrice d'adjacence:");
        graphe.MatriceAdjacence();

        Noeud noeudDeDepart = graphe.GetNoeuds()[0];

        Console.WriteLine("\nParcours en profondeur (DFS) :");
        graphe.ParcoursProfondeur(noeudDeDepart, new HashSet<Noeud>());

        Console.WriteLine("\nParcours en largeur (BFS) :");
        graphe.ParcoursLargeur(noeudDeDepart);

        Console.WriteLine("\nLe graphe est-il connexe ? " + graphe.EstConnexe());
        Console.WriteLine("\nLe graphe contient-il un cycle ? " + graphe.ContientCycle());

        DesignGraphe designGraphe = new DesignGraphe(nombreDeNoeuds);
        designGraphe.ChargerDepuisFichier("soc-karate.txt");

        string cheminImage = "graphe_image.png";
        designGraphe.DessinerGrapheDansImage(cheminImage);

        Console.WriteLine($"\nL'image du graphe a été sauvegardée sous '{cheminImage}'.");
    }
}
