using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashCard.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;

using Flashcard.Infrastructure.MongoDb;
using Flashcard.AppServices.APIs.Models;
using MongoDB.Driver;
using FlashCard.Domains.RequestResponseMessages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flashcard.AppServices.APIs.Controllers
{
    [Route("[controller]")]
    public class FlashCardCategoriesController : Controller
    {
        private readonly IFlashcardBusinessLogic _flashcardBusinessLogic;

        public FlashCardCategoriesController(IFlashcardBusinessLogic flashcardBusinessLogic)
        {
            _flashcardBusinessLogic = flashcardBusinessLogic;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var request = new GetFlashCardCategoryRequest();
            var reponse = _flashcardBusinessLogic.GetFlashCardCategory(request);
            return Ok(reponse);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var request = new GetFlashCardCategoryRequest() { Id = id };
            var reponse = _flashcardBusinessLogic.GetFlashCardCategory(request);
            return Ok(reponse.FirstOrDefault());
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CreateFlashCardCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            _flashcardBusinessLogic.CreateFlashCardCategory(request);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]UpdateFlashCardCategoryRequest request)
        {
            request.Id = id;
            _flashcardBusinessLogic.UpdateFlashCardCategory(request);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
