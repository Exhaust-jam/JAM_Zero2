using System;
using UnityEngine;

namespace Plugins.InputHandler
{
    [Serializable]
    public class CommandSet
    {
        public ControlCommand Command;
        public KeyCode Key;
        public string Axis;
        public bool UseAxis;
    }
}