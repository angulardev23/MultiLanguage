using System;
using System.Collections.Generic;
using MultiLanguage.Models;

namespace MultiLanguage.Data
{
    public interface IPizzaDbContext
    {
        IEnumerable<Pizza> GetPizzasCollection();
    }
}
