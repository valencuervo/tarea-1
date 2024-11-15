using BibliotecaUTN.Dominio.Dominio;

namespace BibliotecaUTN
{
    public class FactoryObjects
    {
        private static string rutaLibros = "libros.txt";

        /**
         * Este método carga los libros desde el archivo "libros.txt".
         */
        public static List<Libro> GenerarLibros()
        {
            List<Libro> libros = new List<Libro>();

            
            if (File.Exists(rutaLibros))
            {
               
                string[] lineas = File.ReadAllLines(rutaLibros);

                foreach (var linea in lineas)
                {
                    
                    string[] datos = linea.Split(new[] { "\", \"" }, StringSplitOptions.None);

                    if (datos.Length == 4)
                    {
                        string titulo = datos[0].Replace("\"", "").Trim();  
                        string isbn = datos[1].Replace("\"", "").Trim();    
                        string autor = datos[2].Replace("\"", "").Trim();   
                        string descripcion = datos[3].Replace("\"", "").Trim(); 

                        
                        Libro libro = new Libro(titulo, isbn, autor, descripcion);
                        libros.Add(libro);
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo de libros no existe.");
            }

            return libros;
        }


        public static List<Copia> GenerarCopias()
        {
            List<Copia> copias = new List<Copia>();

            
            var libros = GenerarLibros();  
            if (libros.Count > 0)
            {
                var libro = libros[0];
                copias.Add(new Copia(libro));
            }

           

            return copias;
        }

        public static List<Alumno> GenerarAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();

            
            alumnos.Add(new Alumno("Manuel", "Fernandez", "43003986", "12980", false)); 
            alumnos.Add(new Alumno("Javiera", "Gonzalez", "41055391", "12981", true));  
            alumnos.Add(new Alumno("Veronica", "Zarate", "29703786", "12982", true));   
            return alumnos;
        }
        public static List<Prestamo> GenerarPrestamos()
        {
            List<Prestamo> prestamos = new List<Prestamo>();

            
            List<Alumno> alumnos = GenerarAlumnos();
            List<Libro> libros = GenerarLibros();

            if (alumnos.Count > 0 && libros.Count > 0)
            {
                foreach (var alumno in alumnos)
                {
                    if (!alumno.Deuda) 
                    {
                        
                        foreach (var libro in libros)
                        {
                            
                            var copiaDisponible = libro.Copias.FirstOrDefault(c => c.Disponible);
                            if (copiaDisponible != null)
                            {
                                
                                Prestamo nuevoPrestamo = new Prestamo(alumno, copiaDisponible, DateTime.Today);

                               
                                prestamos.Add(nuevoPrestamo);

                               
                                copiaDisponible.Disponible = false;

                                
                                alumno.Deuda = true;

                                break;  
                            }
                        }
                    }
                }
            }

            return prestamos;
        }
        public static Libro BuscarLibroPorISBN(string isbn)
        {
            
            List<Libro> libros = GenerarLibros();

           
            foreach (var libro in libros)
            {
                if (libro.ISBN.Trim() == isbn.Trim()) 
                {
                    return libro;  
                }
            }

            return null; 
        }

    }
}
