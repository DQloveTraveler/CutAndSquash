using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    private AudioSource[] _audioSources;


    protected override void Awake()
    {
        base.Awake();
        _audioSources = GetComponentsInChildren<AudioSource>();
    }

    public void Play(int audioNum)
    {
        if (!_audioSources[audioNum].isPlaying)
            _audioSources[audioNum].Play();
    }
    public void Play(int audioNum, float delay)
    {
        StartCoroutine(_Play(audioNum, delay));
    }

    private IEnumerator _Play(int audioNum, float delay)
    {
        if (!_audioSources[audioNum].isPlaying)
        {
            yield return new WaitForSeconds(delay);
            _audioSources[audioNum].Play();
        }
    }

    public void PlayOneShot(int audioNum)
    {
        _audioSources[audioNum].PlayOneShot(_audioSources[audioNum].clip);
    }

    public void Stop(int audioNum)
    {
        _audioSources[audioNum].Stop();
    }

}


