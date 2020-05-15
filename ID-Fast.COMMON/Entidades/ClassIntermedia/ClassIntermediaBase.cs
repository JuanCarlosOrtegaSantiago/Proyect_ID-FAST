using ID_Fast.COMMON.Entidades.IDBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Entidades.ClassIntermedia
{
    public abstract class ClassIntermediaBase:BaseDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Matricula { get; set; }
        public byte[] Foto { get; set; }
        public string TipoDeSangre { get; set; }
        public string Alergias { get; set; }
        public string Num_Seguro { get; set; }
        //public List<string> Enermedades { get; set; }
    }
}
