namespace ImagenEscGrises
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_cargar_imagen = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_cargar_imagen
            // 
            btn_cargar_imagen.Location = new Point(58, 34);
            btn_cargar_imagen.Margin = new Padding(3, 2, 3, 2);
            btn_cargar_imagen.Name = "btn_cargar_imagen";
            btn_cargar_imagen.Size = new Size(273, 50);
            btn_cargar_imagen.TabIndex = 3;
            btn_cargar_imagen.Text = "Cargar Imagen";
            btn_cargar_imagen.UseVisualStyleBackColor = true;
            btn_cargar_imagen.Click += btn1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(94, 107);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 331);
            Controls.Add(pictureBox1);
            Controls.Add(btn_cargar_imagen);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pB2;
        private Button btn2;
        private Button btn_cargar_imagen;
        private PictureBox pictureBox1;
    }
}
