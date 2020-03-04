using System.Threading.Tasks;

namespace SuperHero.Interfaces
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}
