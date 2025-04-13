using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.Ability
{
    public class AIHeadLook : HeadLook
    {
        protected override void Look()
        {
            Vector3 targetDirection = _input.GetMouseMovement();

            Vector3 verticalDirection = Vector3.ProjectOnPlane(targetDirection, _headTransform.right);

            if (verticalDirection.sqrMagnitude < 0.001f)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(verticalDirection, _headTransform.up);
            Vector3 localEuler = lookRotation.eulerAngles;
            localEuler = NormalizeAngles(localEuler);

            float maxVertical = 30f;
            localEuler.x = Mathf.Clamp(localEuler.x, -maxVertical, maxVertical);
            localEuler.y = 0f;
            localEuler.z = 0f;

            Quaternion clampedRotation = Quaternion.Euler(localEuler);

            _headTransform.localRotation = Quaternion.Slerp(
                _headTransform.localRotation,
                clampedRotation,
                _rotationSpeed * Time.deltaTime
            );
            Vector3 NormalizeAngles(Vector3 angles)
            {
                angles.x = NormalizeAngle(angles.x);
                angles.y = NormalizeAngle(angles.y);
                angles.z = NormalizeAngle(angles.z);
                return angles;
                
                float NormalizeAngle(float angle)
                {
                    angle = angle % 360;
                    if (angle > 180) angle -= 360;
                    return angle;
                }
            }

        }
    }
}