using System.Drawing;
using System.Drawing.Imaging;

namespace ImagenEscGrises
{
    public partial class Form1 : Form
    {

        private List<Bitmap> imagenes_grises = new List<Bitmap>();
        private Bitmap copia;
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
                        foreach (string rutas in o.FileNames)
                        {
                            copia = new Bitmap(rutas);

                            Task<Bitmap> gris = Task.Run(() =>
                            {
                                Imagen_Gris im = new Imagen_Gris(); return im.Imagen_final(copia);
                            });

                            imagenes_grises.Add(await gris);

                        }

                        string carpetaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);



                        for (int i = 0; i < imagenes_grises.Count; i++)
                        {
                            string nombreArchivo = $"imagen_{i}.png";
                            string rutaCompleta = Path.Combine(carpetaEscritorio, nombreArchivo);


                            imagenes_grises[i].Save(rutaCompleta, ImageFormat.Png);
                        }

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
