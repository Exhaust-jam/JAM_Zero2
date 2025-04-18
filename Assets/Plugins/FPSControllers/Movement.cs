using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.InputHandler;
using UnityEngine;

namespace Plugins.PlayerController
{
    public class Movement : IUnitComponent
    {
        private float _verticalVelocity;
        private float _velocityBeforeJump;
        
        private bool _isJumping;
        
        private FPSProperties _properties;
        
        public void Init(UnitProperties unitProperties)
        {
            _properties = (FPSProperties)unitProperties;
        }

        public Movement(IInput input)
        {
            input.Moved += Move;
            input.Jumped += Jump;
            input.Rotated += Rotate;
        }

        private void Move(Vector3 direction)
        {
            var controller = _properties.Construct.Controller;
            direction = _properties.Construct.Controller.transform.TransformDirection(direction) *
                        _properties.Speed.Value;
            if (controller.isGrounded)
            {
                if (_verticalVelocity < 0)
                {
                    _verticalVelocity = _properties.MinGravityOnGround;
                }

                if (_isJumping)
                {
                    _verticalVelocity = _properties.JumpForce;
                    _velocityBeforeJump = _properties.Construct.Controller.velocity.magnitude;
                    _isJumping = false;
                }
            }
            else
            {
                direction = direction * _properties.MoveDirectionDecrease + 
                            _properties.Construct.Controller.velocity.normalized * _velocityBeforeJump;
                direction.y = 0;
                _verticalVelocity += Physics.gravity.y * Time.deltaTime;
            }
            _properties.Construct.Controller.Move((_verticalVelocity * Vector3.up +  direction) * Time.deltaTime);
            _properties.CurrentSpeed = _properties.Construct.Controller.velocity.magnitude;
        }

        private void Jump()
        {
            if (_properties.Construct.Controller.isGrounded)
            {
                _isJumping = true;
            }
        }

        private void Rotate(Vector3 mouseDelta)
        {
            Quaternion rotation = Quaternion.Euler(0, mouseDelta.x * _properties.RotationSpeed * Time.deltaTime, 0);
            _properties.Construct.Controller.transform.rotation *= rotation;
        }
    }
}