using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Flashcard.Infrastructure.Identity.MongoDb;
using Flashcard.Infrastructure.MongoDb.Models;

namespace FlashCard.Models.Domains
{
    [BsonIgnoreExtraElements]
    public class Role : IdentityRole<string>, IAggregateRoot
    {
        /// <summary>
        /// Permissions
        /// </summary>
        public IEnumerable<string> Permissions { get; set; }
    }
}