using MongoDB.Bson;
using MongoDB.Driver;
using restTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restTC.Repositories
{
    public class TipoCambioCollection : ITipoCambioColletion
    {
        internal MongoDB mongodb = new MongoDB();
        private IMongoCollection<TipoCambio> collection;

        public TipoCambioCollection ()
        {
            collection = mongodb.db.GetCollection<TipoCambio>(Param.collection);
        }

        public async Task DeleteTipoCambio(string id)
        {
            var filter = Builders<TipoCambio>.Filter.Eq(s => s.Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<TipoCambio>> GetAllTipoCambio()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<List<TipoCambio>> GetTipoCambioByDate(string date)
        {
            var filter = Builders<TipoCambio>.Filter.Eq(s => s.fecha,date);
            return await collection.FindAsync(filter).Result.ToListAsync();   
        }

        public async Task<TipoCambio> GetProductById(string id)
        {
            return await collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task<TipoCambio> GetTipoCambio(TipoCambio tipoCambio)
        {
            
            var filter = Builders<TipoCambio>
                .Filter
                .Eq(s =>  s.fecha, tipoCambio.fecha);
            filter = filter & (Builders<TipoCambio>.Filter.Eq(s => s.codigo, tipoCambio.codigo));

            return await collection.FindAsync(filter).Result.FirstAsync();
            
        }

        public async Task<TipoCambio> GetTipoCambioById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertarTipoCambio(TipoCambio tipoCambio)
        {
            await collection.InsertOneAsync(tipoCambio);
        }

        public async Task UpdateTipoCambio(TipoCambio tipoCambio)
        {
            var filter = Builders<TipoCambio>
                .Filter
                .Eq(s => s.Id, tipoCambio.Id);
            await collection.ReplaceOneAsync(filter, tipoCambio);
        }
    }
}
