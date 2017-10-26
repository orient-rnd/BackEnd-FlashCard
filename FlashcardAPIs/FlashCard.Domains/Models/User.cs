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
    public class User : IdentityUser<string>, IAggregateRoot
    {
        public User()
        {
            Id = Guid.NewGuid().ToString("N");
        }

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
        /// Full name
        /// </summary>
        public string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(MiddleName))
                {
                    return String.Format("{0} {1}", FirstName, LastName);
                }

                return String.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Preferred language
        /// </summary>
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Photo
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Agency id
        /// </summary>
        public string AgencyId { get; set; }


        /// <summary>
        /// Id from ExactOnline
        /// </summary>
        public string IdExactOnline { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}