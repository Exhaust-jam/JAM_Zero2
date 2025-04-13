using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.Ability
{
    public class AIRotation : Rotation
    {
        protected override void Rotate()
        {
            var delta = _input.GetMouseMovement();
            delta.y = 0;
            _rigidbody.transform.forward = Vector3.MoveTowards(_rigidbody.transform.forward, 
                delta,
                _angleSpeed * Time.deltaTime);
        }
    }
}