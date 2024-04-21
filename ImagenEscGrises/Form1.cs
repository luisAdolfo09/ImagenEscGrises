using System.Drawing;

namespace ImagenEscGrises
{
    public partial class Form1 : Form
    {
        private IImagenRepository imagenRepository = new CargarImagenRepository();
        private Bitmap imagenOriginal;
        private Bitmap? imagenGris;

        public Form1()
        {
            InitializeComponent();
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog o = new OpenFileDialog())
            {
                o.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";
                o.Title = "Seleccione una imagen";

                if (o.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        imagenOriginal = new Bitmap(o.FileName);
                        Imagen imagen = new Imagen { Name = o.FileName, ibitmap = imagenOriginal };
                        pB1.Image = imagenOriginal;
                        
                        pB2.Image = null;
                        imagenGris = null;

                        imagenRepository.AgregarImagen(imagen);
                    }
                    catch (IOException)
                    {

                        MessageBox.Show("Error al intentar cargar la imagen");
                    }

                }

            }
        }

        private void CambiarPixelesGrises(Imagen imagen)
        {
            Bitmap original = imagen.ibitmap;


           
            imagenGris = new Bitmap(original.Width, original.Height);

            
            Parallel.For(0, original.Width, x =>
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color color = original.GetPixel(x, y);


                    int gris = (int)(color.R + color.R + color.R);

                    
                    Color grisColor = Color.FromArgb(gris, gris, gris);

                    
                    imagenGris.SetPixel(x, y, grisColor);
                }
            });
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            List<Imagen> imagenes = imagenRepository.CargarImagenes();
            if (imagenes.Count > 0)
            {
                Parallel.ForEach(imagenes, imagen =>
                {
                    CambiarPixelesGrises(imagen);
                });
            }
            else
            {
                MessageBox.Show("Primero debes cargar una imagen.");
            }
        }
        private void pB2_Click(object sender, EventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
