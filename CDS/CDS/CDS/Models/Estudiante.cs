using System;
using System.Collections.Generic;
using System.Text;

namespace CDS.Models
{
    public class Estudiante
    {
        public int idEstudiante { get; set; }
        public int idUsuario { get; set; }
        public string alumno { get; set; }
        public string nombreLogin { get; set; }
        public int idRol { get; set; }
        public int idGrupo { get; set; }
    }
}
