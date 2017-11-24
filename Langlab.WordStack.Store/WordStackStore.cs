using Langlab.Core.Business;
using Langlab.WordStacks.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Langlab.WordStack.Store
{
    public class WordStackStore : IWordStackStore
    {
        readonly IWordStackConfigurationStore _wordStackConfigurationStore;
        public WordStackStore(IWordStackConfigurationStore wordStackConfigurationStore)
        {
            _wordStackConfigurationStore = wordStackConfigurationStore;
        }

        public async Task<IEnumerable<Word>> GetTestData(string userId, string academy, int stackId)
        {
            //1- Load Configuration
            var configuration = _wordStackConfigurationStore.FetchConfiguration(stackId);
            //2.- Get the data
            throw new NotImplementedException();
        }
    }
}
