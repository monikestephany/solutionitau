using itau.conta.api.core.Contracts.Dtos;
using itau.conta.api.core.Contracts.Repositories;
using itau.conta.api.core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.conta.api.data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly IMongoCollection<Conta> _object;
        public ContaRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _object = database.GetCollection<Conta>(settings.ContaCollectionName);
        }
        public List<Conta> Get() =>
                  _object.Find(clube => true).ToList();

        public Conta GetId(string id) =>
           _object.Find<Conta>(clube => clube.Id == id).FirstOrDefault();
        public Conta GetLastAgencia() =>
           _object.Find<Conta>(clube => true).SortByDescending(c => c.NumeroAgencia).FirstOrDefault();

        public Conta GetLastConta() =>
         _object.Find<Conta>(clube => true).SortByDescending(c => c.NumeroConta).FirstOrDefault();

        public Conta Create(Conta clube)
        {
            _object.InsertOne(clube);
            return clube;
        }
        public Conta Update(string id, Conta clubeIn)
        {
            _object.ReplaceOne(clube => clube.Id == id, clubeIn);
            return clubeIn;
        }

        public void Remove(Conta clubeIn) =>
            _object.DeleteOne(clube => clube.Id == clubeIn.Id);

    }
}
