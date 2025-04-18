using Zenject;

namespace Plugins.GameInitialization
{
    public interface IGameOnLoadedState : IGameInitializationStates
    {
        void OnLoaded(DiContainer  container);
    }
}