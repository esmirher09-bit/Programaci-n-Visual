using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Busca entre los formularios MDI hijos si ya hay uno abierto del tipo indicado.
        // Devuelve la instancia encontrada o null si no existe.
        private Form VerificarFormularioAbierto(Type formType)
        {
            // this.MdiChildren devuelve un arreglo de formularios hijos abiertos
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == formType)
                {
                    return child;
                }
            }
            return null;
        }

        // Manejador del botón para abrir Form2.
        // Si Form2 no está abierto crea una nueva instancia, la asigna como hijo MDI y la muestra.
        // Si ya está abierta, simplemente la activa (trae al frente).
        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form abierto = VerificarFormularioAbierto(typeof(Form2));
            if (abierto == null)
            {
                Form2 f2 = new Form2();
                f2.MdiParent = this;
                f2.Show();
            }
            else
            {
                abierto.Activate();
            }
        }

        // Manejador del botón para abrir Form3.
        // Misma lógica: crear y mostrar si no existe, activar si ya existe.
        private void btnForm3_Click_1(object sender, EventArgs e)
        {
            Form abierto = VerificarFormularioAbierto(typeof(Form3));
            if (abierto == null)
            {
                Form3 f3 = new Form3();
                f3.MdiParent = this;
                f3.Show();
            }
            else
            {
                abierto.Activate();
            }
        }

        // Manejador del botón para abrir Form4.
        // Misma lógica: crear y mostrar si no existe, activar si ya existe.
        private void btnForm4_Click(object sender, EventArgs e)
        {
            Form abierto = VerificarFormularioAbierto(typeof(Form4));
            if (abierto == null)
            {
                Form4 f4 = new Form4();
                f4.MdiParent = this;
                f4.Show();
            }
            else
            {
                abierto.Activate();
            }
        }
    }
}
