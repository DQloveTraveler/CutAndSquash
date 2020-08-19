using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ScoreZeroPanel : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStart;
        [SerializeField] private UnityEvent onAnimation;

        void Start()
        {
            onStart.Invoke();
        }

        public void OnAnimation()
        {
            onAnimation.Invoke();
        }

    }
}
