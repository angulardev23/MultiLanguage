using System;
using MultiLanguage.Models;

namespace MultiLanguage.Services
{
    public interface ILanguageHandler
    {
        PizzaContent GetLanguageTranslation(Pizza pizza);
    }
}
