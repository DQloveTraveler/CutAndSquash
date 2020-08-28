using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI readyText = null;
        [SerializeField] private GameObject gameOverPanel = null;
        [SerializeField] private GameObject scoreZeroPanel = null;
        [Space]
        [SerializeField] public UnityEvent onCallRanking = null;

        private Coroutine _coroutine;

        void Awake()
        {
            gameOverPanel.SetActive(false);
        }

        void Update()
        {
            _ReadyTextUpdate();
        }

        private void _ReadyTextUpdate()
        {
            if (readyText.gameObject.activeSelf)
            {
                var count = ReadyTimer.ReadyCount;
                switch (count)
                {
                    case 0:
                        readyText.text = "スタート";
                        if (_coroutine == null)
                            _coroutine = StartCoroutine(_SetActive(readyText.gameObject, false, 0.9f));
                        break;
                    default:
                        readyText.text = count.ToString();
                        break;
                }
            }
        }

        private IEnumerator _SetActive(GameObject obj, bool value, float delay)
        {
            yield return new WaitForSeconds(delay);
            obj.SetActive(value);
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
        }

        public void ScoreZero()
        {
            scoreZeroPanel.SetActive(true);
        }

    }
}
