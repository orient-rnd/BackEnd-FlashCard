using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using Flashcard.Infrastructure.MongoDb.Models;
using System.ComponentModel.DataAnnotations;

namespace FlashCard.Models.Domains
{
    [BsonIgnoreExtraElements]
    public class FlashCardCategory : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage ="Fill the blank, Please!!")]
        [StringLength(100,MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}