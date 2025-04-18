namespace Plugins.GameInitialization
{
    public interface IGamePreLoadState : IGameInitializationStates
    {
        public void PreLoad();
    }
}