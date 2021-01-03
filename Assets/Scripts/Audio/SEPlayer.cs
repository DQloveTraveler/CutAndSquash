using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SEEnum
{
    //SEs
    Beat, Slash, Slime, Click, Cancel, Warning, Lose, Win
}

public class SEPlayer : SingletonMonoBehaviour<SEPlayer>
{
    [SerializeField]
    private SESet[] audioList = null;

    private Dictionary<SEEnum, AudioSource> _audioDic = new Dictionary<SEEnum, AudioSource>();

    protected override void Awake()
    {
        base.Awake();
        foreach(var ses in audioList)
        {
            _audioDic.Add(ses.Name, ses.Audio);
        }
    }

    public void Play(SEEnum name)
    {
        if (!_audioDic[name].isPlaying)
            _audioDic[name].Play();
    }
    public void Play(SEEnum name, float delay)
    {
        StartCoroutine(_Play(name, delay));
    }
    private IEnumerator _Play(SEEnum name, float delay)
    {
        if (!_audioDic[name].isPlaying)
        {
            yield return new WaitForSeconds(delay);
            _audioDic[name].Play();
        }
    }
    public void PlayOneShot(SEEnum name)
    {
        _audioDic[name].PlayOneShot(_audioDic[name].clip);
    }
    public void PlayOneShot(int num)
    {
        SEEnum seName = (SEEnum)num;
        _audioDic[seName].PlayOneShot(_audioDic[seName].clip);
    }

    public void Stop(SEEnum name)
    {
        _audioDic[name].Stop();
    }

}

