using Plugins.LoopForge;
using UnityEngine;

namespace Plugins.RigidbodyMovement
{
    public class Rotation : MonoBehaviour, IControllable
    {
        [SerializeField] protected float _angleSpeed;
        [SerializeField] protected Rigidbody _rigidbody;
        
        protected IInput _input;

        public void SetInput(IInput input)
        {
            _input = input;
        }

        private void OnTick()
        {
            Rotate();
        }

        protected virtual void Rotate()
        {
            var angle = _input.GetMouseMovement().x;
            if (angle != 0)
            {
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                _rigidbody.MoveRotation(_rigidbody.rotation * rotation);
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