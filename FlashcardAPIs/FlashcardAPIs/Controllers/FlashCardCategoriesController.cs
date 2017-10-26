using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashCard.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;

using Flashcard.Infrastructure.MongoDb;
using Flashcard.AppServices.APIs.Models;

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
        public IActionResult Post([FromBody]FlashCardCategory category)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            category.Id = Guid.NewGuid().ToString();
            _mongoDbWriteRepository.Create(category);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]FlashCardCategory category)
        {
            var tempCategory = _mongoDbWriteRepository.Get<FlashCardCategory>(category.Id);
            _mongoDbWriteRepository.Replace(category);
            return Ok(tempCategory);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
