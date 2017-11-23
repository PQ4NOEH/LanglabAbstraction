using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Langlab.WordStacks.Contracts
{
    public interface IWordStackConfigurationStore
    {
        Task<WordStackConfiguration> FetchConfiguration(int stackId);
    }

    public class WordStackConfiguration
    {

    }
}
