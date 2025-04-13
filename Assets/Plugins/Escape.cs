using Plugins.CharacteristicsSystem;
using Plugins.LoopForge;
using UnityEngine;

namespace Plugins
{
    public class Escape : MonoBehaviour
    {
        [SerializeField] private Unit _playerUnit;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _boolParametr;
        private bool _active = false;

        private void OnTick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!_active) Show();
                else Hide();
            }
        }

        private void Deactivate()
        {
            foreach (var controllable in _playerUnit.Controllables)
            {
                (controllable as MonoBehaviour).enabled = false;
            }
        }

        private void Activate()
        {
            foreach (var controllable in _playerUnit.Controllables)
            {
                (controllable as MonoBehaviour).enabled = true;
            }
        }

        public void Show()
        {
            _active = !_active;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CoreLoop.PauseOn();
            _animator.SetBool(_boolParametr, true);
            Deactivate();
        }

        public void Hide()
        {
            _active = !_active;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CoreLoop.PauseOff();
            _animator.SetBool(_boolParametr, false);
            Activate();
        }

        private void OnEnable()
        {
            CoreLoop.OnUnPausedTick += OnTick;
        }

        private void OnDisable()
        {
            CoreLoop.OnUnPausedTick -= OnTick;
        }
    }
}