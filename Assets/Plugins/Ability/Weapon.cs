using System;
using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.LoopForge;
using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.Ability
{
    public abstract class Weapon : MonoBehaviour, IControllable, IUnitComponent
    {
        [SerializeField] protected float _fireRate;
        [SerializeField] protected LayerMask _targetLayer;

        protected float _lastShootTime;
        protected IInput _input;
        protected UnitProperties _unitProperties;

        public abstract void Fire();
        protected abstract void OnTick();

        public void SetInput(IInput input)
        {
            _input = input;
        }

        public virtual void Init(UnitProperties unitProperties)
        {
            _unitProperties = unitProperties;
        }

        private void OnEnable()
        {
            CoreLoop.OnTick += OnTick;
        }

        private void OnDisable()
        {
            CoreLoop.OnTick -= OnTick;
        }
    }
}