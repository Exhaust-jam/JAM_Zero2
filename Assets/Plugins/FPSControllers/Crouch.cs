using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.InputHandler;
using UnityEngine;

namespace Plugins.PlayerController
{
    public class Crouch : IUnitComponent
    {
        private FPSProperties _properties;
        
        public void Init(UnitProperties unitProperties)
        {
            _properties = (FPSProperties)unitProperties;     
        }

        public Crouch(IInput input)
        {
            input.Crouched += CrouchDown;
            input.CrouchedUp += CrouchUp;
        }

        private void CrouchDown()
        {
            _properties.Speed.Value = _properties.CrouchSpeed;
            var scale = _properties.transform.localScale;
            scale.y = _properties.CrouchScale;
            _properties.transform.localScale = scale;
        }
        
        private void CrouchUp()
        {
            _properties.Speed.Value = _properties.StartSpeed.Value;
            _properties.transform.localScale = Vector3.one;
        }
    }
}