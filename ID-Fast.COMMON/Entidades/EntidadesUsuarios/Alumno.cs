using ID_Fast.COMMON.Entidades.ClassIntermedia;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Entidades
{
    public class Alumno:ClassIntermediaBase
    {
        public int Semestre { get; set; }
        public string Carrera { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EstaDeAlta { get; set; }
        public DateTime CicloEscolarInicio { get; set; }
        public DateTime CicloEscolarFin { get; set; }
    }
}
