using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.Bots
{
    public class AIInput : MonoBehaviour, IInput
    {
        public bool FireActive { get; set; }
        public bool RotateActive { get; set; }
        public Transform Player { get; set; }
        public Transform Unit { get; set; }
        
        public Vector3 GetKeyboardMovement()
        {
            return Player.position;
        }

        public Vector3 GetMouseMovement()
        {
            return Player.position - Unit.position;
        }

        public bool GetAction()
        {
            return false;
        }

        public bool GetFire()
        {
            return FireActive;
        }

        public bool GetSpecialAction()
        {
            throw new System.NotImplementedException();
        }

        public bool GetJump()
        {
            throw new System.NotImplementedException();
        }
    }
}