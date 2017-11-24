using Langlab.Core.CORS;
using System.Threading.Tasks;

namespace Langlab.Core.MOM
{
    public interface IMomTray
    {
        Task Send(IEvent @event);
    }
    public interface IOutputTray : IMomTray { }
    public interface ICleanerTray : IMomTray { }


}
