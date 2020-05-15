using ID_Fast.COMMON.Entidades.ClasssIntermediaTrabajadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Entidades.EntidadesUsuarios
{
    public class Administrativos:ClassIntermediaTrabajadores
    {
        public string Cargo { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
    }
}
