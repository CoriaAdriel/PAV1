using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase02.Entidades
{
    public class Usuario
    {
        private string usuario;
        private string contraseña;

        public Usuario(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }
        public string getUsuario()
        {
            return usuario;
        }
        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
        }
        public string getContraseña()
        {
            return contraseña;
        }
        public void setContraseña(string contraseña)
        {
            this.contraseña = contraseña;
        }
    }
}
