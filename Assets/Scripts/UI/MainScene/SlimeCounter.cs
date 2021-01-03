using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

namespace UI
{
    public abstract class SlimeCounter : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI numText;

        private const float _effectDuration = 0.2f;

        private string numString = string.Empty;
        protected string NumString
        {
            get
            {
                return numString;
            }
            set
            {
                if (numString != value)
                {
                    _StartCoroutine(numText.ScaleEffect(_effectDuration));
                }
                numString = value;
            }
        }

        private Coroutine _effectCoroutine = null;

        private void _StartCoroutine(IEnumerator enumerator)
        {
            if(_effectCoroutine != null)
            {
                StopCoroutine(_effectCoroutine);
            }
            _effectCoroutine = StartCoroutine(enumerator);
        }

    }
}
