using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCard.Domains.RequestResponseMessages
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
