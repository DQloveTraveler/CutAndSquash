using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingCanvas : MonoBehaviour
{
    public void PlayAudio(SEEnum name)
    {
        SEPlayer.Instance.Play(name);
    }
}
