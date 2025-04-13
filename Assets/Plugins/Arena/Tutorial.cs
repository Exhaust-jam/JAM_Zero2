using System;
using Plugins.CharacteristicsSystem;
using Plugins.Popup;
using TMPro;
using UnityEngine;

namespace Plugins.Arena
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private int _countTutorialSteps = 3;
        [SerializeField] private string[] _messages;
        [SerializeField] private Characteristics[] _characteristics;
        [SerializeField] private TMP_Text _view;
        [SerializeField] private Transform _iconViewPoint;
        
        private int _tutorialStep = 0;
        
        public event Action Started;

        public void NextStep()
        {
            if (_tutorialStep == _countTutorialSteps)
            {
                Started?.Invoke();
                _view.gameObject.SetActive(false);
                return;
            }
            PopupFactory.Make(_iconViewPoint.position ,IconCharacteristicStorage.IconsDictionary[_characteristics[_tutorialStep]]);
            string result = $"Characteristic: {_characteristics[_tutorialStep]}\n";
            result += _messages[_tutorialStep];
            _view.text = result;
            _tutorialStep++;
        }
    }
}