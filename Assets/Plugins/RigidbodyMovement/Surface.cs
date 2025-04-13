using System.Collections;
using UnityEngine;

namespace Plugins.RigidbodyMovement
{
    public class Surface : MonoBehaviour
    {
        [SerializeField] private LayerMask _ground;
        [SerializeField] private float _distance;

        private Vector3? _surfaceNormal;

        private void Awake()
        {
            StartCoroutine(SurfaceDetectRoutine());
        }

        public bool On()
        {
            return _surfaceNormal != null;
        }

        public Vector3 Project(Vector3 direction)
        {
            if (_surfaceNormal == null)
            {
                return direction * 0.5f;
            }
            return Vector3.ProjectOnPlane(direction, _surfaceNormal.Value);
        }

        private IEnumerator SurfaceDetectRoutine()
        {
            var duration = new WaitForSeconds(0.05f);
            while (true)
            {
                if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hit, _distance, _ground))
                {
                    _surfaceNormal = hit.normal;
                }
                else
                {
                    _surfaceNormal = null;
                }
                yield return duration;
            }
        }
    }
}