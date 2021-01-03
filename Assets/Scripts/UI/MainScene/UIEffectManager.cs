using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class UIEffectManager
{
    public static IEnumerator ScaleEffect(this TextMeshProUGUI tmp, float duration)
    {
        float elapsedTime = 0;
        Vector3 maxScale = new Vector3(1, 1.3f, 1);
        Transform transform = tmp.transform;
        for (; elapsedTime < duration / 2; elapsedTime += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, 0.5f);
            yield return null;
        }
        transform.localScale = maxScale;
        for (; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.5f);
            yield return null;
        }
        transform.localScale = Vector3.one;

    }

    public static IEnumerator ScaleEffect(this Text text, float duration)
    {
        float elapsedTime = 0;
        Vector3 maxScale = new Vector3(1, 1.3f, 1);
        Transform transform = text.transform;
        for (; elapsedTime < duration / 2; elapsedTime += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, 0.5f);
            yield return null;
        }
        transform.localScale = maxScale;
        for (; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.5f);
            yield return null;
        }
        transform.localScale = Vector3.one;

    }


}
