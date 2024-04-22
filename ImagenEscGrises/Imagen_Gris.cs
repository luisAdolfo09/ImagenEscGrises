using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagenEscGrises
{
    public class Imagen_Gris : Irepository
    {
        private Color[,] colores_grises;
        public async Task<Bitmap> Imagen_final(Bitmap copia)
        {
            colores_grises = await Task.Run(() => Copiar_pixeles(copia));
            return await Task.Run(() => Asignar_colores_a_prixeles(colores_grises, copia));


        }

        static Color[,] Copiar_pixeles(Bitmap imagen_original)
        {
            Color[,] pixels_gris = new Color[imagen_original.Width, imagen_original.Height];


            for (int i = 0; i < imagen_original.Height; i++)
            {

                for (int j = 0; j < imagen_original.Width; j++)
                {
                    lock (imagen_original)
                    {
                        Color color_original = imagen_original.GetPixel(j, i);
                        int color_gris_en_num = (int)(color_original.R * 0.3 + color_original.G * 0.59 + color_original.B * 0.11);
                        Color gris = Color.FromArgb(color_gris_en_num, color_gris_en_num, color_gris_en_num);
                        pixels_gris[j, i] = gris;
                    }
                }


            } 
            return pixels_gris;
        }

        static Bitmap Asignar_colores_a_prixeles(Color[,] prixeles_gris, Bitmap Imagen_original)
        {
            Bitmap Imagen_gris = new Bitmap(Imagen_original.Width, Imagen_original.Height);      
                for (int i = 0; i < Imagen_gris.Height; i++)
                {
                    for (int j = 0; j < Imagen_gris.Width; j++)
                    {
                        lock (Imagen_gris)
                        {
                            Color prixel_gris = prixeles_gris[j, i];
                            Imagen_gris.SetPixel(j, i, prixel_gris);
                        }
                    } 
                }
            return Imagen_gris;
        }




    }


}

