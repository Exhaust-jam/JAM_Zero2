using System.Collections.Generic;
using System.Linq;
using Plugins.Animations;
using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using UnityEngine;

namespace Plugins.HealthSystem
{
    [DisallowMultipleComponent]
    public class UnitProperties : MonoBehaviour
    {
        [SerializeField] protected float _maxHealth;
        [SerializeField] protected float _startArmor;
        [SerializeField] protected float _damage;
        [SerializeField] protected float _speed;
        [SerializeField] protected bool _isSmart;
        [SerializeField] protected UnitSoundsStorage _unitSoundsStorage;

        [SerializeField] protected Transform _head;
        [field: SerializeField] public AnimationsProperties AnimationsProperties { get; private set; }
        
        private List<IUnitProperty> _unitProperties;
        public IReadOnlyList<IUnitProperty> Properties => _unitProperties;
        
        public UnitSoundsStorage UnitSoundsStorage => _unitSoundsStorage;
        
        public UnitProperty<float> CurrentHp { get; set; }
        public UnitProperty<float> Armor {get; set;}
        public UnitProperty<float> Damage {get; set;}
        public UnitProperty<float> Speed {get; set;}
        public UnitProperty<bool> IsSmart {get; set; }
        
        public Transform Head => _head;
        
        public void Init()
        {
            CurrentHp = new UnitProperty<float>(_maxHealth, 0, Characteristics.Health);
            Armor = new UnitProperty<float>(_startArmor, 0, Characteristics.Armor);
            Damage = new UnitProperty<float>(_damage, 0, Characteristics.Damage);
            Speed = new UnitProperty<float>(_speed, 0, Characteristics.Speed);
            IsSmart = new UnitProperty<bool>(_isSmart, false, Characteristics.IsSmart);
            _unitProperties = new object[] { CurrentHp, Armor, Damage, Speed, IsSmart }.Cast<IUnitProperty>().ToList();
        }
    }
}