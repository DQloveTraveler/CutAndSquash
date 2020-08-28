using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Animator canvas1 = null;
    [SerializeField] private Animator canvas2 = null;
    [Space]
    [SerializeField] private UnityEvent clickEvent = null;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_WaitClick());
        BGMPlayer.Instance.Play(3.3f);
    }

    private IEnumerator _WaitClick()
    {
        yield return new WaitForSeconds(4);
        while (true)
        {
            if (Input.GetMouseButtonDown(0)) break;
            yield return null;
        }

        clickEvent.Invoke();
        canvas1.SetTrigger("Next");
        canvas2.SetTrigger("Activate");
    }


}
