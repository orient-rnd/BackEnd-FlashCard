using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlashCard.Domains.Services;

namespace Flashcard.AppServices.APIs.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        //private readonly IUserService _userService;

        //public HomeController(IUserService userService)
        //{
        //    _userService = userService;
        //}
        [HttpGet]
        public IActionResult Get()
        {
            return Redirect("/swagger/");
        }
    }
}