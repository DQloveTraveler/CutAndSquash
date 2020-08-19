using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoad : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(_WaitClick());
    }

    private IEnumerator _WaitClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0)) break;
            yield return null;
        }
        SceneManager.LoadScene("Title");
    }

}
