using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace PeojetPSI
{
    internal class VisualisationGraphe
    {
        private Graphe graphe;
        private Dictionary<int, Point> positions;

        public VisualisationGraphe(Graphe g)
        {
            graphe = g;
            positions = new Dictionary<int, Point>();
            GenererPositions();
        }

        // Génère des positions aléatoires pour chaque nœud dans un espace de 600x600
        private void GenererPositions()
        {
            Random rand = new Random();
            foreach (var noeud in graphe.GetNoeuds())
            {
                positions[noeud.Identifiant] = new Point(rand.Next(50, 550), rand.Next(50, 550));
            }
        }

        // Dessine le graphique et sauvegarde l'image
        public void Dessiner(string fichierSortie)
        {
            // Crée une image de 600x600 pixels
            using (Bitmap bitmap = new Bitmap(600, 600))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // Fond blanc

                Pen pen = new Pen(Color.Black, 2);
                Brush brush = new SolidBrush(Color.Blue);
                Font font = new Font("Arial", 12);

                // Dessiner les arêtes (liens)
                foreach (var lien in graphe.GetLiens())
                {
                    Point position1 = positions[lien.Noeud1.Identifiant];
                    Point position2 = positions[lien.Noeud2.Identifiant];
                    g.DrawLine(pen, position1, position2);
                }

                // Dessiner les nœuds
                foreach (var noeud in graphe.GetNoeuds())
                {
                    Point position = positions[noeud.Identifiant];
                    g.FillEllipse(brush, position.X - 10, position.Y - 10, 20, 20);
                    g.DrawString(noeud.Identifiant.ToString(), font, Brushes.White, position.X - 5, position.Y - 5);
                }

                // Sauvegarder l'image dans un fichier
                bitmap.Save(fichierSortie);
            }

            Console.WriteLine($"Graphique sauvegardé dans {fichierSortie}");
        }
    
}
}
