using UnityEngine;

namespace Plugins.Animations
{
    public class AnimatorFloatToggleEvent<T> : AnimatorToggleEvent
    {
        private T _value;
        
        public T Value => _value;
        
        public AnimatorFloatToggleEvent(string transitionName, Animator animator) : base(transitionName, animator, Transition.Float)
        {
        }
    }
}