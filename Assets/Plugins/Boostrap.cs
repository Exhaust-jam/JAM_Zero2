using System.Collections.Generic;
using Plugins.Bots;
using Plugins.CharacteristicsSystem;
using Plugins.LoopForge;
using Plugins.Player;
using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins
{
    public class Boostrap : MonoBehaviour
    {
        [SerializeField] private PlayerInit _playerInit;
        [SerializeField] private UserControl _control;
        [SerializeField] private Unit _unitUnderPlayerControl;
        [Space]
        [Header("AI")]
        [SerializeField] private List<BotFactory> _botFactory;

        private void Awake()
        {
            CoreLoop.PauseOff();
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _unitUnderPlayerControl.Init();
            _playerInit.Init(_control, _unitUnderPlayerControl);
            foreach (var factory in _botFactory)
            {
                factory.Init(_unitUnderPlayerControl.transform);
            }
        }
    }
}