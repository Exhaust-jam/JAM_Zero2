using Plugins.FX.Sound;
using Plugins.HealthSystem;

namespace Plugins.CharacteristicsSystem
{
    public class HealthAI : Health
    {
        public override void TakeDamage(float damage)
        {
            _unitProperties.AnimationsProperties.TakeDamage();
            _unitProperties.UnitSoundsStorage.Play(Sound.Damage);
            base.TakeDamage(damage);
        }
    }
}