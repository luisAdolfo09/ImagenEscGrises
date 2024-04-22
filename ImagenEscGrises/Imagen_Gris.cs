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
        public async Task<Bitmap> Imagen_final(Bitmap imagenOriginal)
        {
            return await Task.Run(() =>
            {
                Color[,] coloresGris = CopiarPixeles(imagenOriginal);
                return AsignarColoresAPixeles(coloresGris, imagenOriginal);
            });

        }

        private Color[,] CopiarPixeles(Bitmap imagenOriginal)
        {
            Color[,] pixelsGris = new Color[imagenOriginal.Width, imagenOriginal.Height];

            for (int i = 0; i < imagenOriginal.Height; i++)
            {
                for (int j = 0; j < imagenOriginal.Width; j++)
                {
                    Color colorOriginal = imagenOriginal.GetPixel(j, i);
                    int colorGris = (int)(colorOriginal.R * 0.3 + colorOriginal.G * 0.59 + colorOriginal.B * 0.11);
                    Color gris = Color.FromArgb(colorGris, colorGris, colorGris);
                    pixelsGris[j, i] = gris;
                }
            }
            return pixelsGris;
        }

        private Bitmap AsignarColoresAPixeles(Color[,] pixelesGris, Bitmap imagenOriginal)
        {
            Bitmap imagenGris = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int i = 0; i < imagenGris.Height; i++)
            {
                for (int j = 0; j < imagenGris.Width; j++)
                {
                    Color pixelGris = pixelesGris[j, i];
                    imagenGris.SetPixel(j, i, pixelGris);
                }
            }
            return imagenGris;
        }

       
    }


}

