using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restTC.Models
{
    public class TipoCambio
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string fecha { get; set; }
        public string serie { get; set; }
        public string descripcion { get; set; }
        public string codigo { get; set; }
        public Double valor { get; set; }
    }
}
