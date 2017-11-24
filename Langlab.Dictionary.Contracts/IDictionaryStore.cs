using Langlab.Core.Business;
using System.Threading.Tasks;

namespace Langlab.Dictionary.Contracts
{
    public interface IDictionaryStore
    {
        Task<Word> FetchWord(string word, string language, string translateTo);
    }

    
    
    public interface IExternalDictionary : IDictionaryStore { }
    public interface ILanglabDictionaryStore : IDictionaryStore
    {
        Task PushWord(Word word);
    }
}
