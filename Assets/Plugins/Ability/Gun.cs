using Plugins.FX;
using Plugins.FX.Sound;
using Plugins.HealthSystem;
using UnityEngine;

namespace Plugins.Ability
{
    public class Gun : Weapon
    {
        [SerializeField] protected BulletFX _bullet;
        [SerializeField] protected Transform _bulletSpawn;
        [SerializeField] protected float _bulletDistance;
        public override void Fire()
        {
            if (Time.time - _lastShootTime >= _fireRate)
            {
                if (Physics.Raycast(_unitProperties.Head.position, _unitProperties.Head.forward, out RaycastHit hit,  Mathf.Infinity, _targetLayer))
                {
                    hit.collider.GetComponent<Health>()?.TakeDamage(_unitProperties.Damage.Value);
                    Fx(hit.point);
                }
                else
                {
                    Fx(_unitProperties.Head.position + _unitProperties.Head.forward * _bulletDistance);
                }
                _unitProperties.UnitSoundsStorage.Play(Sound.Fire);
                _lastShootTime = Time.time;
                _unitProperties.AnimationsProperties.Fire();
            }
        }

        protected void Fx(Vector3 position)
        {
            var fx = Instantiate(_bullet, _bulletSpawn.position, Quaternion.identity);
            fx.Launch(position);
        }

        protected override void OnTick()
        {
            if (_input.GetFire())
            {
                Fire();
            }
        }
    }
}