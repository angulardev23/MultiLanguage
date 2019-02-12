using System;
namespace MultiLanguage.Services
{
    public class LanguageHandlerService : ILanguageHandlerService
    {
        private readonly ILanguageHandler _initLanguageHandler;

        public LanguageHandlerService()
        {   //define the chain of responsibilities
            var firstOrDefaultLanguageHandler = new LanguageHandler(null);
            var polishLanguageHandler = new LanguageHandler("pl");
            var englishLanguageHandler = new LanguageHandler("en");

            englishLanguageHandler.Successor = polishLanguageHandler;
            polishLanguageHandler.Successor = firstOrDefaultLanguageHandler;

            _initLanguageHandler = englishLanguageHandler;
        }

        public LanguageHandler GetLanguageHandler(string languageCode)
        {
            var languageHandler = new LanguageHandler(languageCode)
            {
                Successor = _initLanguageHandler
            };

            return languageHandler;
        }
    }
}
