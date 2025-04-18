using System.Collections;
using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.InputHandler;
using UnityEngine;

namespace Plugins.PlayerController
{
    public class Run : IUnitComponent
    {
        private float _endurance;
        
        private Coroutine _runCoroutine;
        private Coroutine _enduranceRecoverCoroutine;
        private Coroutine _enduranceWasteCoroutine;
        
        private FPSProperties _properties;
        
        public void Init(UnitProperties unitProperties)
        {
            _properties = (FPSProperties)unitProperties;
        }

        public Run(IInput input)
        {
            input.RunnedDown += RunDown;
            input.RunnedUp += RunUp;
            input.Crouched += RunUp;
        }

        private IEnumerator RunRoutine(float targetVelocity)
        {
            var t = 0.0f;
            while (t <= _properties.Duration)
            {
                t += Time.deltaTime;
                _properties.Speed.Value = Mathf.Lerp(_properties.Speed.Value, targetVelocity, t / _properties.Duration);
                yield return null;
            }
        }

        private IEnumerator EnduranceWasteRoutine()
        {
            _endurance = _properties.Endurance;
            while (_properties.Endurance > 0)
            {
                _properties.Endurance = Mathf.MoveTowards(_properties.Endurance, 0, Time.deltaTime * _properties.EnduranceWaste);
                yield return null;
            }
            _properties.StopCoroutine(_runCoroutine);
            _runCoroutine = _properties.StartCoroutine(RunRoutine(_properties.StartSpeed.Value));
        }

        private IEnumerator EnduranceRecoverRoutine()
        {
            while (_properties.Endurance < _endurance)
            {
                _properties.Endurance = Mathf.MoveTowards(_properties.Endurance, _endurance, Time.deltaTime * _properties.EnduranceWaste);
                yield return null;
            }
        }

        private void RunDown()
        {
            if (_runCoroutine != null)
            {
                _properties.StopCoroutine(_runCoroutine);
            }

            if (_enduranceRecoverCoroutine != null)
            {
                _properties.StopCoroutine(_enduranceRecoverCoroutine);
            }
            _runCoroutine = _properties.StartCoroutine(RunRoutine(_properties.RunSpeed));
            _enduranceWasteCoroutine = _properties.StartCoroutine(EnduranceWasteRoutine());
        }

        private void RunUp()
        {
            if (_runCoroutine != null)
            {
                _properties.StopCoroutine(_runCoroutine);
            }
            if (_enduranceWasteCoroutine != null)
            {
                _properties.StopCoroutine(_enduranceWasteCoroutine);
            }
            _properties.Speed.Value = _properties.StartSpeed.Value;
            _enduranceRecoverCoroutine = _properties.StartCoroutine(EnduranceRecoverRoutine());
        }
    }
}