using System;
using System.Collections.Generic;
using System.Text;

namespace CDS.Models
{
    public class Clase
    {
        public int idClase { get; set; }
        public int idMateria { get; set; }
        public int idDocente { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public string dia { get; set; }
    }
}
