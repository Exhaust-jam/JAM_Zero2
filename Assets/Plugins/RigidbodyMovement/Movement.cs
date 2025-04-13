using System;
using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using Plugins.HealthSystem;
using Plugins.LoopForge;
using UnityEngine;

namespace Plugins.RigidbodyMovement
{
    public class Movement : MonoBehaviour, IUnitComponent, IControllable
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Surface _surface;
        [SerializeField] private float _jumpForce = 5f;
        
        protected UnitProperties _unitProperties;
        private Transform _root;
        protected IInput _input;

        public void SetInput(IInput input)
        {
            _input = input;
        }

        public void Init(UnitProperties unitProperties)
        {
            _unitProperties = unitProperties;
        }

        protected virtual void OnTick()
        {
            Move();
            if (_input.GetJump())
            {
                Jump();
            }
        }

        protected virtual void Move()
        {
            var horizontal = _surface.Project(_input.GetKeyboardMovement() *
                                              _unitProperties.Speed.Value);
            var upVelocity = Mathf.Clamp(_rigidbody.linearVelocity.y, -100f, 0.2f);
            
            _rigidbody.linearVelocity = horizontal + upVelocity * Vector3.up;
            if (horizontal.magnitude > 0)
            {
                _unitProperties.UnitSoundsStorage.Play(Sound.Walk);
            }
        }

        private void Jump()
        {
            if (_surface.On())
                _rigidbody.linearVelocity += Vector3.up * _jumpForce;
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