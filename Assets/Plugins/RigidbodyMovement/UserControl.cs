using UnityEngine;

namespace Plugins.RigidbodyMovement
{
    public class UserControl : MonoBehaviour, IInput
    {
        [SerializeField] private float _sensivity = 5;
        
        private readonly string Horizontal =  "Horizontal";
        private readonly string Vertical = "Vertical";
        private readonly string MouseX = "Mouse X";
        private readonly string MouseY = "Mouse Y";
        
        private Transform _root;

        private void Awake()
        {
            _root = Camera.main.transform;
        }

        public Vector3 GetKeyboardMovement()
        {
            float z = Input.GetAxisRaw(Vertical);
            float x = Input.GetAxisRaw(Horizontal);
            Vector3 move = new Vector3(x, 0, z);
            move = _root.TransformDirection(move);
            move.y = 0;
            return move.normalized;
        }

        public Vector3 GetMouseMovement()
        {
            float x = Input.GetAxis(MouseX);
            float y = Input.GetAxis(MouseY);
            
            Vector3 move = new Vector3(x, y) * _sensivity;
            
            return move;
        }

        public bool GetAction()
        {
            return Input.GetKey(KeyCode.E);
        }

        public bool GetFire()
        {
            return Input.GetKey(KeyCode.Mouse0);
        }

        public bool GetSpecialAction()
        {
            return Input.GetKeyUp(KeyCode.E);
        }

        public bool GetJump()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}