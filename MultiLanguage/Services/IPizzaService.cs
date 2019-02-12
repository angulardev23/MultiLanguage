using System;
using System.Collections.Generic;
using MultiLanguage.Models;

namespace MultiLanguage.Services
{
    public interface IPizzaService
    {
        List<PizzaContent> GetPizzasList(string code);
    }
}
