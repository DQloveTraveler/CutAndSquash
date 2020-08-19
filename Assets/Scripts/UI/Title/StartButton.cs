using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartButton : MonoBehaviour
    {

        public void GameStart()
        {
            SceneManager.LoadScene("MainScene");
        }

    }
}
