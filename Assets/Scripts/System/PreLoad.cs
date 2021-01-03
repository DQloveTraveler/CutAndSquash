using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoad : MonoBehaviour
{
    //UnityRoomはゲーム画面をクリックしないと音がならないという仕様のため
    //クリック待ちをしている
    IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0)) break;
            yield return null;
        }
        SceneManager.LoadScene("Title");
    }

}
