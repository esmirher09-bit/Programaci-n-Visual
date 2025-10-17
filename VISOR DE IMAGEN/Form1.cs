using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISOR_DE_IMAGEN
{
    public partial class Form1 : Form
    {
        private List<string> listaImagenes = new List<string>();
        private int indiceActual = 0;

        private Bitmap originalImage = null;

        private enum VisionMode { Normal, EscalaGris }
        private VisionMode visionActual = VisionMode.Normal;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string ruta = @"C:\Users\esmir\OneDrive\Imágenes\Camera";

            DirectoryInfo dir = new DirectoryInfo(ruta);
            foreach (string ext in new string[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" })
            {
                foreach (FileInfo file in dir.GetFiles(ext))
                {
                    listaImagenes.Add(file.FullName);
                    cmbImagenes.Items.Add(file.Name);           
                    
                }
            }

            if (listaImagenes.Count > 0)
            {
                indiceActual = 0;
                MostrarImagen();
            }
        }

        private void MostrarImagen()
        {
            if (indiceActual < 0 || indiceActual >= listaImagenes.Count) return;

            string ruta = listaImagenes[indiceActual];

            if (originalImage != null)
            {
                originalImage.Dispose();
                originalImage = null;
            }

            using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            {
                using (Image tmp = Image.FromStream(fs))
                {
                    originalImage = new Bitmap(tmp);
                }
            }

            AplicarVision();

            cmbImagenes.SelectedIndex = indiceActual;
            lblRuta.Text = ruta;
        }


        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visualizadorImagen.Image != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    visualizadorImagen.Image.Save(save.FileName);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visionActual = VisionMode.Normal;
            AplicarVision();

            normalToolStripMenuItem.Checked = true;
            escalaGrisToolStripMenuItem.Checked = false;
        }

        private void escalaGrisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visionActual = VisionMode.EscalaGris;
            AplicarVision();
            escalaGrisToolStripMenuItem.Checked = true;
            normalToolStripMenuItem.Checked = false;
        }

        private void AplicarVision()
        {
            if (originalImage == null) return;


            if (visualizadorImagen.Image != null)
            {
                var old = visualizadorImagen.Image;
                visualizadorImagen.Image = null;
                old.Dispose();
            }

            if (visionActual == VisionMode.Normal)
            {
                visualizadorImagen.Image = new Bitmap(originalImage);
            }
            else
            {
                Bitmap bmp = new Bitmap(originalImage.Width, originalImage.Height);

                ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                    new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                    new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    using (ImageAttributes ia = new ImageAttributes())
                    {
                        ia.SetColorMatrix(cm);
                        g.DrawImage(originalImage, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                    0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, ia);
                    }
                }

                visualizadorImagen.Image = bmp;
            }

            checknormal.Checked = (visionActual == VisionMode.Normal);
            checkescalaGris.Checked = (visionActual == VisionMode.EscalaGris);
            normalToolStripMenuItem.Checked = (visionActual == VisionMode.Normal);
            escalaGrisToolStripMenuItem.Checked = (visionActual == VisionMode.EscalaGris);
        }




        private void centradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizadorImagen.SizeMode = PictureBoxSizeMode.CenterImage;

            radioCentrada.Checked = true;
            radioAjustar.Checked = false;
            radioZoom.Checked = false;

            centradaToolStripMenuItem.Checked = true;
            ajustarToolStripMenuItem.Checked = false;
            zoonToolStripMenuItem.Checked = false;
        }

        private void ajustarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizadorImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            radioCentrada.Checked = false;
            radioAjustar.Checked = true;
            radioZoom.Checked = false;

            centradaToolStripMenuItem.Checked = false;
            ajustarToolStripMenuItem.Checked = true;
            zoonToolStripMenuItem.Checked = false;
        }

        private void zoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizadorImagen.SizeMode = PictureBoxSizeMode.Zoom;

            radioCentrada.Checked = false;
            radioAjustar.Checked = false;
            radioZoom.Checked = true;

            centradaToolStripMenuItem.Checked = false;
            ajustarToolStripMenuItem.Checked = false;
            zoonToolStripMenuItem.Checked = true;
        }

        private void normalbtn_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem_Click(sender, e);
        }

        private void escalaGrisbtn_Click(object sender, EventArgs e)
        {
            escalaGrisToolStripMenuItem_Click(sender, e);
        }

        private void centradabtn_Click(object sender, EventArgs e)
        {
            
            centradaToolStripMenuItem_Click(sender, e);
        }

        private void ajustarbtn_Click(object sender, EventArgs e)
        {
            ajustarToolStripMenuItem_Click(sender, e);
        }

        private void zoombtn_Click(object sender, EventArgs e)
        {
            zoonToolStripMenuItem_Click(sender, e );
        }

        private void checknormal_CheckedChanged(object sender, EventArgs e)
        {
            if (checknormal.Checked)
            {
                normalToolStripMenuItem_Click(sender, e);
            }
                
        }

        private void checkescalaGris_CheckedChanged(object sender, EventArgs e)
        {
            if (checkescalaGris.Checked)
            {
                escalaGrisToolStripMenuItem_Click(sender, e);
            }
        }

        private void radioCentrada_CheckedChanged(object sender, EventArgs e)
        {
            if(radioCentrada.Checked)
            {
                centradaToolStripMenuItem_Click(sender, e);
            }
        }

        private void radioAjustar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAjustar.Checked)
            {
                ajustarToolStripMenuItem_Click(sender, e);
            }
        }

        private void radioZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioZoom.Checked)
            {
                zoonToolStripMenuItem_Click(sender, e);
            }
        }

        private void cmbImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            indiceActual = cmbImagenes.SelectedIndex;
            MostrarImagen();
        }

        private void visualizadorImagen_Click(object sender, EventArgs e)
        {

        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            indiceActual = 0;
            MostrarImagen();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
            }
            MostrarImagen();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indiceActual < listaImagenes.Count - 1)
            {
                indiceActual++;
            }
            MostrarImagen();
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            indiceActual = listaImagenes.Count - 1;
            MostrarImagen();
        }

        private void lblRuta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblRuta.Text) && File.Exists(lblRuta.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + lblRuta.Text + "\"");
            }
        }
        private void girarIzquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visualizadorImagen.Image != null)
            {
                visualizadorImagen.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                visualizadorImagen.Refresh();
            }
        }

        private void girarDerechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visualizadorImagen.Image != null)
            {
                visualizadorImagen.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                visualizadorImagen.Refresh();
            }
        }

        private void girar90ALaIzquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visualizadorImagen.Image != null)
            {
                visualizadorImagen.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                visualizadorImagen.Refresh();
            }
        }

        private void girar90ALaDerechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visualizadorImagen.Image != null)
            {
                visualizadorImagen.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                visualizadorImagen.Refresh();
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visualizadorImagen.Image != null)
            {
                Clipboard.SetImage(visualizadorImagen.Image);
                MessageBox.Show("Imagen copiada al portapapeles",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
