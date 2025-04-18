using Plugins.InputHandler;
using UnityEngine;
using Zenject;

namespace Plugins.PlayerController
{
    public class FPSCamera : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Vector2 _lookAndleLimit;
        
        private Camera _camera;
        private float _yAngle;

        [Inject]
        public void Init(IInput input)
        {
            input.Rotated += Look;
            _camera = GetComponent<Camera>();
        }

        private void Look(Vector3 mouseDelta)
        {
            _yAngle -= mouseDelta.y * _rotationSpeed * Time.deltaTime;
            _yAngle = Mathf.Clamp(_yAngle, _lookAndleLimit.x, _lookAndleLimit.y);
            _camera.transform.localRotation = Quaternion.Euler(_yAngle, 0, 0);
        }
    }
}