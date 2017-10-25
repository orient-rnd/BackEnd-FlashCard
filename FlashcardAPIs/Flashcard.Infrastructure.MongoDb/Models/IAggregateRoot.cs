using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcard.Infrastructure.MongoDb.Models
{
    public interface IAggregateRoot
    {
        string Id { get; set; }
    }
}
