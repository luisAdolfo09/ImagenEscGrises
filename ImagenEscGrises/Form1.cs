namespace ImagenEscGrises
{
    public partial class Form1 : Form
    {
        private readonly IImagenRepository imagenRepository;
        private Bitmap imagenOriginal;
        private Bitmap imagenGris;

        public Form1(IImagenRepository imagenRepository)
        {
            InitializeComponent();
            this.imagenRepository = imagenRepository;   
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
                        Imagen imagen = new Imagen { Name = o.FileName, ibitmap = imagenOriginal };
                        pB1.Image = imagenOriginal;
                        imagenOriginal = new Bitmap(o.FileName);
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
                foreach (int y in Enumerable.Range(0, original.Height))
                {
                    Color actual, NuevoGris;
                    actual = original.GetPixel(x, y);
                    NuevoGris = Color.FromArgb(actual.R, actual.R, actual.R);
                    imagenGris.SetPixel(x, y, NuevoGris);

                }
            });

            pB2.Image = imagenGris;
        }
        private void pB2_Click(object sender, EventArgs e)
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
