using System.Collections;
using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using UnityEngine;

namespace Plugins.FX
{
    public class Damagable : MonoBehaviour, IUnitComponent
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private string _signColorPropertyName = "_SignColor";
        [SerializeField] private float _signDuration = 0.1f;

        private Material _mat;
        private UnitProperties _properties;
        
        public void Init(UnitProperties unitProperties)
        {
            _properties = unitProperties;
            _mat = _renderer.material;
            _properties.CurrentHp.OnValueChanged += Sign;
        }

        private IEnumerator SignRoutine()
        {
            _mat.SetColor(_signColorPropertyName, Color.white);
            yield return new WaitForSeconds(_signDuration);
            _mat.SetColor(_signColorPropertyName, Color.black);
        }
        
        private void Sign()
        {
            if (_properties.CurrentHp.Value <= 0) return;
            StartCoroutine(SignRoutine());
        }
    }
}