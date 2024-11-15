using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUTN.Dominio.Dominio
{
    public class Alumno : Identificable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Legajo { get; set; }
        public bool Deuda { get; set; }

        // Constructor con los 5 parámetros
        public Alumno(string nombre, string apellido, string dni, string legajo, bool deuda)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Legajo = legajo;
            Deuda = deuda;
        }
    }

}
