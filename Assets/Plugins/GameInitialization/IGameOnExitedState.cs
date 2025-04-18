namespace Plugins.GameInitialization
{
    public interface IGameOnExitedState : IGameInitializationStates
    {
        void OnExited();
    }
}