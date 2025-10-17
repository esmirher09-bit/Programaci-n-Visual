using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MDIEstudiantes
{
    // Formulario que calcula y muestra en un gráfico de columnas
    // los tres estudiantes con mayor promedio de notas.
    public partial class Form4 : Form
    {
        public Form4()
        {
            // Inicializa los componentes visuales del formulario.
            InitializeComponent();
        }

        // Evento Load del formulario: prepara el chart, calcula promedios y muestra los 3 mejores.
        private void Form4_Load_1(object sender, EventArgs e)
        {
            // Limpiar cualquier configuración previa del chart.
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Crear y añadir un área de dibujo principal.
            chart1.ChartAreas.Add(new ChartArea("MainArea"));

            // Configurar la serie que mostrará los promedios (columnas).
            var series = new Series("Promedios");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true; // Mostrar valor encima de cada columna.
            series.LabelFormat = "F2"; // Formato numérico con 2 decimales.

            // Lista temporal para almacenar pares (Nombre, Promedio) de cada estudiante.
            List<(string Nombre, double Promedio)> listaPromedios = new List<(string, double)>();

            // Calcular el promedio de cada estudiante que tenga asignaturas.
            foreach (var est in DatosCompartidos.Estudiantes)
            {
                if (est.Asignaturas.Count > 0)
                {
                    double promedio = est.Asignaturas.Average(a => a.Nota);
                    listaPromedios.Add((est.Nombre, promedio));
                }
            }

            // Ordenar por promedio descendente para obtener los mejores.
            listaPromedios.Sort((x, y) => y.Promedio.CompareTo(x.Promedio));

            // Agregar al gráfico hasta los 3 primeros (o menos si hay menos datos).
            for (int i = 0; i < Math.Min(3, listaPromedios.Count); i++)
            {
                series.Points.AddXY(listaPromedios[i].Nombre, listaPromedios[i].Promedio);
            }

            // Añadir la serie al chart para mostrarla en pantalla.
            chart1.Series.Add(series);
        }
    }
}

