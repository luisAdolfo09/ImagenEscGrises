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
            pB1 = new PictureBox();
            pB2 = new PictureBox();
            btn2 = new Button();
            btn1 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pB1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pB2).BeginInit();
            SuspendLayout();
            // 
            // pB1
            // 
            pB1.Location = new Point(29, 56);
            pB1.Name = "pB1";
            pB1.Size = new Size(435, 356);
            pB1.SizeMode = PictureBoxSizeMode.Zoom;
            pB1.TabIndex = 0;
            pB1.TabStop = false;
            pB1.Click += pictureBox1_Click;
            // 
            // pB2
            // 
            pB2.Location = new Point(595, 56);
            pB2.Name = "pB2";
            pB2.Size = new Size(450, 356);
            pB2.SizeMode = PictureBoxSizeMode.AutoSize;
            pB2.TabIndex = 1;
            pB2.TabStop = false;
            pB2.Click += pB2_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(486, 127);
            btn2.Name = "btn2";
            btn2.Size = new Size(90, 188);
            btn2.TabIndex = 2;
            btn2.Text = "Cambiar color a escala de grises ---->";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(29, 418);
            btn1.Name = "btn1";
            btn1.Size = new Size(435, 59);
            btn1.TabIndex = 3;
            btn1.Text = "Cargar Imagen";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(162, 20);
            label1.Name = "label1";
            label1.Size = new Size(136, 24);
            label1.TabIndex = 4;
            label1.Text = "Imagen Orinigal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(707, 20);
            label2.Name = "label2";
            label2.Size = new Size(210, 24);
            label2.TabIndex = 5;
            label2.Text = "Imagen Convertida a Gris";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 489);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(pB2);
            Controls.Add(pB1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pB1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pB2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pB1;
        private PictureBox pB2;
        private Button btn2;
        private Button btn1;
        private Label label1;
        private Label label2;
    }
}
