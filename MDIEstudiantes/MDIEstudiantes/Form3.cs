using System;
using System.Windows.Forms;

namespace MDIEstudiantes
{
    // Formulario para mostrar la lista de estudiantes y sus asignaturas en un DataGridView.
    public partial class Form3 : Form
    {
        public Form3()
        {
            // Inicializa los componentes del formulario (controles, eventos, etc.).
            InitializeComponent();
        }

        // Evento Load del formulario: limpia el DataGridView y carga los datos desde DatosCompartidos.
        private void Form3_Load_1(object sender, EventArgs e)
        {
            // Limpiar filas previas antes de poblar con datos actuales.
            dgvDatos.Rows.Clear();

            // Si hay estudiantes almacenados, recorrerlos y mostrar cada asignatura en una fila.
            if (DatosCompartidos.Estudiantes.Count > 0)
            {
                foreach (var estudiante in DatosCompartidos.Estudiantes)
                {
                    // Por cada asignatura del estudiante, agregar una fila con carnet, nombre, asignatura y nota.
                    foreach (var asig in estudiante.Asignaturas)
                    {
                        dgvDatos.Rows.Add(estudiante.Carnet, estudiante.Nombre, asig.Nombre, asig.Nota);
                    }

                    // Agregar una fila vacía como separador entre estudiantes.
                    dgvDatos.Rows.Add("", "");
                }
            }
            else
            {
                // Informar al usuario si no hay datos cargados.
                MessageBox.Show("No hay datos de estudiante cargados.");
            }
        }

        // Evento asociado a un Label (sin implementación por ahora).
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
