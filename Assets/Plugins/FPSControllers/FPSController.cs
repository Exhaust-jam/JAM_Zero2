using System.Collections.Generic;
using Plugins.CharacteristicsSystem;
using UnityEngine;

namespace Plugins.PlayerController
{
    [RequireComponent(typeof(FPSConstruct), typeof(FPSProperties))]
    public class FPSController : MonoBehaviour
    {
        private FPSProperties _properties;
        
        private List<IUnitComponent> _components = new List<IUnitComponent>();

        public void Init()
        {
            _properties = GetComponent<FPSProperties>();
            _properties.Init();
        }

        public void Add(IUnitComponent component)
        {
            component.Init(_properties);
            _components.Add(component);
        }
    }
}