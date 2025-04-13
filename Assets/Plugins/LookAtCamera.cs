using Plugins.LoopForge;
using UnityEngine;

namespace Plugins
{
    public class LookAtCamera : MonoBehaviour
    {
        private void OnTick()
        {
            transform.LookAt(Camera.main.transform);
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