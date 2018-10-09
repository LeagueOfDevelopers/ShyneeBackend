using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ShyneeBackend.Infrastructure.Models
{
    class Shynee
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
