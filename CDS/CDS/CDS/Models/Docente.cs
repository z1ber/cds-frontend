using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Models
{
    public class Docente
    {
        public int idDocente { get; set; }
        public string idUsuario { get; set; }
        public int idMateria { get; set; }
        public string docente { get; set; }
        public string nombreMateria { get; set; }
        public string nombreLogin { get; set; }
        public int idRol { get; set; }
    }
}
