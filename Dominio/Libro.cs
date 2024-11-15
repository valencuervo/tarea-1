using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BibliotecaUTN.Dominio.Dominio
{
    public class Libro : Identificable
    {
        private string _titulo;
        private string _ISBN;
        private string _autor;
        private string _descripcion;
        private List<Copia> _copias;

        public Libro() : base()
        {
            _copias = new List<Copia>();
        }

        public Libro(String titulo, String isbn, String autor, String descripcion) : this()
        {
            _titulo = titulo;
            _ISBN = isbn;
            _autor = autor;
            _descripcion = descripcion;
        }

       
        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        
        public List<Copia> Copias
        {
            get { return _copias; }
            set { _copias = value; }
        }
    }


}
