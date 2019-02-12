using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiLanguage.Models;
using MultiLanguage.Services;
using MultiLanguage.Data;

namespace MultiLanguage.Controllers
{
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET
        [HttpGet("{languageCode}")]
        public IActionResult Get(string languageCode)
        {
            var pizzaContentsList = _pizzaService.GetPizzasList(languageCode);
            return Ok(pizzaContentsList);
        }

    }
}
