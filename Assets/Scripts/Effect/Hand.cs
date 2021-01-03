using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.5f;

    private Collider2D _collider;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    void Start()
    {
        Destroy(transform.root.gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root.TryGetComponent<SlimeController>(out var enemy))
        {
            enemy.Die();
        }
    }


    //AnimationEvent用メソッド
    public void Shake()
    {
        SEPlayer.Instance.PlayOneShot(SEEnum.Beat);
        CameraShaker.Instance.Shake(0.2f);
    }

    public void ColliderON()
    {
        _collider.enabled = true;
    }

    public void ColliderOFF()
    {
        _collider.enabled = false;
    }

}
