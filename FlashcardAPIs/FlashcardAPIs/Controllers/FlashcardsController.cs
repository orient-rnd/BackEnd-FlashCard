using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;
using Flashcard.Infrastructure.MongoDb;
using FlashCard.Models.Domains;
using Flashcard.AppServices.APIs.Models;
using MongoDB.Driver;
using FlashCard.Domains.RequestResponseMessages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flashcard.AppServices.APIs.Controllers
{
    [Route("[controller]")]
    public class FlashcardsController : Controller
    {
        private readonly IFlashcardBusinessLogic _flashcardBusinessLogic;

        public FlashcardsController(IFlashcardBusinessLogic flashcardBusinessLogic)
        {
            _flashcardBusinessLogic = flashcardBusinessLogic;
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


        [HttpPost]
        public IActionResult Post([FromBody]CreateFlashCardRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            _flashcardBusinessLogic.CreateFlashCard(request);

            return Ok();
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _flashcardBusinessLogic.Delete<FlashCards>(id);
            return Ok();
        }
    }
}
