
namespace BibliotecaUTN.Dominio.Dominio
{
    public class Copia
    {
        private bool _disponible;
        private Libro _libro;

        public Copia(Libro libro)
        {
            _libro = libro;
            _disponible = true; // Por defecto, la copia está disponible
        }

        // Propiedad pública para acceder y modificar el estado de disponibilidad
        public bool Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }

        // Propiedad para obtener el libro asociado a la copia
        public Libro Libro
        {
            get { return _libro; }
        }
    }

}
