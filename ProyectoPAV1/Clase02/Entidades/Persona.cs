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
        private DateTime fechaNacimiento;
        private int idSexo;
        private int idTipoDocumento;
        private string calle;
        private string nroCasa;
        private bool soltero;
        private bool casado;
        private bool otro;
        private int cantidadHijos;
        private int idCarrera;

        public Persona(string nombre, string apellido, string numeroDocumento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.numeroDocumento = numeroDocumento;
        }
        public Persona()
        {

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
        public DateTime getFechaNacimiento()
        {
            return this.fechaNacimiento;
        }
        public void setFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }
        public int getIdSexo()
        {
            return this.idSexo;
        }
        public void setIdSexo(int idSexo)
        {
            this.idSexo = idSexo;
        }
        public int getIdTipoDocumento()
        {
            return this.idTipoDocumento;
        }
        public void setIdTipoDocumento(int idTipoDocumento)
        {
            this.idTipoDocumento = idTipoDocumento;
        }
        public string getCalle()
        {
            return this.calle;
        }
        public void setCalle(string calle)
        {
            this.calle = calle;
        }
        public string getNroCasa()
        {
            return this.nroCasa;
        }
        public void setNroCasa(string nroCasa)
        {
            this.nroCasa = nroCasa;
        }
        public bool getSoltero()
        {
            return this.soltero;
        }
        public void setSoltero(bool soltero)
        {
            this.soltero = soltero;
        }
        public bool getCasado()
        {
            return this.casado;
        }
        public void setCasado(bool casado)
        {
            this.casado = casado;
        }
        public bool getOtro()
        {
            return this.otro;
        }
        public void setOtro(bool otro)
        {
            this.otro = otro;
        }
        public int getCantidadHijos()
        {
            return this.cantidadHijos;
        }
        public void setCantidadHijos(int cantidadHijos)
        {
            this.cantidadHijos = cantidadHijos;
        }
        public int getIdCarrera()
        {
            return this.idCarrera;
        }
        public void setIdCarrera(int idCarrera)
        {
            this.idCarrera = idCarrera;
        }

    }
}
