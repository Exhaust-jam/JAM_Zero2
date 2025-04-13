using Plugins.FX.Sound;
using Plugins.LoopForge;
using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.Ability
{
    public class CrosshairUnitCapture : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private UnitSoundsStorage _unitSoundsStorage;

        private static Collider _target;
        
        private IInput _input;
        private Camera _camera;
        private CrosshairRenderer _renderer;
        
        public static Collider Target => _target;
        
        public void Init(IInput input, CrosshairRenderer renderer)
        {
            _input = input;
            _camera = Camera.main;
            _renderer = renderer;
        }

        private void OnTick()
        {
            if (_input.GetAction())
            { 
                _unitSoundsStorage.Play(Sound.AbilityWait);
                TryCapture();
            } else if (_input.GetSpecialAction())
            {
                _unitSoundsStorage.Stop(Sound.AbilityWait);
                _renderer.Clear();
            }
        }

        private void TryCapture()
        {
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _mask))
            {
                Vector3 screenPosition = _camera.WorldToScreenPoint(hit.collider.transform.position);
                _target = hit.collider;
                _renderer.Draw(screenPosition);
            }
            else
            {
                _target = null;
                _renderer.Clear();
            }
        }
        
        private void OnEnable()
        {
            CoreLoop.OnTick += OnTick;
        }

        private void OnDisable()
        {
            CoreLoop.OnTick -= OnTick;
        }
    }
}