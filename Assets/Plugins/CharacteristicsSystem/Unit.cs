using System;
using Plugins.Animations;
using Plugins.HealthSystem;
using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.CharacteristicsSystem
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private GameObject _componentContainer;
        private AnimationsProperties _animationsProperties;
        public event Action<Unit> OnDestroyed;
        
        public void Init()
        {
            var props = _componentContainer.GetComponent<UnitProperties>();
            props.Init();
            _animationsProperties = props.AnimationsProperties;
            var comps = _componentContainer.GetComponents<IUnitComponent>();
            foreach (var comp in comps)
            {
                comp.Init(props);
                if (comp is Health health)
                {
                    health.OnDeath += PreDestroy;
                }
            }
        }

        private void PreDestroy()
        {
            _animationsProperties?.Die();
            OnDestroyed?.Invoke(this);
        }
    }
}