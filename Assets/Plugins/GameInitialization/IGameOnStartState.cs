using Zenject;

namespace Plugins.GameInitialization
{
    public interface IGameOnStartState : IGameInitializationStates
    {
        void OnStart(DiContainer container);
    }
}