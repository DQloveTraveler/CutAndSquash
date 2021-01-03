using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SESet
{
    [SerializeField] private SEEnum name;
    [SerializeField] private AudioSource audio = null;

    public SEEnum Name => name;
    public AudioSource Audio => audio;
}
