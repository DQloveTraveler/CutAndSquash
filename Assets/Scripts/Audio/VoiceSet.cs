using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VoiceSet
{
    [SerializeField] private VoiceEnum name;
    [SerializeField] private AudioSource audio = null;

    public VoiceEnum Name => name;
    public AudioSource Audio => audio;
}
