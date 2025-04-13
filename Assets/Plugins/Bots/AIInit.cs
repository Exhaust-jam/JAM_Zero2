using Plugins.CharacteristicsSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Plugins.Bots
{
    public class AIInit : MonoBehaviour
    {
        private Unit _unit;
        private AIController _aiController;

        public void Init(AIInput input, Unit unit, Transform player, AIController aiController)
        {
            foreach (var controllable in unit.Controllables)
            {
                switch (controllable)
                {
                    case AIMovement movement:
                        movement.SetAgent(unit.GetComponent<NavMeshAgent>());
                        movement.SetInput(input);
                        break;
                    case { } cont:
                        cont.SetInput(input);
                        break;
                }
            }
            input.Player = player;
            input.Unit = unit.transform;
            aiController.Init(player, input);
        }
    }
}