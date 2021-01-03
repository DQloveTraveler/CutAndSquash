using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyTimer
{
    private static float _readyCount;
    public static int ReadyCount => (int)_readyCount;

    public ReadyTimer(int readyTime)
    {
        _readyCount = readyTime + 0.99f;
    }

    public IEnumerator StartCountDown()
    {
        for (; ReadyCount > 0; _readyCount -= Time.deltaTime)
        {
            yield return null;
        }
        yield break;
    }
}
