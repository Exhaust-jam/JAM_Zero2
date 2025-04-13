using Plugins.Animations;
using Plugins.CharacteristicsSystem;
using Plugins.FX.Sound;
using UnityEngine;

namespace Plugins.Arena
{
    public class ArenaActivator : ZeroOutValues
    {
        [SerializeField] private Arena _arena;
        [SerializeField] private Tutorial _tutorial;
        [SerializeField] private UnitSoundsStorage _sounds;

        private Animator _animator;
        private AnimatorTriggerToggleEvent _pressedEvent;
        
        private bool _started;
        private bool _blocked;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _tutorial.Started += Toggle;

            var reciver = new ButtonActivatorPressed();
            _pressedEvent = new AnimatorTriggerToggleEvent(_animator.GetParameter(0).name, _animator);
            global::EventBus.EventBus.Subscribe<AnimatorTriggerToggleEvent>(reciver.OnPressed);
        }

        private void Toggle()
        {
            _sounds.Play(Sound.Background);
            _started = true;
            Activate();
            _tutorial.Started -= Toggle;
        }

        private void Activate()
        {
            if (_blocked) return;
            _arena.Round();
            Block();
        }

        public override void ToZero()
        {
            global::EventBus.EventBus.Publish(_pressedEvent);
            if (_started)
            {
               Activate();
            }
            else
            {
                _tutorial.NextStep();
            }
        }

        private void Block()
        {
            _blocked = true;
        }

        private void UnBlock()
        {
            _blocked = false;
        }

        private void OnEnable()
        {
            Arena.OnWaveDone += UnBlock;
        }

        private void OnDisable()
        {
            Arena.OnWaveDone -= UnBlock;
        }
    }
}