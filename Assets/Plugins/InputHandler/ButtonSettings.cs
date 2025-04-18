using System.Collections.Generic;
using UnityEngine;

namespace Plugins.InputHandler
{
    [CreateAssetMenu(fileName = "ButtonSettings", menuName = "Plugins/InputHandler/ButtonSettings")]
    public class ButtonSettings : ScriptableObject
    {
        [SerializeField] private List<CommandSet> _commands;
        private Dictionary<ControlCommand, CommandSet> _commandsMap = new Dictionary<ControlCommand, CommandSet>();
        public IReadOnlyDictionary<ControlCommand, CommandSet> CommandsMap => _commandsMap;

        private void OnEnable()
        {
            foreach (var commandSet in _commands)
            {
                _commandsMap.Add(commandSet.Command, commandSet);
            }
        }
    }
}