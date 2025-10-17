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
    // Formulario para capturar un nuevo estudiante y sus asignaturas.
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Manejador del botón "Guardar".
        // Crea un objeto Estudiante con los datos del formulario,
        // recorre las filas del DataGridView de asignaturas y agrega
        // cada asignatura válida a la lista del estudiante.
        // Finalmente añade el estudiante a DatosCompartidos y cierra el formulario.
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Crear y poblar el objeto Estudiante con los campos del formulario.
            Estudiante estudiante = new Estudiante
            {
                Carnet = txtCarnet.Text,
                Nombre = txtNombre.Text
            };

            // Recorrer las filas del DataGridView para obtener asignaturas y notas.
            foreach (DataGridViewRow fila in dgvAsignaturas.Rows)
            {
                // Verificar que las celdas de nombre y nota no estén vacías.
                if (fila.Cells[0].Value != null && fila.Cells[1].Value != null)
                {
                    estudiante.Asignaturas.Add(new Asignatura
                    {
                        Nombre = fila.Cells[0].Value.ToString(),
                        Nota = Convert.ToDouble(fila.Cells[1].Value)
                    });
                }
            }

            // Agregar el estudiante a la colección compartida de la aplicación.
            DatosCompartidos.Estudiantes.Add(estudiante);

            // Informar al usuario y cerrar el formulario de captura.
            MessageBox.Show("Datos guardados correctamente");
            this.Close();
        }

        // Evento del textbox Carnet (actualmente sin implementación).
        private void txtCarnet_TextChanged(object sender, EventArgs e)
        {

        }

        // Evento para clicks en celdas del DataGridView (sin implementación actual).
        private void dgvAsignaturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
