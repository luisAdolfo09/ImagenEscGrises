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

                        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                        {
                            folderBrowserDialog.Description = "Selecciona un directorio para guardar las imágenes.";

                            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                            {
                                string directorio = folderBrowserDialog.SelectedPath;

                                foreach (Bitmap imagen in imagenes_grises)
                                {
                                    string nombreArchivo = "imagen_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
                                    string rutaCompleta = System.IO.Path.Combine(directorio, nombreArchivo);
                                    imagen.Save(rutaCompleta, System.Drawing.Imaging.ImageFormat.Png);
                                }

                                MessageBox.Show("Las imágenes se han guardado exitosamente en el directorio seleccionado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }




                        imagenes_grises.Clear();

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
