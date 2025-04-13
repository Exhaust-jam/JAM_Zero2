using System;
using Plugins.HealthSystem;

namespace Plugins.CharacteristicsSystem
{
    public class UnitProperty<T> : IUnitProperty
    {
        private T _value;
        private readonly T _defaultValue;
        private readonly Characteristics _characteristic;
        
        public event Action OnValueChanged;
        public event Action OnValueReset;

        public T Value
        {
            get { return _value; }
            set
            {
                OnValueChanged?.Invoke();
                _value = value;
            }
        }
        
        public Characteristics Characteristic => _characteristic;

        public UnitProperty(T value, T defaultValue, Characteristics characteristic)
        {
            _value = value;
            _defaultValue = defaultValue;
            _characteristic = characteristic;
        }

        public void Reset()
        {
            _value = _defaultValue;
            OnValueReset?.Invoke();
        }
    }
}