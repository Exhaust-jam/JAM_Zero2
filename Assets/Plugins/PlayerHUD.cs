using Plugins.CharacteristicsSystem;
using Plugins.HealthSystem;
using Plugins.LoopForge;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins
{
    public class PlayerHUD : MonoBehaviour, IUnitComponent
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private Image _abilityCooldown;
        [SerializeField] private TMP_Text _waveView;
        [SerializeField] private Arena.Arena _arena;
        
        private PlayerUnitProperties _unitProperties;
        
        public void Init(UnitProperties unitProperties)
        {
            _unitProperties = (PlayerUnitProperties)unitProperties;
            _unitProperties.CurrentHp.OnValueChanged += HealthUpdate;
        }

        private void OnTick()
        {
            CooldownUpdate();
        }

        private void HealthUpdate()
        {
            _healthBar.fillAmount = _unitProperties.CurrentHp.Value / _unitProperties.MaxHealth;
        }

        private void CooldownUpdate()
        {
            _abilityCooldown.fillAmount = (Time.time - _unitProperties.LastShootTime) /  _unitProperties.AbilityCooldown;
        }

        private void WaveUpdate()
        {
            _waveView.text = $"Wave: {_arena.CurrentWave}/{_arena.Waves}";
        }

        private void OnEnable()
        {
            CoreLoop.OnTick += OnTick;
            Arena.Arena.OnWaveStarted += WaveUpdate;
        }

        private void OnDisable()
        {
            CoreLoop.OnTick -= OnTick;
            Arena.Arena.OnWaveStarted -= WaveUpdate;
        }
    }
}