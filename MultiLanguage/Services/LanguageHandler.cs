using MultiLanguage.Models;
using System.Linq;

namespace MultiLanguage.Services
{
    public class LanguageHandler : ILanguageHandler
    {
        public ILanguageHandler Successor;
        private readonly string _languageCode;

        public LanguageHandler(string languageCode)
        {
            _languageCode = languageCode;
        }

        public PizzaContent GetLanguageTranslation(Pizza pizza)
        {
            if(pizza.Contents == null)
            {
                return null;
            }

            var contentsList = pizza.Contents;

            var translation = contentsList.Where(
                x => x.LanguageCode == _languageCode)
                .FirstOrDefault();

            if (translation != null)
            {
                return translation;
            }
            else if (Successor != null)
            {   //provide responsibility to the next handler
                return Successor.GetLanguageTranslation(pizza);
            }
            else
            {
                return contentsList.FirstOrDefault();
            }
        }

    }
}
