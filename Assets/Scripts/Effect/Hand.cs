using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.5f;
    [SerializeField] private Collider2D myCollider = null;

    private readonly float _cameraShakeDuration = 0.2f;

    void Awake()
    {
        myCollider.enabled = false;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(transform.root.gameObject);
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
        Camera.main.Shake(_cameraShakeDuration);
    }

    public void ColliderON()
    {
        myCollider.enabled = true;
    }

    public void ColliderOFF()
    {
        myCollider.enabled = false;
    }

}
