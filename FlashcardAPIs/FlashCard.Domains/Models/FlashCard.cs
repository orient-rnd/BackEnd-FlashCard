using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Flashcard.Infrastructure.MongoDb.Models;

namespace FlashCard.Models.Domains
{
    [BsonIgnoreExtraElements]
    public class FlashCard : AuditableEntityBase, IAggregateRoot
    {
        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public string UserEmail { get; set; }

        public int DisplayOrder { get; set; }

        public int ViewNumber { get; set; }
    }
}