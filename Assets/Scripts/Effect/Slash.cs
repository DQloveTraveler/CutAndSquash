using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.12f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        AudioManager.Instance.PlayOneShot(7);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.TryGetComponent<SlimeController>(out var enemy))
        {
            enemy.Cut();
        }
    }
}
