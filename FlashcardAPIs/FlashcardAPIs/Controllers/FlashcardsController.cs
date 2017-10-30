using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashCard.BusinessLogic;
using Flashcard.Infrastructure.MongoDb;
using FlashCard.Models.Domains;
using Flashcard.AppServices.APIs.Models;
using FlashCard.Domains.RequestResponseMessages;
using MongoDB.Driver;

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
        public IActionResult Get()
        {
            //throw new InvalidOperationException("Invalid operation.");

            var req = new GetFlashCardRequest();
            var res = _flashcardBusinessLogic.GetFlashCard(req);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var req = new GetFlashCardRequest() { Id = id };
            var res = _flashcardBusinessLogic.GetFlashCard(req);

            return Ok(res.FirstOrDefault());
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

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]UpdateFlashCardRequest request)
        {
            request.Id = id;
            _flashcardBusinessLogic.UpdateFlashCard(request);
            return Ok();
        }
    }
}
