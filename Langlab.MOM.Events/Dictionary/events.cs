using Langlab.Core.Business;
using Langlab.Core.CORS;
using System;

namespace Langlab.MOM.Events.Dictionary
{
    public class WordSearched : Event<Word>
    {
        public WordSearched(
            string triggeredByCommandId,
            string userId,
            DateTime createdDate,
            Word payload
            ) :
            base(triggeredByCommandId, userId, createdDate, payload)
        { }
    }

    public class NonExistentWordSearched : Event<NonExistentWordSearchedPayLoad>
    {
        public NonExistentWordSearched(
            string triggeredByCommandId,
            string userId,
            DateTime createdDate,
            NonExistentWordSearchedPayLoad payload
            ) :
            base(triggeredByCommandId, userId, createdDate, payload)
        { }
    }

    public class NonExistentWordSearchedPayLoad
    {
        public string Word { get; private set; }
        public string Language { get; private set; }
        public string TranslateTo { get; private set; }
        public NonExistentWordSearchedPayLoad(string word, string language, string translateTo)
        {
            Word = word;
            Language = language;
            TranslateTo = translateTo;
        }
    }
}
