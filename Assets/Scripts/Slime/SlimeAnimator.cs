using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slime
{
    public class SlimeAnimator : MonoBehaviour
    {

        private Animator _animator;


        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Cut()
        {
            _animator.SetTrigger("Cut");
        }

        public void Die()
        {
            _animator.SetTrigger("Die");
        }

        public void Stop()
        {
            _animator.enabled = false;
        }

    }
}
