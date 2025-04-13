using UnityEngine;

namespace Plugins.RigidbodyMovement
{
    public interface IInput
    {
        Vector3 GetKeyboardMovement();
        Vector3 GetMouseMovement();
        bool GetAction();
        bool GetFire();
        bool GetSpecialAction();
        bool GetJump();
    }
}