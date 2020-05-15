using ID_Fast.COMMON.Entidades.IDBase;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Interfaces
{
    public interface IManejadorGenerico<T> where T : BaseDto
    {
        bool Create(T entidad);
        List<T> Read { get; }
        bool Update(T entidadModificada);
        bool Delete(ObjectId Id);
    }
}
