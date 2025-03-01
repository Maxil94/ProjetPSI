using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ConsoleApp1
{
    internal class DesignGraphe
    {
        private Graphe graphe;
        private int width = 800;  // Largeur de l'image
        private int height = 600; // Hauteur de l'image

        public DesignGraphe(int n)
        {
            this.graphe = new Graphe(n);
        }

        // Charger les données depuis le fichier et créer les liens
        public void ChargerDepuisFichier(string fichier)
        {
            graphe.Fichier(fichier);
        }

        // Dessiner le graphe dans un fichier image
        public void DessinerGrapheDansImage(string cheminImage)
        {
            // Créer un Bitmap pour dessiner le graphe
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // Fond blanc
                Pen pen = new Pen(Color.Black, 2);
                Brush brush = new SolidBrush(Color.Blue);

                // Taille des noeuds
                int nodeRadius = 20;

                // Calculer la position des noeuds
                int nodeSpacing = 50;
                int nodesPerRow = 10; // Limiter le nombre de noeuds par ligne
                int xOffset = 50, yOffset = 50;

                // Dessiner chaque noeud et les connexions
                for (int i = 0; i < graphe.GetNoeuds().Count; i++)
                {
                    Noeud noeud = graphe.GetNoeuds()[i];

                    // Calculer la position des noeuds
                    int x = xOffset + (i % nodesPerRow) * (nodeRadius * 3);
                    int y = yOffset + (i / nodesPerRow) * (nodeRadius * 3);

                    // Dessiner les noeuds
                    g.FillEllipse(brush, x, y, nodeRadius * 2, nodeRadius * 2);
                    g.DrawEllipse(pen, x, y, nodeRadius * 2, nodeRadius * 2);
                    g.DrawString(noeud.Identifiant.ToString(), new Font("Arial", 10), Brushes.White, x + nodeRadius / 2, y + nodeRadius / 2);

                    // Dessiner les liens entre les noeuds
                    foreach (Noeud voisin in noeud.Voisin)
                    {
                        int voisinIndex = graphe.GetNoeuds().IndexOf(voisin);
                        int xVoisin = xOffset + (voisinIndex % nodesPerRow) * (nodeRadius * 3);
                        int yVoisin = yOffset + (voisinIndex / nodesPerRow) * (nodeRadius * 3);

                        // Dessiner une ligne entre les noeuds
                        g.DrawLine(pen, x + nodeRadius, y + nodeRadius, xVoisin + nodeRadius, yVoisin + nodeRadius);
                    }
                }
            }

            // Sauvegarder l'image dans un fichier
            bitmap.Save(cheminImage);
        }
    }
}
