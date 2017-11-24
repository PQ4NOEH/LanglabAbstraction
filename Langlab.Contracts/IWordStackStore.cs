using Langlab.Core.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Langlab.WordStacks.Contracts
{
    public interface IWordStackStore
    {
        Task<IEnumerable<Word>> GetTestData(string userId, string academy, int stackId);
    }
}
