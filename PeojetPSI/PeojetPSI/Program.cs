using PeojetPSI;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
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

    }
    

}
