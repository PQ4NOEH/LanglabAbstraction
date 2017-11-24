using Langlab.Core.CORS;

namespace Langlab.Dictionary.Contracts
{
    public interface IDictionaryService:
        IQueryHandler<SearchWord>
    {

    }
   
    public  class SearchWord:Query
    {
        public string Word { get; }
        public string Language { get; }
        public string TranslationLanguage { get; }
    }
}
