using System.Threading.Tasks;

namespace Langlab.Core.CORS
{
    public interface IUserDemandHandler<T>
    {
        Task Handle(T demand);
    }
    public interface IQueryHandler<Q> : IUserDemandHandler<Q> where Q : IQuery { }
    public interface ICommandHandler<C> : IUserDemandHandler<C> where C : ICommand { }
}
