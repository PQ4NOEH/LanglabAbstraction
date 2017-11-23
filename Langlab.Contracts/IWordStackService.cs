using Langlab.Core.CORS;
using System;

namespace Langlab.WordStacks.Contracts
{
    public interface IWordStackService:
        IQueryHandler<GetStackTest>,
        ICommandHandler<SetStackTest>
    {
    }

    #region Command messages
    public class SetStackTest : Command
    {
        public StackTestUserAnswer Answer { get; }
        public StackTest Test { get; }
    }

    #endregion command messages

    #region Query messages
    public class GetStackTest : Query
    {
        public int StackId { get; }

        public GetStackTest() { }
    }
    #endregion Query messages

    #region Messages structures
    public class StackTest
    {
        public string QueryId { get; }
    }

    public class StackTestUserAnswer
    {
        public string QueryId { get; }
    }
    #endregion
}
