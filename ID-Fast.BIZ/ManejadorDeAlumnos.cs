using ID_Fast.COMMON.Entidades;
using ID_Fast.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ID_Fast.BIZ
{
    public class ManejadorDeAlumnos : IManejadorAlumnos
    {
        IRepositorioGenerico<Alumno> repositorio;
        public ManejadorDeAlumnos(IRepositorioGenerico<Alumno> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Alumno> Read => repositorio.Read.ToList().OrderBy(e=>e.EstaDeAlta == false).OrderBy(e=> e.Carrera).ToList();

        public bool Create(Alumno entidad)
        {
            return repositorio.Create(entidad);
        }

        public bool Delete(ObjectId Id)
        {
            return repositorio.Delete(Id);
        }

        public bool Update(Alumno entidadModificada)
        {
            return repositorio.Update(entidadModificada);
        }
    }
}
