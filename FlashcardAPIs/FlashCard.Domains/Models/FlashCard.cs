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
    public class FlashCards : AuditableEntityBase, IAggregateRoot
    {
        [Required(ErrorMessage = "Fill the blank, Please!!")]
        [StringLength(100, MinimumLength = 5)]
        public string FaceA { get; set; }

        [Required(ErrorMessage = "Fill the blank, Please!!")]
        [StringLength(300, MinimumLength = 5)]
        public string FaceB { get; set; }

        [Required]
        public string FlashCardCategoryId { get; set; }

        [Required]
        public string FlashCardCategoryName { get; set; }

        public string UserEmail { get; set; }

        public int DisplayOrder { get; set; }

        public int ViewNumber { get; set; }
    }
}