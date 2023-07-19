using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase02.Entidades
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private string numeroDocumento;

        public Persona(string nombre, string apellido, string numeroDocumento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.numeroDocumento = numeroDocumento;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string getApellido()
        {
            return this.apellido;
        }
        public void setApellido(string apellido)
        {
            this.apellido = apellido;
        }
        public string getNumeroDocumento()
        {
            return this.numeroDocumento;
        }
        public void setNumeroDocumento(string numeroDocumento)
        {
            this.numeroDocumento = numeroDocumento;
        }

    }
}
