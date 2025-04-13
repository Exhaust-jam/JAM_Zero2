using System;
using Plugins.HealthSystem;
using Plugins.Popup;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plugins.CharacteristicsSystem
{
    public class ZeroOutValues : MonoBehaviour, IUnitComponent
    {
        private UnitProperties _unitProperties;
        private Transform _transform;
        public void Init(UnitProperties unitProperties)
        {
            _unitProperties = unitProperties;
            _transform = transform;
        }

        public virtual void ToZero()
        {
            Characteristics characteristics = (Characteristics)Random.Range(0, Enum.GetValues(typeof(Characteristics)).Length);
            _unitProperties.Properties[(int)characteristics].Reset();
            PopupFactory.Make(_transform.position ,IconCharacteristicStorage.IconsDictionary[characteristics]);
        }
    }
}