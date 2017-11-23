using Langlab.WordStacks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Langlab.WordStack.Store
{
    public class WordStackConfigurationStore : IWordStackConfigurationStore
    {
        public Task<WordStackConfiguration> FetchConfiguration(int stackId)
        {
            throw new NotImplementedException();
        }
    }
}
