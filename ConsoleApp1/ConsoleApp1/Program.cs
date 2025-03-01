using System;
using System.Collections.Generic;
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


        DesignGraphe designGraphe = new DesignGraphe(nombreDeNoeuds);

        // Charger les données dans DesignGraphe
        designGraphe.ChargerDepuisFichier("soc-karate.txt");

        // Dessiner le graphe dans un fichier image
        string cheminImage = "graphe_image.png";  // Spécifiez le chemin et le nom du fichier
        designGraphe.DessinerGrapheDansImage(cheminImage);

        // Message confirmant la sauvegarde de l'image
        Console.WriteLine($"\nL'image du graphe a été sauvegardée sous '{cheminImage}'.");

    }


}
