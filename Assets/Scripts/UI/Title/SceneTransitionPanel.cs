using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace UI
{
    public class SceneTransitionPanel : MonoBehaviour
    {
        [SerializeField] private float interval = 0.02f;

        private List<Transform> childs = new List<Transform>();
        private Coroutine _startingCoroutine = null;

        void Awake()
        {
            foreach(var child in GetComponentsInChildren<Image>())
            {
                childs.Add(child.transform);
                child.gameObject.SetActive(false);
            }
        }

        public void StartTransition()
        {
            if (_startingCoroutine == null)
                _startingCoroutine = StartCoroutine(_StartTransition());
        }

        private IEnumerator _StartTransition()
        {
            var wait = new WaitForSeconds(interval);
            while(childs.Count > 0)
            {
                int randomValue = Random.Range(0, childs.Count);
                int randomAngle = Random.Range(0, 360);
                childs[randomValue].eulerAngles = new Vector3(0, 0, randomAngle);
                childs[randomValue].gameObject.SetActive(true);
                childs.RemoveAt(randomValue);
                if(childs.Count % 4 == 0) AudioManager.Instance.PlayOneShot(8);
                yield return wait;
            }
            SceneManager.LoadScene("MainScene");
        }

    }
}
