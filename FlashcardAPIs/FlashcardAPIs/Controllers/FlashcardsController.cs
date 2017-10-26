using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;
using Flashcard.Infrastructure.MongoDb;
using FlashCard.Models.Domains;

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
            //throw new InvalidOperationException("Invalid operation.");
            //var cate = new FlashCardCategory();
            //cate.Name = "abc";

            //_mongoDbWriteRepository.Create(cate);
            return new string[] { "value1", "value2" };
        }

    }
}
