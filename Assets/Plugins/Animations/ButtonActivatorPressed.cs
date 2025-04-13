using UnityEngine;

namespace Plugins.Animations
{
    public class ButtonActivatorPressed
    {
        public void OnPressed(AnimatorTriggerToggleEvent ev)
        {
            ev.Animator.SetTrigger(ev.TransitionName);
        }
    }
}