using ID_Fast.COMMON.Entidades.EntidadesUsuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Interfaces
{
    public interface IManejadorAdministrativos:IRepositorioGenerico<Administrativos>
    {

        bool BuscarAdmin(string Correo, string contarsenia);

    }
}
