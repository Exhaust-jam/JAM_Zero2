using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using Plugins.LoopForge;
using UnityEngine;

namespace Plugins
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Escape _escape;
        [SerializeField] private GameObject _hud;
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private Unit _playerUnit;
        [SerializeField] private Animator _gameOverAnimator;
        [SerializeField] private Animator _winPanelAnimator;
        [SerializeField] private string _gameOverAnimationTrigger;
        [SerializeField] private string _winPanelAnimationTrigger;
        [SerializeField] private UnitSoundsStorage _sounds;

        private void Awake()
        {
            _gameOverAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
            
            _playerUnit.OnDestroyed += Lose;
            Arena.Arena.OnVictory += Win;
        }

        private void Final()
        {
            _sounds.Stop(Sound.Background);
            CoreLoop.PauseOn();
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            _escape.enabled = false;
            _hud.SetActive(false);
            _gameOver.SetActive(true);
        }
        
        private void Lose(Unit unit)
        {
            Final();
            _sounds.Play(Sound.GameOver);
            _gameOverAnimator.SetTrigger(_gameOverAnimationTrigger);
        }

        private void Win()
        {
            Final();
            _sounds.Play(Sound.Win);
            _winPanelAnimator.SetTrigger(_winPanelAnimationTrigger);
        }
    }
}