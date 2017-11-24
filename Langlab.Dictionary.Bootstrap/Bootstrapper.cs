using Langlab.Dictionary.Contracts;
using Langlab.Dictionary.Services;
using Langlab.Dictionary.Store;
using Langlab.MOM.Conectors;

namespace Langlab.Dictionary.Bootstrap
{
    public class Bootstrapper
    {
        public IDictionaryService GetDictionary()
        {
            var externalDictionary = new CambridgeDictionaryStore();
            var langlabDictionary = new LanglabDictionaryStore();
            var momConfig = new MomConfiguration();
            var outputTray = new OutputTray(momConfig);
            var cleanerTray = new CleanerTray(momConfig);

            return new DictionaryService(externalDictionary, langlabDictionary, outputTray, cleanerTray);
        }
    }
}
