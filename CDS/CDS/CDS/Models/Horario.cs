using System;
using System.Collections.Generic;
using System.Text;

namespace CDS.Models
{
    public class Horario
    {
        public int idHorario { get; set; }
        public int idEstudiante { get; set; }
        public int idClase { get; set; }
        public int fechaInicio { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public string nombreMateria { get; set; }
        public string docente { get; set; }
    }
}
