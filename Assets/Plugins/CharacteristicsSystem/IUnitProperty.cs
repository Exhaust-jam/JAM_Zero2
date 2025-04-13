using System;

namespace Plugins.CharacteristicsSystem
{
    public interface IUnitProperty
    {
        public event Action OnValueChanged;
        public void Reset();
    }
}