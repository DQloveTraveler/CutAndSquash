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
                    _StartCoroutine(_textScaleEffect(0.2f));
                }
                numString = value;
            }
        }

        private Coroutine _startingCoroutine = null;

        private void _StartCoroutine(IEnumerator enumerator)
        {
            if(_startingCoroutine != null)
            {
                StopCoroutine(_startingCoroutine);
            }
            _startingCoroutine = StartCoroutine(enumerator);
        }

        private IEnumerator _textScaleEffect(float duration)
        {
            float elapsedTime = 0;
            Vector3 maxScale = new Vector3(1, 1.3f, 1);
            for (; elapsedTime < duration / 2; elapsedTime += Time.deltaTime)
            {
                numText.transform.localScale = Vector3.Lerp(numText.transform.localScale, maxScale, 0.5f);
                yield return null;
            }
            numText.transform.localScale = maxScale;
            for (; elapsedTime < duration; elapsedTime += Time.deltaTime)
            {
                numText.transform.localScale = Vector3.Lerp(numText.transform.localScale, Vector3.one, 0.5f);
                yield return null;
            }
            numText.transform.localScale = Vector3.one;

        }

    }
}
