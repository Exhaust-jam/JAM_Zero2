using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using Plugins.HealthSystem;
using UnityEngine;

namespace Plugins.Ability
{
    public class Hand : Weapon
    {
        [SerializeField] private Ability _ability;
        [SerializeField] protected Transform _firePoint;
        
        private PlayerUnitProperties _playerUnitProperties;
        
        public override void Init(UnitProperties unitProperties)
        {
            _playerUnitProperties = (PlayerUnitProperties)unitProperties;
            _fireRate = _playerUnitProperties.AbilityCooldown;
        }
        
        public override void Fire()
        {
            if (Time.time - _playerUnitProperties.LastShootTime >= _fireRate)
            {
                if (CrosshairUnitCapture.Target != null)
                {
                    var ab = Instantiate(_ability, _firePoint.position, Quaternion.identity);
                    ab.Launch(CrosshairUnitCapture.Target.GetComponent<ZeroOutValues>());
                    _playerUnitProperties.LastShootTime = Time.time;
                    _playerUnitProperties.UnitSoundsStorage.Play(Sound.AbilityFire);
                }
            }
        }

        protected override void OnTick()
        {
            if (_input.GetSpecialAction())
            {
                Fire();
            }
        }
    }
}