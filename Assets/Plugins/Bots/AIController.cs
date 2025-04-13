using Plugins.FX.Sound;
using Plugins.LoopForge;
using UnityEngine;
using UnityEngine.AI;

namespace Plugins.Bots
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float _distanceToFireInit;
        
        private NavMeshAgent _agent;
        private Transform _player;
        private AIInput _aiInput;
        private float _distanceToFire;

        public void Init(Transform player, AIInput input)
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = player;
            _aiInput = input;
            _distanceToFire = _distanceToFireInit * _distanceToFireInit;
        }

        private void OnTick()
        {
            var dist = (_agent.transform.position - _player.position).sqrMagnitude;
            if (dist <= _agent.stoppingDistance)
            {
                _aiInput.RotateActive = true;
            }
            else
            {
                _aiInput.RotateActive = false;
            }
            if (dist <= _distanceToFire)
            {
                _aiInput.FireActive = true;
            }
            else
            {
                _aiInput.FireActive = false;
            }
        }

        private void OnEnable()
        {
            CoreLoop.OnFixedTick += OnTick;
        }

        private void OnDisable()
        {
            CoreLoop.OnFixedTick -= OnTick;
        }
    }
}