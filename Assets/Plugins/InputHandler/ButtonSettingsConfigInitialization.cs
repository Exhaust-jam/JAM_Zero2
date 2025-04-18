using Plugins.GameInitialization;
using Plugins.PlayerController;
using Plugins.ResourceManagment;
using UnityEngine;
using Zenject;

namespace Plugins.InputHandler
{
    public class ButtonSettingsConfigInitialization : IGameOnLoadedState
    {
        private readonly string _inputPath = "Player/Input/PCInput";
        private readonly string _buttonSettings = "Player/Input/ButtonSettings";
        private readonly string _player = "Player/Player";
        private readonly string _factory = "Player/Factory";
        private readonly string _fpsCamera = "Player/FPSCamera";

        public void OnLoaded(DiContainer container)
        {
            var factory = Resources.Load<FPSControllerFactory>(_factory);
            var buttons = Resources.Load<ButtonSettings>(_buttonSettings);
            var input = Resources.Load<PCInput>(_inputPath);
            //ResourceManager.Register(input);
            container.Bind<FPSCamera>().FromComponentInNewPrefab(
                Resources.Load<FPSCamera>(_fpsCamera)
            ).AsSingle();
            container.Bind<ButtonSettings>().FromInstance(buttons).AsSingle();
            container.Bind<IInput>().To<PCInput>().FromComponentInNewPrefab(input).AsSingle();
            container.Bind<FPSController>().FromResources(_player).AsSingle();
            container.Bind<FPSControllerFactory>().FromComponentInNewPrefab(factory).AsSingle();
            
            ResourceManager.Init();
        }
    }
}