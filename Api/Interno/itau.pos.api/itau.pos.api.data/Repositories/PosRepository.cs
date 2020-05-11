using itau.pos.api.core.Contracts.Dtos;
using itau.pos.api.core.Contracts.Repositories;
using itau.pos.api.core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.pos.api.data.Repositories
{
    public class PosRepository : IPosRepository
    {
        private readonly IMongoCollection<Pos> _object;
        public PosRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _object = database.GetCollection<Pos>(settings.PosCollectionName);
        }
        public List<Pos> Get() =>
                  _object.Find(clube => true).ToList();

        public Pos GetId(string id) =>
           _object.Find<Pos>(clube => clube.Id == id).FirstOrDefault();

        public Pos Create(Pos clube)
        {
            _object.InsertOne(clube);
            return clube;
        }
        public Pos Update(string id, Pos clubeIn)
        {
            _object.ReplaceOne(clube => clube.Id == id, clubeIn);
            return clubeIn;
        }

        public void Remove(Pos clubeIn) =>
            _object.DeleteOne(clube => clube.Id == clubeIn.Id);

    }
}
