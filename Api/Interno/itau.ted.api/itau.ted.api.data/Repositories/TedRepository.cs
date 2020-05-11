using itau.ted.api.core.Contracts.Dtos;
using itau.ted.api.core.Contracts.Repositories;
using itau.ted.api.core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.ted.api.data.Repositories
{
    public class TedRepository : ITedRepository
    {
        private readonly IMongoCollection<Ted> _object;
        public TedRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _object = database.GetCollection<Ted>(settings.TedCollectionName);
        }
        public List<Ted> Get() =>
                  _object.Find(clube => true).ToList();

        public Ted GetId(string id) =>
           _object.Find<Ted>(clube => clube.Id == id).FirstOrDefault();

        public Ted Create(Ted clube)
        {
            _object.InsertOne(clube);
            return clube;
        }
        public Ted Update(string id, Ted clubeIn)
        {
            _object.ReplaceOne(clube => clube.Id == id, clubeIn);
            return clubeIn;
        }

        public void Remove(Ted clubeIn) =>
            _object.DeleteOne(clube => clube.Id == clubeIn.Id);

    }
}
