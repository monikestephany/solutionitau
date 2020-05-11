using itau.doc.api.core.Contracts.Dtos;
using itau.doc.api.core.Contracts.Repositories;
using itau.doc.api.core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.doc.api.data.Repositories
{
    public class DocRepository : IDocRepository
    {
        private readonly IMongoCollection<Doc> _object;
        public DocRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _object = database.GetCollection<Doc>(settings.DocCollectionName);
        }
        public List<Doc> Get() =>
                  _object.Find(clube => true).ToList();

        public Doc GetId(string id) =>
           _object.Find<Doc>(clube => clube.Id == id).FirstOrDefault();

        public Doc Create(Doc clube)
        {
            _object.InsertOne(clube);
            return clube;
        }
        public Doc Update(string id, Doc clubeIn)
        {
            _object.ReplaceOne(clube => clube.Id == id, clubeIn);
            return clubeIn;
        }

        public void Remove(Doc clubeIn) =>
            _object.DeleteOne(clube => clube.Id == clubeIn.Id);

    }
}
