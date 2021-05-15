using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class SlimeAnimator
    {

        private Animator _animator;

        public SlimeAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void Cut() => _animator.SetTrigger("Cut");

        public void Die() => _animator.SetTrigger("Die");

        public void Enable() => _animator.enabled = true;

        public void Desable() => _animator.enabled = false;

    }
}
