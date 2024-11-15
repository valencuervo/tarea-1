using BibliotecaUTN.Dominio.Dominio;

namespace BibliotecaUTN.Servicios
{
    internal class LibroServicio
    {
        internal static void Crear()
        {
            Console.WriteLine("Añadir un nuevo libro");

            
            Console.Write("Ingrese el ISBN del libro al que desea agregar una copia: ");
            string isbn = Console.ReadLine();

            
            Libro libro = BuscarLibroPorISBN(isbn);
            if (libro == null)
            {
                Console.WriteLine("No se encontró el libro con ese ISBN.");
                return;
            }

            
            Copia nuevaCopia = new Copia(libro);

            
            libro.Copias.Add(nuevaCopia);

            
            GuardarCopiaEnArchivo(nuevaCopia);

            Console.WriteLine("Copia agregada exitosamente.");
        }

        
        private static Libro BuscarLibroPorISBN(string isbn)
        {
            
            foreach (var libro in FactoryObjects.GenerarLibros())
            {
                if (libro.ISBN == isbn)
                {
                    return libro; 
                }
            }
            return null; 
        }

       
        private static void GuardarCopiaEnArchivo(Copia copia)
        {
            
            string rutacopia = "copias.txt";

            
            using (StreamWriter grabar = new StreamWriter(rutacopia, true))
            {
                
                grabar.WriteLine($"{copia.Libro.ISBN},{copia.Libro.Titulo},{copia.Disponible}");
            }
        }
    }


}
