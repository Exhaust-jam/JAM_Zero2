using System.Collections.Generic;
using Plugins.CharacteristicsSystem;
using UnityEngine;

namespace Plugins.Popup
{
    public class IconCharacteristicStorage : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _icons = new List<Sprite>();
        [SerializeField] private List<Characteristics> _characteristics = new List<Characteristics>();

        private static Dictionary<Characteristics, Sprite> _iconsDictionary = new Dictionary<Characteristics, Sprite>();
        
        public static Dictionary<Characteristics, Sprite>  IconsDictionary => _iconsDictionary;
        
        private void Awake()
        {
            _iconsDictionary.Clear();
            for (int i = 0; i < _icons.Count; i++)
            {
                _iconsDictionary.Add(_characteristics[i], _icons[i]);
            }
        }
    }
}