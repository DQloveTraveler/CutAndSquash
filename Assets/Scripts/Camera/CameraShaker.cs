using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraShaker
{

    private const float _randomMin = -1f;
    private const float _randomMax = 1f;
    private static Coroutine _startingCoroutine = null;

    public static void Shake(this Camera camera, float duration)
    {
        if (_startingCoroutine != null)
        {
            CoroutineHandler.StopStaticCoroutine(_startingCoroutine);
        }
        _startingCoroutine = CoroutineHandler.StartStaticCoroutine(_Shake(camera.transform, duration));
    }

    private static IEnumerator _Shake(Transform cameraT, float duration)
    {
        for(float elapsedTime = 0; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            float randomX = Random.Range(_randomMin, _randomMax);
            float randomY = Random.Range(_randomMin, _randomMax);

            cameraT.position = new Vector3(randomX, randomY, cameraT.position.z);

            yield return null;
        }
        cameraT.position = new Vector3(0, 0, cameraT.position.z);
    }

}
