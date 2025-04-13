using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.LoopForge;
using UnityEngine;

namespace Plugins.RigidbodyMovement
{
    public class HeadLook : MonoBehaviour, IControllable, IUnitComponent
    {
        [SerializeField] private float _upLimit;
        [SerializeField] private float _downLimit;
        [SerializeField] private float _verticalSensitivity;
        [SerializeField] protected float _rotationSpeed = 40;
        
        protected IInput _input;
        protected Transform _headTransform;
        private float _rotY;
        private float _rotX;
        
        public Transform Head => _headTransform;

        public void SetInput(IInput input)
        {
            _input = input;
        }

        public void Init(UnitProperties unitProperties)
        {
            _headTransform = unitProperties.Head;
        }

        private void OnTick()
        {
            Look();
        }

        protected virtual void Look()
        {
            var delta = _input.GetMouseMovement().y;
            _rotY += delta * _verticalSensitivity;
            _rotY = Mathf.Clamp(_rotY, -90f, 90f);
            Quaternion quaternion = Quaternion.Euler(-_rotY, _headTransform.transform.eulerAngles.y, 0);
            _headTransform.rotation = Quaternion.Slerp(_headTransform.rotation, quaternion, _rotationSpeed * Time.deltaTime);
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