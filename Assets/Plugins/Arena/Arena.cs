using System;
using System.Collections.Generic;
using System.Collections;
using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Plugins.Arena
{
    public class Arena : MonoBehaviour
    {
        [SerializeField] private List<FactoriesContainer> _factories;
        [SerializeField] private int _waves = 3;
        [SerializeField] private int _unitsOnFirstWave = 3;
        [SerializeField] private float _spawnDuration = 1f;
        [SerializeField] private UnitSoundsStorage _sounds;
        
        private List<Unit> _units = new  List<Unit>();
        public static event Action OnWaveStarted;
        public static event Action OnWaveDone;
        public static event Action OnVictory;
        
        private int _currentWave = 0;
        
        public int CurrentWave => _currentWave;
        public int Waves => _waves;
        
        public void Round()
        {
            _sounds.Play(Sound.Wave);
            _currentWave++;
            OnWaveStarted?.Invoke();
            var units = _unitsOnFirstWave * _currentWave;
           // StartCoroutine(SpawnRoutine(_factories[_currentWave-1].FatalFactories, units));
        }

        private void OnKilled(Unit unit)
        {
            Destroy(unit.gameObject, 5f);
            _units.Remove(unit);
            if (_units.Count == 0)
            {
                if (_currentWave == _waves)
                {
                    OnVictory?.Invoke();
                    return;
                }
                OnWaveDone?.Invoke();
            }
        }
/*
        private IEnumerator SpawnRoutine(List<BotFactory> factories, int quota)
        {
            var duration = new WaitForSeconds(_spawnDuration);
            while (quota != 0)
            {
                quota--;
                int factNumber = Random.Range(0, factories.Count);
                var unit = factories[factNumber].Make();
                unit.OnDestroyed += OnKilled;
                _units.Add(unit);
                yield return duration;
            }
        }
        */
    }
}