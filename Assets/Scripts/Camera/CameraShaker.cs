using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : SingletonMonoBehaviour<CameraShaker>
{

    private readonly float randomMin = -1f;
    private readonly float randomMax = 1f;
    private static Coroutine _startingCoroutine = null;

    public void Shake(float duration)
    {
        if (_startingCoroutine != null) StopCoroutine(_startingCoroutine);
        _startingCoroutine = StartCoroutine(_Shake(duration));
    }
    private IEnumerator _Shake(float duration)
    {
        for(float elapsedTime = 0; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            float randomX = Random.Range(randomMin, randomMax);
            float randomY = Random.Range(randomMin, randomMax);

            transform.position = new Vector3(randomX, randomY, transform.position.z);

            yield return null;
        }
        transform.position = new Vector3(0, 0, transform.position.z);
    }
    public void Shake(float duration, float randomMin, float randomMax)
    {
        if (_startingCoroutine != null) StopCoroutine(_startingCoroutine);
        _startingCoroutine = StartCoroutine(_Shake(duration, randomMin, randomMax));
    }
    private IEnumerator _Shake(float duration, float randomMin, float randomMax)
    {
        for (float elapsedTime = 0; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            float randomX = Random.Range(randomMin, randomMax);
            float randomY = Random.Range(randomMin, randomMax);

            transform.position = new Vector3(randomX, randomY, transform.position.z);

            yield return null;
        }
        transform.position = new Vector3(0, 0, transform.position.z);
    }
}
