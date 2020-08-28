using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ScoreZeroPanel : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStart = null;
        [SerializeField] private UnityEvent onAnimation = null;

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
