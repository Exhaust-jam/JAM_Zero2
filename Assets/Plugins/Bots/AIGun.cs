using System;
using Plugins.Ability;
using Plugins.FX.Sound;
using Plugins.HealthSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plugins.Bots
{
    public class AIGun : Gun
    {
        [SerializeField, Range(0, 1)] private float _hitChance = 0.8f;
        
        public override void Fire()
        {
            if (Time.time - _lastShootTime >= _fireRate)
            {
                if (Physics.Raycast(_unitProperties.Head.position, _unitProperties.Head.forward, out RaycastHit hit,  Mathf.Infinity, _targetLayer))
                {
                    if (Random.Range(0f, 1f) <= _hitChance)
                    {
                        hit.collider.GetComponent<Health>().TakeDamage(_unitProperties.Damage.Value);
                    }
                }
                Fx(_unitProperties.Head.position + _unitProperties.Head.forward * _bulletDistance);
                _unitProperties.UnitSoundsStorage.Play(Sound.Fire);
                _lastShootTime = Time.time;
            }
        }
    }
}