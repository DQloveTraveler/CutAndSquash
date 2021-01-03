using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VoiceEnum
{
    //Voices
    CountDown, Start, Finish, Bad, Good, Congratulations,
}

public class VoicePlayer : SingletonMonoBehaviour<VoicePlayer>
{
    [SerializeField]
    private VoiceSet[] audioList = null;

    private Dictionary<VoiceEnum, AudioSource> _audioDic = new Dictionary<VoiceEnum, AudioSource>();

    protected override void Awake()
    {
        base.Awake();

        foreach(var AS in audioList)
        {
            _audioDic.Add(AS.Name, AS.Audio);
        }
    }

    public void Play(VoiceEnum name)
    {
        if (!_audioDic[name].isPlaying)
            _audioDic[name].Play();
    }
    public void Play(VoiceEnum name, float delay)
    {
        StartCoroutine(_Play(name, delay));
    }
    private IEnumerator _Play(VoiceEnum name, float delay)
    {
        if (!_audioDic[name].isPlaying)
        {
            yield return new WaitForSeconds(delay);
            _audioDic[name].Play();
        }
    }

    public void PlayOneShot(VoiceEnum name)
    {
        _audioDic[name].PlayOneShot(_audioDic[name].clip);
    }

    public void Stop(VoiceEnum name)
    {
        _audioDic[name].Stop();
    }

}
