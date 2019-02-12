using System;
namespace MultiLanguage.Services
{
    public interface ILanguageHandlerService
    {
        LanguageHandler GetLanguageHandler(string code);
    }
}
