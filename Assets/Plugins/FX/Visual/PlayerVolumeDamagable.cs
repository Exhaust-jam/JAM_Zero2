using System.Collections;
using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Plugins.FX
{
    public class PlayerVolumeDamagable : MonoBehaviour, IUnitComponent
    {
        [SerializeField] private Volume _volume;
        [SerializeField] private float _effectDuration;
        [SerializeField] private float _effectIntencity;
        private Vignette _vignette;
        private float _startIntencity;
        private bool _active;

        private void Awake()
        {
            if (_volume.profile.TryGet(out Vignette vignette))
            {
                _vignette = vignette;
            }
        }

        public void Init(UnitProperties unitProperties)
        {
            unitProperties.CurrentHp.OnValueChanged += Show;
        }

        private void Show()
        {
            if (_active)
            {
                StopAllCoroutines();
            }
            StartCoroutine(ShowRoutine());
        }

        private IEnumerator ShowRoutine()
        {
            _active = true;
            float time = 0;
            while (time < _effectDuration)
            {
                _vignette.intensity.value = Mathf.Lerp(_startIntencity, _effectIntencity, time / _effectDuration);
                time += Time.deltaTime;
                yield return null;
            }

            time = 0;
            
            while (time < _effectDuration)
            {
                _vignette.intensity.value = Mathf.Lerp(_effectIntencity, _startIntencity, time / _effectDuration);
                time += Time.deltaTime;
                yield return null;
            }
            _active = false;
        }
    }
}