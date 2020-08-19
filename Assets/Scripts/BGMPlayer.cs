using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : SingletonMonoBehaviour<BGMPlayer>
{
    private AudioSource _audiosource;
    private float maxVolume = 0;

    protected override void Awake()
    {
        base.Awake();
        _audiosource = GetComponent<AudioSource>();
        maxVolume = _audiosource.volume;
    }

    public void Play()
    {
        _audiosource.volume = maxVolume;
        _audiosource.Play();
    }

    public void Play(float delay)
    {
        _audiosource.volume = maxVolume;
        StartCoroutine(_Play(delay));
    }

    private IEnumerator _Play(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audiosource.Play();
    }

    public void Stop()
    {
        StartCoroutine(_Stop());
    }

    private IEnumerator _Stop()
    {
        var wait = new WaitForSeconds(0.2f);
        while(_audiosource.volume > maxVolume / 10)
        {
            _audiosource.volume -= maxVolume / 10;
            yield return wait;
        }
        _audiosource.Stop();
    }


}
