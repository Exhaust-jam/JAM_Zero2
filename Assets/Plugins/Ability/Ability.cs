using System;
using System.Collections;
using Plugins.CharacteristicsSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plugins.Ability
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private ZeroOutValues _target;

        public void Launch(ZeroOutValues target)
        {
            _target = target;
            StartCoroutine(InvestigateRoutine());
        }

        private IEnumerator InvestigateRoutine()
        {
            while (_target != null && (transform.position - _target.transform.position).sqrMagnitude > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
                yield return null;
            }

            if (_target == null)
            {
                Destroy(gameObject);
            }
            else
            {
                ZeroOut();
            }
        }

        private void ZeroOut()
        {
            _target.ToZero();
            Destroy(gameObject);
        }
    }
}