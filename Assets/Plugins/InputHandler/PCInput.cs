using System;
using System.Collections.Generic;
using Plugins.LoopForge;
using UnityEngine;
using Zenject;

namespace Plugins.InputHandler
{
    public class PCInput : MonoBehaviour, IInput
    {
        [SerializeField] private float _sensitivity;
        
        public Action<Vector3> Moved { get; set; }
        public Action<Vector3> Rotated { get; set; }
        public Action Fired { get; set; }
        public Action Jumped { get; set; }
        public Action RunnedDown { get; set; }
        public Action Crouched { get; set; }
        public Action CrouchedUp { get; set; }
        public Action RunnedUp { get; set; }

        private bool _crouched;

        private IReadOnlyDictionary<ControlCommand, CommandSet> _settings;
        
        [Inject]
        public void Init(ButtonSettings buttonSettings)
        {
            Debug.Log(buttonSettings);
            _settings = buttonSettings.CommandsMap;
            CoreLoop.OnTick += Tick;
        }

        private void Tick()
        {
            KeyboardMove();
            KeyboardJump();
            MouseMoved();
            Crouch();
            if (_crouched)
            {
                CrouchUp();
            }
            else
            {
                RunDown();
                RunUp();
            }
        }

        private void Crouch()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Crouched?.Invoke();
                _crouched = true;
            }
        }
        
        private void CrouchUp()
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                CrouchedUp?.Invoke();
                _crouched = false;
            }
        }
        
        private void RunDown()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
                RunnedDown?.Invoke();
        }

        private void RunUp()
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
                RunnedUp?.Invoke();
        }

        private void KeyboardMove()
        {
            float x = 0, y = 0;
            if (_settings.ContainsKey(ControlCommand.Horizontal))
            {
                x = Input.GetAxisRaw("Horizontal");
            }
            if (_settings.ContainsKey(ControlCommand.Vertical))
            {
                y = Input.GetAxisRaw("Vertical");
            }
            Moved?.Invoke(new Vector3(x, 0, y).normalized);
        }

        private void KeyboardJump()
        {
            if (Input.GetKeyDown(_settings[ControlCommand.Jump].Key))
            {
                Jumped?.Invoke();
            }
        }

        private void MouseMoved()
        {
            float x = Input.GetAxisRaw("Mouse X");
            float y = Input.GetAxisRaw("Mouse Y");
            Rotated?.Invoke(new Vector3(x, y, 0f) *  _sensitivity);
        }

        public void Dispose()
        {
            CoreLoop.OnTick -= Tick;
        }
    }
}