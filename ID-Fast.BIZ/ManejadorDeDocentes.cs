using ID_Fast.COMMON.Entidades.EntidadesUsuarios;
using ID_Fast.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ID_Fast.BIZ
{
    public class ManejadorDeDocentes : IManejadorDocentes
    {
        IRepositorioGenerico<Docentes> repositorio;
        public ManejadorDeDocentes(IRepositorioGenerico<Docentes> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Docentes> Read => repositorio.Read.ToList().OrderBy(e => e.EstaActivo == false).OrderBy(e => e.Area).ToList();

        public bool Create(Docentes entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(ObjectId Id)
        {
            return repositorio.Delete(Id);
        }

        public bool Update(Docentes entidadModificada)
        {
            return repositorio.Update(entidadModificada);
        }
    }
}
