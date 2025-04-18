using Zenject;

namespace Plugins.GameInitialization
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Core core = new Core();
            core.Start(Container);
        }
    }
}