using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagenEscGrises
{
    public interface IImagenRepository
    {
       void AgregarImagen(Imagen imagen);
        List<Imagen> CargarImagenes();
        
    };
    
}
