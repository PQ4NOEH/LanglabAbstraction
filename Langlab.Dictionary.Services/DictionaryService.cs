using Langlab.Core.CORS;
using Langlab.Core.MOM;
using Langlab.Dictionary.Contracts;
using Langlab.MOM.Events.Dictionary;
using System;
using System.Threading.Tasks;

namespace Langlab.Dictionary.Services
{
    public class DictionaryService : BaseService, IDictionaryService
    {
        readonly IExternalDictionary _externalDictionary;
        readonly ILanglabDictionaryStore _langlabDictionary;
        readonly ICleanerTray _cleanerTray;
        public DictionaryService(
            IExternalDictionary externalDictionary, 
            ILanglabDictionaryStore langlabDictionary,
            IOutputTray outputTray,
            ICleanerTray cleanerTray):
            base(outputTray)
        {
            _externalDictionary = externalDictionary;
            _langlabDictionary = langlabDictionary;
            _cleanerTray = cleanerTray;
        }

        //todo: 
        // 1.- Mejorar los rendimientos y escribir en los tray en paralelo.
        // 2.- Usar un topic en vez de una queue. la cola produce cierto acoplamiento y además 
        //      no permite n elementos logicos de escucha. Por ejemplo en el futuro me podría venir bien preparar datos estadísticos sobre 
        //      la búsqueda de palabras.
        public Task Handle(SearchWord query)
        {
            return this.Handle(query, async () =>
            {
                IEvent @event = null;
                var word = await _langlabDictionary.FetchWord(query.Word, query.Language, query.TranslationLanguage);
                if (word == null)
                {
                    word = await _externalDictionary.FetchWord(query.Word, query.Language, query.TranslationLanguage);
                    if (word != null) await _langlabDictionary.PushWord(word);
                }
                if (word == null)
                {
                    var payload = new NonExistentWordSearchedPayLoad(query.Word, query.Language, query.TranslationLanguage);
                    @event = new NonExistentWordSearched(query.Id, query.CreatedBy, DateTime.Now, payload);
                }
                else
                {
                    @event = new WordSearched(query.Id, query.CreatedBy, DateTime.Now, word);
                    await _cleanerTray.Send(@event);
                }
                return @event;
            });
        }
    }
}
