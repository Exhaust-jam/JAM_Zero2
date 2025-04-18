using Plugins.CharacteristicsSystem;
using UnityEngine;

namespace Plugins.Weapon
{
    public class WeaponProperty : MonoBehaviour
    {
        [field: SerializeField] private float _startDamage;
        [field: SerializeField] private float _shootDistance;
        [field: SerializeField] public Transform Head {get; set;}
        
        public UnitProperty<float> Damage { get; private set; }
        public UnitProperty<float> ShootDistance { get; private set; }

        public virtual void Init()
        {
            Damage = new UnitProperty<float>(_startDamage, 0, Characteristics.Damage);
            ShootDistance = new UnitProperty<float>(_shootDistance, 0, Characteristics.Damage);
        }
    }
}