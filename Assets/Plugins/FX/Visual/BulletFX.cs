using Plugins.LoopForge;
using UnityEngine;

namespace Plugins.FX
{
    public class BulletFX : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 _target;
        
        public void Launch(Vector3 target)
        {
            _target = target;
            Destroy(gameObject, 10);
        }

        private void OnTick()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
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