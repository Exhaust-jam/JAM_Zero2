using Plugins.CharacteristicsSystem;
using UnityEngine;

namespace Plugins.Bots
{
    public class BotFactory : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Unit _unit;

        private Transform _player;
        
        public void Init(Transform player)
        {
            _player = player;
        }

        public void Set(Unit unit)
        {
            _unit = unit;
        }

        public Unit Make()
        {
            var newUnit = Instantiate(_unit, _spawnPoint.position, Quaternion.identity);
            newUnit.Init();
            var aiInput = newUnit.GetComponent<AIInput>();
            var aiContoller = newUnit.GetComponent<AIController>();
            var aiInit = newUnit.GetComponent<AIInit>();
            aiInit.Init(aiInput, newUnit, _player, aiContoller);
            return newUnit;
        }
    }
}