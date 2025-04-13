using UnityEngine;

namespace Plugins.Animations
{
    public class AnimatorTriggerToggleEvent : AnimatorToggleEvent
    {
        public AnimatorTriggerToggleEvent(string transitionName, Animator animator) : base(transitionName, animator, Transition.Trigger)
        {
        }
    }
}