using System;
using UnityEngine;

namespace Plugins.InputHandler
{
    public interface IInput
    {
        public Action<Vector3> Moved  { get; set; }
        public Action<Vector3> Rotated { get; set; }
        public Action Fired { get; set; }
        public Action Jumped { get; set; }
        public Action RunnedUp { get; set; }
        public Action RunnedDown { get; set; }
        public Action Crouched { get; set; }
        public Action CrouchedUp { get; set; }
    }
}