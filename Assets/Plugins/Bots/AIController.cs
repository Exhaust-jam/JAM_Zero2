using System;
using Plugins.HealthSystem;
using Plugins.LoopForge;
using UnityEngine;
using UnityEngine.AI;

namespace Plugins.Bots
{
    public class AIController : MonoBehaviour
    {
        private UnitProperties _properties;
        private NavMeshAgent _agent;

        public void Init(UnitProperties properties)
        {
            _properties = properties;
        }

        private void Tick()
        {
            
        }

        private void OnEnable()
        {
            CoreLoop.OnTick += Tick;
        }

        private void OnDisable()
        {
            CoreLoop.OnTick -= Tick;
        }
    }
}