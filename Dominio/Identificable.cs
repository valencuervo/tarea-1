using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUTN.Dominio
{
    public abstract class Identificable
    {

        public string _id;

        public Identificable()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get { return _id; } set { _id = value; } }

    }
}
