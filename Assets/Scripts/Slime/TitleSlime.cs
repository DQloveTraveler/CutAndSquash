using Slime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSlime : MonoBehaviour
{
    #region AnimationEvent用メソッド
    public void PlayAudio()
    {
        SEPlayer.Instance.PlayOneShot(SEEnum.Slime);
    }
    public void CoreColliderOFF() {}
    public void CopyMe() {}
    public void DestroySelf() {}
    #endregion;
}
