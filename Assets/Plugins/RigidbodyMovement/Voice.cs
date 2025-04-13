using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using Plugins.HealthSystem;
using Plugins.LoopForge;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plugins.RigidbodyMovement
{
    public class Voice : MonoBehaviour, IUnitComponent
    {
        [SerializeField] private Vector2 _timeToVoiceRange;

        private float _lastTimeVoicePlayed;
        private float _delay;
        private UnitProperties _unitProperties;

        private void Awake()
        {
            _lastTimeVoicePlayed = Time.time;
        }

        public void Init(UnitProperties unitProperties)
        {
            _unitProperties = unitProperties;
            _delay = Random.Range(_timeToVoiceRange.x, _timeToVoiceRange.y);
        }

        private void OnTick()
        {
            if (_lastTimeVoicePlayed + _delay <= Time.time)
            {
                _unitProperties.UnitSoundsStorage.Play(Sound.Voice);
                _delay = Random.Range(_timeToVoiceRange.x, _timeToVoiceRange.y);
                _lastTimeVoicePlayed = Time.time;
            } 
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