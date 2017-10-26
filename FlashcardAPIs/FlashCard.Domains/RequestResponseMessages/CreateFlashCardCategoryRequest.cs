using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlashCard.Domains.RequestResponseMessages
{
    public class CreateFlashCardCategoryRequest
    {
        [Required(ErrorMessage = "Fill the blank, Please!!")]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public bool IsFaceAShowFirst { get; set; }

        public bool IsRandom { get; set; }
    }
}
