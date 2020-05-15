using ID_Fast.COMMON.Entidades.EntidadesUsuarios;
using ID_Fast.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ID_Fast.BIZ
{
    public class ManejadorDeAdministrativos : IManejadorAdministrativos
    {
        IRepositorioGenerico<Administrativos> repositorio;
        public ManejadorDeAdministrativos(IRepositorioGenerico<Administrativos> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Administrativos> Read => repositorio.Read;

        public bool BuscarAdmin(string Correo, string contarsenia)
        {
            return Read.Where(e => e.Correo == Correo && e.Contrasenia == contarsenia).Count() == 1 ? true : false;
        }

        public bool Create(Administrativos Entidad)
        {
            return repositorio.Create(Entidad);
        }

        public bool Delete(ObjectId Id)
        {
            return repositorio.Delete(Id);
        }

        public bool Update(Administrativos EntidadModificada)
        {
            return repositorio.Update(EntidadModificada);
        }
    }
}
