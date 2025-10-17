using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDIEstudiantes
{
    // Modelo que representa a un estudiante con su carnet, nombre y lista de asignaturas.
    public class Estudiante
    {
        // Identificador del estudiante (por ejemplo, número de carnet).
        public string Carnet { get; set; }

        // Nombre completo del estudiante.
        public string Nombre { get; set; }

        // Lista de asignaturas asociadas al estudiante.
        // Se inicializa por defecto para evitar referencias nulas al agregar asignaturas.
        public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    }

    // Modelo que representa una asignatura con su nombre y la nota obtenida.
    public class Asignatura
    {
        // Nombre de la asignatura (materia).
        public string Nombre { get; set; }

        // Nota numérica de la asignatura. Usar double para permitir decimales.
        public double Nota { get; set; }
    }

    // Almacenamiento compartido en memoria para la aplicación MDI.
    // Contiene la lista global de estudiantes que consumen los distintos formularios.
    public static class DatosCompartidos
    {
        // Colección global de estudiantes. Inicializada vacía al inicio de la aplicación.
        public static List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
