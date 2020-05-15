using ID_Fast.COMMON.Entidades.IDBase;
using ID_Fast.COMMON.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ID_Fast.DAL
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : BaseDto
    {
        private MongoClient client;
        private IMongoDatabase db;
        string _error;

        public RepositorioGenerico()
        {
            //mongodb://Admin:Admin1234@ds263638.mlab.com:63638/huichbd
            client = new MongoClient(new MongoUrl(@"mongodb://Admin:Admin1234@ds263638.mlab.com:63638/huichbd?retryWrites=false"));
            //client = new MongoClient(new MongoUrl(@"mongodb://Admin:Admin1234@ds263638.mlab.com:63638/huichbd?retryWrites=false&AuthMechanism=SCRAM-SHA-1"));
            db = client.GetDatabase("huichbd");
        }
        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }
        public List<T> Read => Collection().AsQueryable().ToList();

        //public string Error => _error;

        public bool Create(T entidad)
        {
            string resul = "";

            entidad.id = new ObjectId();
            try
            {
                Collection().InsertOne(entidad);
                resul = "";
                return true;
            }
            catch (Exception ex)
            {
                resul = ex.Message;
                return false;
            }
        }

        public bool Delete(ObjectId Id)
        {
            try
            {
                return Collection().DeleteOne(e => e.id == Id).DeletedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entidadModificada)
        {
            try
            {
                return Collection().ReplaceOne(e => e.id == entidadModificada.id, entidadModificada).ModifiedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
