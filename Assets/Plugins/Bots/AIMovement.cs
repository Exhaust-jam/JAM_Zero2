using Plugins.RigidbodyMovement;
using UnityEngine.AI;

namespace Plugins.Bots
{
    public class AIMovement : Movement
    {
        private NavMeshAgent _agent;
        private float _stoppingDistance;
        
        public void SetAgent(NavMeshAgent agent)
        {
            _agent = agent;
            _stoppingDistance = _agent.stoppingDistance * _agent.stoppingDistance;
        }

        protected override void OnTick()
        {
            Move();
        }
        
        protected override void Move()
        {
            _agent.speed = _unitProperties.Speed.Value;
            var dist = _agent.transform.position - _input.GetKeyboardMovement();
            if (dist.sqrMagnitude > _stoppingDistance)
            {
                _agent.SetDestination(_input.GetKeyboardMovement());
            }
            _unitProperties.AnimationsProperties?.Move(_agent.velocity.magnitude);
        }
    }
}