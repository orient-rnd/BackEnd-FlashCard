using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;
using Flashcard.Infrastructure.MongoDb;
using FlashCard.Models.Domains;
using Flashcard.AppServices.APIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flashcard.AppServices.APIs.Controllers
{
    [Route("api/[controller]")]
    public class FlashcardsController : Controller
    {
        private readonly IFlashcardBusinessLogic _flashcardBusinessLogic;
        private readonly IMongoDbWriteRepository _mongoDbWriteRepository;

        public FlashcardsController(IFlashcardBusinessLogic flashcardBusinessLogic, IMongoDbWriteRepository mongoDbWriteRepository)
        {
            _flashcardBusinessLogic = flashcardBusinessLogic;
            _mongoDbWriteRepository = mongoDbWriteRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {   
            
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Post([FromBody]FlashCards flashCard)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            flashCard.Id = Guid.NewGuid().ToString();
            _mongoDbWriteRepository.Create(flashCard);
            return Ok();
        }

    }
}
