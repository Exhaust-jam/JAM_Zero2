using Plugins.GameInitialization;
using Plugins.InputHandler;
using UnityEngine;
using Zenject;

namespace Plugins.PlayerController
{
    public class FPSControllerFactory : MonoBehaviour, IRestartable
    {
        private Vector3 _spawnPoint;
        private FPSController _fpsControllerPrefab, _instance;
        private FPSCamera _fpsCameraPrefab;
        private IInput _input;

        [Inject]
        public void Init(FPSController fpsController, FPSCamera fpsCamera, IInput input)
        {
            _input = input;
            _fpsControllerPrefab = fpsController;
            _fpsCameraPrefab = fpsCamera;
        }

        public void Make(Vector3 position)
        {
            _spawnPoint = position;
            var movement = new Movement(_input);
            var run = new Run(_input);
            var headShake = new HeadShake(_input);
            var crouch = new Crouch(_input);
            _instance = Instantiate(_fpsControllerPrefab, _spawnPoint, Quaternion.identity);
            var cameraPosition = _instance.GetComponent<FPSConstruct>().Head;
            _fpsCameraPrefab.transform.parent = cameraPosition;
            _fpsCameraPrefab.transform.localPosition = Vector3.zero;
            _instance.Init();
            _instance.Add(movement);
            _instance.Add(run);
            _instance.Add(headShake);
            _instance.Add(crouch);
        }

        public void Restart()
        {
            if (_instance != null)
            {
                _instance.Init();
                _instance.transform.position = _spawnPoint;
            }
        }
    }
}