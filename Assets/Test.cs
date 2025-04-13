using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * 10);
        }
    }
}