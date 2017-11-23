using Langlab.WordStacks.Contracts;
using System;
using System.Threading.Tasks;

namespace Langlab.WordStack.Services
{
    public class WordStackService : IWordStackService
    {
        readonly IWordStackConfigurationStore _wordStackConfigurationStore;
        readonly IWordStackStore _wordStackStore;

        public WordStackService(
            IWordStackConfigurationStore wordStackConfigurationStore,
            IWordStackStore wordStackStore)
        {
            _wordStackConfigurationStore = wordStackConfigurationStore;
            _wordStackStore = wordStackStore;
        }

        public Task Handle(GetStackTest demand)
        {
            throw new NotImplementedException();
        }

        public Task Handle(SetStackTest demand)
        {
            throw new NotImplementedException();
        }
    }
}
