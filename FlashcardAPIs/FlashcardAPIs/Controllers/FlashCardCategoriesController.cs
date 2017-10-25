using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;
using Flashcard.Infrastructure.MongoDb;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flashcard.AppServices.APIs.Controllers
{
    [Route("api/[controller]")]
    public class FlashCardCategoriesController : Controller
    {
        private readonly IFlashcardBusinessLogic _flashcardBusinessLogic;
        private readonly IMongoDbWriteRepository _mongoDbWriteRepository;

        public FlashCardCategoriesController(IFlashcardBusinessLogic flashcardBusinessLogic, IMongoDbWriteRepository mongoDbWriteRepository)
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
