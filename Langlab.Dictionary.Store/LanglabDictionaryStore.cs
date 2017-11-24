using Langlab.Core.Business;
using Langlab.Dictionary.Contracts;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Langlab.Dictionary.Store
{
    public class LanglabDictionaryStore : ILanglabDictionaryStore
    {
        readonly CloudBlobClient _client;

        public LanglabDictionaryStore()
        {
            _client = new CloudBlobClient(new Uri("https://langlabserverlesstorage.blob.core.windows.net"));
        }
        public async Task<Word> FetchWord(string word, string language, string translateTo)
        {
            Word result = null;
            var blob = _client.GetContainerReference("dictionary").GetBlockBlobReference(word);

            if( await blob.ExistsAsync())
            {
                var wordSerialized = await blob.DownloadTextAsync();
                result = JsonConvert.DeserializeObject<Word>(wordSerialized);
            }
            return result;
        }

        public Task PushWord(Word word)
        {
            var serializedWord = JsonConvert.SerializeObject(word);
            var blobref = _client.GetContainerReference("dictionary").GetBlockBlobReference(word.Text);
            return blobref.UploadTextAsync(serializedWord);
        }
    }
}
