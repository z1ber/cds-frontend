using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace CDS.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreLogin { get; set; }
        public string password { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string dui { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int idRol { get; set; }

    }

    public class UsuarioList
    {
        public List<Usuario> userlist { get; set; }
    }
}
