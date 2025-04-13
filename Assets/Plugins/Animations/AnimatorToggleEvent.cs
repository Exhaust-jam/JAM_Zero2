using Plugins.EventBus;
using UnityEngine;

namespace Plugins.Animations
{
    public class AnimatorToggleEvent : IEvent
    {
        protected string _transitionName;
        protected Animator _animator;
        protected Transition _transition;
        
        public Animator Animator => _animator;
        public string TransitionName => _transitionName;
        public Transition Transition => _transition;

        public AnimatorToggleEvent(string transitionName, Animator animator, Transition transition)
        {
            _animator = animator;
            _transition = transition;
            _transitionName = transitionName;
        }
    }
}