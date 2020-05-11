using itau.cliente.api.core.Contracts.Dtos;
using itau.cliente.api.core.Contracts.Repositories;
using itau.cliente.api.core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace itau.cliente.api.data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clube;
        public ClienteRepository(IDBClubeSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clube = database.GetCollection<Cliente>(settings.ClienteCollectionName);
        }
        public List<Cliente> Get() =>
                  _clube.Find(clube => true).ToList();

        public Cliente GetCPF(string cpf) =>
            _clube.Find<Cliente>(clube => clube.CPF == cpf).FirstOrDefault();

        public Cliente GetId(string id) =>
           _clube.Find<Cliente>(clube => clube.Id == id).FirstOrDefault();

        public bool CPFExists(string cpf) =>
          _clube.Find<Cliente>(clube => clube.CPF == cpf).Any();

        public Cliente Create(Cliente clube)
        {
            _clube.InsertOne(clube);
            return clube;
        }
        public Cliente Update(string id, Cliente clubeIn)
        {
            _clube.ReplaceOne(clube => clube.Id == id, clubeIn);
            return clubeIn;
        }

        public void Remove(Cliente clubeIn) =>
            _clube.DeleteOne(clube => clube.Id == clubeIn.Id);

    }
}
