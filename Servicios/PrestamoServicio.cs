using BibliotecaUTN.Dominio.Dominio;

namespace BibliotecaUTN.Servicios
{
    public class PrestamoServicio
    {
        internal static void Actualizar()
        {
            Console.WriteLine("Vamos a hacer una devolución");
        }

        internal static void Crear()
        {
            Console.WriteLine("Vamos a crear un préstamo");

            Console.Write("Ingrese el DNI del alumno: ");
            string dni = Console.ReadLine();

            
            Alumno alumno = null;
            foreach (var a in FactoryObjects.GenerarAlumnos())
            {
                if (a.Dni == dni)
                {
                    alumno = a;
                    break;
                }
            }

            if (alumno == null)
            {
                Console.WriteLine("Alumno no encontrado.");
                return;
            }

            
            bool tienePrestamo = false;
            foreach (var prestamo in FactoryObjects.GenerarPrestamos())
            {
                if (prestamo.Alumno.Id == alumno.Id && prestamo.FechaDevolucion == null)
                {
                    tienePrestamo = true;
                    break;
                }
            }

            if (tienePrestamo)
            {
                Console.WriteLine("El alumno ya tiene un libro prestado.");
                return;
            }

            
            Console.Write("Ingrese el ISBN del libro a alquilar: ");
            string isbn = Console.ReadLine();

          
            Libro libro = FactoryObjects.BuscarLibroPorISBN(isbn);

            if (libro == null)
            {
                Console.WriteLine("Libro no encontrado.");
                return;
            }

            
            Copia copiaDisponible = null;
            foreach (var copia in libro.Copias)
            {
                if (copia.Disponible)
                {
                    copiaDisponible = copia;
                    break;
                }
            }

            if (copiaDisponible == null)
            {
                Console.WriteLine("No hay copias disponibles de este libro.");
                return;
            }

            
            DateTime fechaPrestamo = DateTime.Now;
            Prestamo nuevoPrestamo = new Prestamo(alumno, copiaDisponible, fechaPrestamo);

            
            copiaDisponible.Disponible = false;
            alumno.Deuda = true; 

            Console.WriteLine($"El libro '{libro.Titulo}' ha sido alquilado exitosamente a {alumno.Nombre} {alumno.Apellido}.");
        }


        internal static void Listar()
        {
            Console.WriteLine("Informar alumnos con deudas retrasadas:");
            List<Alumno> alumnos = FactoryObjects.GenerarAlumnos();  
            bool hayDeudas = false;

            foreach (var alumno in alumnos)
            {
               
                if (alumno.Deuda)
                {
                    Console.WriteLine($"{alumno.Nombre} {alumno.Apellido} - DNI: {alumno.Dni} - Legajo: {alumno.Legajo}");
                    hayDeudas = true;
                }
            }

            
            if (!hayDeudas)
            {
                Console.WriteLine("No hay alumnos con deudas.");
            }
        }
    }


}
