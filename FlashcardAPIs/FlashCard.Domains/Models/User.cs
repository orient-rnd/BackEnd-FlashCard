using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Flashcard.Infrastructure.MongoDb.Models;
using Flashcard.Infrastructure.Identity.MongoDb;

namespace FlashCard.Models.Domains
{
    [BsonIgnoreExtraElements]
    public class User : AuditableEntityBase, IAggregateRoot
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}