using Plugins.GameInitialization;
using Plugins.PlayerController;
using UnityEngine;
using Zenject;

namespace Plugins
{
    public class Boostrap : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        
        [Inject]
        public void Init(FPSControllerFactory factory)
        {
            factory.Make(_playerSpawnPoint.position);
        }
    }
}