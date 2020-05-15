using ID_Fast.COMMON.Entidades.IDBase;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Interfaces
{
    public interface IRepositorioGenerico<T> where T : BaseDto
    {
        bool Create(T Entidad);
        List<T> Read { get; }
        bool Update(T EntidadModificada);
        bool Delete(ObjectId Id);
    }
}
