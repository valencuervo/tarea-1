using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUTN.Dominio.Dominio
{
    public class Prestamo : Identificable
    {
        private Alumno _alumno;
        private Copia _copia;
        private DateTime _fechaPrestamo;
        private DateTime _fechaDevolucion;

        // Constructor sin parámetros
        public Prestamo() { }

        // Constructor con parámetros
        public Prestamo(Alumno alumno, Copia copia, DateTime fechaPrestamo)
        {
            this._alumno = alumno; // Asignamos el alumno al campo privado
            this._copia = copia; // Asignamos la copia al campo privado
            this._fechaPrestamo = fechaPrestamo;
            this._fechaDevolucion = CalcularFechaDevolucion(fechaPrestamo, Constants.DIAS_PRESTAMO);

            // Establecemos que el alumno tiene deuda
            this._alumno.Deuda = true;

            // Marcamos que la copia no está disponible
            this._copia.Disponible = false;
        }

        // Propiedades públicas para acceder a los campos privados
        public Alumno Alumno
        {
            get { return _alumno; }
            set { _alumno = value; }
        }

        public Copia Copia
        {
            get { return _copia; }
            set { _copia = value; }
        }

        public DateTime FechaPrestamo
        {
            get { return _fechaPrestamo; }
            set { _fechaPrestamo = value; }
        }

        public DateTime FechaDevolucion
        {
            get { return _fechaDevolucion; }
            set { _fechaDevolucion = value; }
        }

        // Método para calcular la fecha de devolución
        public DateTime CalcularFechaDevolucion(DateTime fechaDesde, int dias)
        {
            return fechaDesde.AddDays(dias);
        }
    }


}
