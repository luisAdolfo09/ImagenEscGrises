using System.Drawing;
using System.Drawing.Imaging;

namespace ImagenEscGrises
{
    public partial class Form1 : Form
    {

        private List<Bitmap> imagenes_grises = new List<Bitmap>();
    
      
        public Form1()
        {
            InitializeComponent();
        }


        private async void btn1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            using (OpenFileDialog o = new OpenFileDialog())
            {
                o.Filter = "Archivos de tipo JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";
                o.Title = "Seleccione una imagen";
                o.Multiselect = true;


                if (o.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        Parallel.For(0, o.FileNames.Length, async i =>
                        {
                            string ruta = o.FileNames[i];
                            Bitmap imagen_orginal = new Bitmap(ruta);
                            Imagen_Gris ima = new Imagen_Gris();
                            Bitmap Imagen_gris = await ima.Imagen_final(imagen_orginal);
                            lock (Imagen_gris)
                            {
                                imagenes_grises.Add(Imagen_gris);
                            }

                        });


                        string carpetaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);



            

                        for (int i = 0; i < imagenes_grises.Count; i++)
                        {
                            string nombreArchivo = $"imagen_{i}.png";
                            string rutaCompleta = Path.Combine(carpetaEscritorio, nombreArchivo);

                            // Verificar si la imagen ya existe en el escritorio
                            if (!File.Exists(rutaCompleta))
                            {

                                imagenes_grises[i].Save(rutaCompleta, ImageFormat.Png);
                            }

                            
                        }


                        imagenes_grises.Clear();

                        MessageBox.Show($"se guardaron las imagenes en {carpetaEscritorio}");

                        pictureBox1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrio un error {ex.Message}");
                    }
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}
