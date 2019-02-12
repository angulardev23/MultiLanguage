using System;
using System.Collections;
using System.Collections.Generic;
using MultiLanguage.Models;
using MultiLanguage.Data;
using System.Linq;

namespace MultiLanguage.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaDbContext _pizzaDbContext;
        private readonly ILanguageHandlerService _languageHandlerService;

        public PizzaService(IPizzaDbContext pizzaDbContext, ILanguageHandlerService languageHandlerService)
        {
            _pizzaDbContext = pizzaDbContext;
            _languageHandlerService = languageHandlerService;
        }

        public List<PizzaContent> GetPizzasList(string languageCode)
        {
            //set responsible handler
            var languageHandler = _languageHandlerService.GetLanguageHandler(languageCode);
            var pizzas = _pizzaDbContext.GetPizzasCollection();

            var pizzaContentsList = new List<PizzaContent>();
            pizzas.ToList().ForEach(
                x => pizzaContentsList.Add(languageHandler.GetLanguageTranslation(x)));

            return pizzaContentsList;
        }
    }
}
