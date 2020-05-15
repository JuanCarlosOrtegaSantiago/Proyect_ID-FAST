using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.COMMON.Entidades.IDBase
{
    public abstract class BaseDto
    {
        public ObjectId id { get; set; }   
    }
}
