using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagenEscGrises
{
    public class CargarImagenRepository : IImagenRepository
    {
        private List<Imagen> imagenes = new List<Imagen>();
        public void AgregarImagen(Imagen imagen)
        {
            imagenes.Add(imagen);
        }

        public List<Imagen> CargarImagenes()
        {
            return imagenes;
        }
    }
}
