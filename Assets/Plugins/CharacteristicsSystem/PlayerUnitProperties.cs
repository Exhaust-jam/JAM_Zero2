using Plugins.HealthSystem;
using UnityEngine;

namespace Plugins.CharacteristicsSystem
{
    public class PlayerUnitProperties : UnitProperties
    {
        [SerializeField] private float _abilityFireRate;
        [SerializeField] private float _gunFireRate;
        public float LastShootTime {get; set;}

        public float AbilityCooldown
        {
            get
            {
                return _abilityFireRate;
            }
        }
        public float MaxHealth => _maxHealth;
    }
}