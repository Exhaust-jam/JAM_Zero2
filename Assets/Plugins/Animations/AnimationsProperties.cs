using UnityEngine;

namespace Plugins.Animations
{
    public class AnimationsProperties : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _deathTrigger;
        [SerializeField] private string _moveFloat;
        [SerializeField] private string _fireTrigger;
        [SerializeField] private string _takeDamageTrigger;

        public void Die()
        {
            _animator.SetTrigger(_deathTrigger);
        }

        public void Move(float speed)
        {
            _animator.SetFloat(_moveFloat, speed);
        }

        public void Fire()
        {
            _animator.SetTrigger(_fireTrigger);
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(_takeDamageTrigger);
        }
    }
}