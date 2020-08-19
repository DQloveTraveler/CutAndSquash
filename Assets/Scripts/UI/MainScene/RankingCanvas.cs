using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingCanvas : MonoBehaviour
{
    public void PlayAudio(int audioNum)
    {
        AudioManager.Instance.Play(audioNum);
    }
}
