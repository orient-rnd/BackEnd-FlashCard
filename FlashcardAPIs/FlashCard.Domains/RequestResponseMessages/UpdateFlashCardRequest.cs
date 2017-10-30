using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCard.Domains.RequestResponseMessages
{
    public class UpdateFlashCardRequest : CreateFlashCardRequest
    {
        public string Id { get; set; }
    }
}
