using Plugins.HealthSystem;
using UnityEngine;

namespace Plugins.Bots
{
    public class BotProperty : UnitProperties
    {
        [field: SerializeField] public float _distanceToShoot { get; private set; }
    }
}