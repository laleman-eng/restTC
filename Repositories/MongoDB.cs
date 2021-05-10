using MongoDB.Driver;
using restTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restTC.Repositories
{
    public class MongoDB
    {
        public MongoClient client;
        public IMongoDatabase db;
        
        public MongoDB()
        {
            
            client = new MongoClient(Param.stringConection);
            db = client.GetDatabase(Param.database);

        }

    }
}
