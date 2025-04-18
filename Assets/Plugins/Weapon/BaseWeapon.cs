using UnityEngine;

namespace Plugins.Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        private WeaponProperty _properties;

        public void Init(WeaponProperty properties)
        {
            _properties = properties;
        }
        
        public abstract void Fire();

        protected void RaycastCheck()
        {
            if (Physics.Raycast(_properties.Head.position, _properties.Head.forward, out RaycastHit hit,
                    _properties.ShootDistance.Value))
            {
                
            }
        }
    }
}