using System;
using UnityEngine;

namespace Plugins.LoopForge
{
    public class CoreLoop : MonoBehaviour
    {
        public static event Action OnTick;
        public static event Action OnFixedTick;
        public static event Action OnLateTick;
        public static event Action OnUnPausedTick;

        private static bool _paused;

        private void Update()
        {
            if (!_paused) OnTick?.Invoke();
            OnUnPausedTick?.Invoke();
        }

        private void FixedUpdate()
        {
            if (_paused) return;
            OnFixedTick?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateTick?.Invoke();
        }

        public static void PauseOn()
        {
            _paused = true;
        }

        public static void PauseOff()
        {
            _paused = false;
        }
    }
}