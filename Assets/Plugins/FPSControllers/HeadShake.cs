using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.InputHandler;
using Plugins.LoopForge;
using UnityEngine;

namespace Plugins.PlayerController
{
    public class HeadShake : IUnitComponent
    {
        private FPSProperties _properties;
        private Vector3 _originalLocalPosition;
        private Vector3 _targetLocalPosition;
        private bool _movingDown = true;
        private bool _isShaking = false;

        public HeadShake(IInput input)
        {
            input.Moved += OnMove;
            CoreLoop.OnTick += Tick;
        }

        public void Init(UnitProperties unitProperties)
        {
            _properties = (FPSProperties)unitProperties;
            _originalLocalPosition = _properties.Head.localPosition;
            _targetLocalPosition = _originalLocalPosition + Vector3.down * _properties.HeadShakedDownDeltaLimit;
        }

        private void OnMove(Vector3 direction)
        {
            _isShaking = true;
        }

        private void Tick()
        {
            if (!_isShaking || _properties?.Head == null) return;

            Vector3 current = _properties.Head.localPosition;
            Vector3 target = _movingDown ? _targetLocalPosition : _originalLocalPosition;

            float speed = _properties.CurrentSpeed;
            if (_properties.CurrentSpeed == 0 || !_properties.Construct.Controller.isGrounded)
            {
                target = _originalLocalPosition;
                speed = _properties.Speed.Value;
            }

            _properties.Head.localPosition = Vector3.MoveTowards(
                current,
                target,
                Time.deltaTime * _properties.HeadShakeForce * speed
            );

            if (Vector3.Distance(current, target) < 0.001f)
            {
                _movingDown = !_movingDown;
            }
        }
    }
}