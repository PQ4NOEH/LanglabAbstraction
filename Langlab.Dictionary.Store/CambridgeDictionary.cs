using AngleSharp;
using Langlab.Core.Business;
using Langlab.Core.Tools;
using Langlab.Dictionary.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Langlab.Dictionary.Store
{
    public class CambridgeDictionaryStore : IExternalDictionary
    {
        readonly string _wordAddressTemplate = "https://dictionary.cambridge.org/es/diccionario/ingles-espanol/{0}";
        readonly Dictionary<string, PartOfSpeech> _posMapping = new Dictionary<string, PartOfSpeech>
        {
            { "adjective",PartOfSpeech.Adjetive },
            { "adverb",PartOfSpeech.Adverb },
            { "conjunction",PartOfSpeech.Conjunction },
            { "exclamation",PartOfSpeech.Interjection },
            { "noun",PartOfSpeech.Noun },
            { "prefix",PartOfSpeech.Noun },
            { "preposition",PartOfSpeech.Preposition },
            { "pronoun",PartOfSpeech.Pronoun },
            { "verb",PartOfSpeech.Verb }
        };
        PartOfSpeech MapPOS(string pos) => _posMapping[pos.ToLower()];
        public async Task<Word> FetchWord(string word, string language, string translateTo)
        {
            var requestedAddres = string.Format(_wordAddressTemplate, word);
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(requestedAddres);
            if (document.QuerySelector(".di-title") == null) return null;
            var acceptions = new List<WordFacet>();
            foreach (var bl in document.QuerySelectorAll(".pos-block"))
            {
                var ukPronunciationUrl = bl.QuerySelectorAll(".uk span:last-of-type").Any() ?
                    bl.QuerySelector(".uk span:last-of-type").Attributes["data-src-mp3"].Value :
                    string.Empty;
                var usPronunciationUrl = bl.QuerySelectorAll(".us span:last-of-type").Any() ?
                    bl.QuerySelector(".us span:last-of-type").Attributes["data-src-mp3"].Value :
                    string.Empty;
                var pos = MapPOS(bl.QuerySelector(".pos").TextContent);

                acceptions.AddRange(bl.QuerySelectorAll(".sense-block").Select(element => new WordFacet
                {
                    Id = (word + language + translateTo + element.QuerySelector(".def").TextContent).Md5(),
                    Pronunciation = ukPronunciationUrl,
                    POS = pos,
                    Language = language,
                    Translation = element.QuerySelector(".def-body .trans").TextContent,
                    Meaning = element.QuerySelector(".def").TextContent,
                    Examples = element.QuerySelectorAll(".eg")
                                        .Select(sentence => new WordFacetExample
                                        {
                                            Sentence = sentence.TextContent,
                                            Language = language,
                                            Translation = string.Empty
                                        }).ToList()

                }));
            }
            return new Word
            {
                Text = word,
                Language = language,
                Facets = acceptions
            };

        }
    }
}
