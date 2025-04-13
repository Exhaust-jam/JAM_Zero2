using System;
using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using UnityEngine;

namespace Plugins.HealthSystem
{
    public class Health : MonoBehaviour, IUnitComponent
    {
        protected UnitProperties _unitProperties;
        
        public event Action OnDeath;

        public void Init(UnitProperties unitProperties)
        {
            _unitProperties = unitProperties;
            _unitProperties.CurrentHp.OnValueReset += Die;
        }
        
        public virtual void TakeDamage(float damage)
        {
            if (_unitProperties.CurrentHp.Value <= 0)
            {
                return;
            }
            _unitProperties.CurrentHp.Value -= damage * (100f / (100 + _unitProperties.Armor.Value));
            if (_unitProperties.CurrentHp.Value <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _unitProperties.UnitSoundsStorage.Play(Sound.Die);
            OnDeath?.Invoke();
        }
    }
}