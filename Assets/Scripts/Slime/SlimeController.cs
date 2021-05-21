using Slime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour, IPoolable
{
    #region serialize field
    [SerializeField] private float startSpeed = 10;
    [SerializeField] private Transform[] copyPoints = null;
    [SerializeField] private Collider2D coreCollider = null;
    [SerializeField] private Collider2D outCollider = null;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigid2D;
    #endregion


    private bool isCut = false;
    private SlimeAnimator slimeAnimator;
    private SlimeMover slimeMover;

    public ObjectPool Pool { get; set; }

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        SlimeManager.Instance.AddList(this);
        slimeAnimator = new SlimeAnimator(animator);
        slimeMover = new SlimeMover(startSpeed, rigid2D);
        outCollider.enabled = true;
        isCut = false;
        coreCollider.enabled = true;
        gameObject.SetActive(true);

        slimeMover.SetVelocity();
    }

    private void FixedUpdate()
    {
        slimeMover.FixedUpdate();
    }

    public void Cut()
    {
        if (!isCut)
        {
            SlimeManager.Instance.RemoveList(this);
            slimeAnimator.Cut();
            slimeMover.Stop();
            outCollider.enabled = false;
            isCut = true;
        }
    }

    public void Die()
    {
        GameManager.Instance.AddSquashedNum();
        SlimeManager.Instance.RemoveList(this);
        slimeAnimator.Die();
        slimeMover.Stop();
        outCollider.enabled = false;
    }

    public void Stop()
    {
        slimeMover.Stop();
        outCollider.enabled = false;
    }

    public void DesableAnimator()
    {
        slimeAnimator.Desable();
    }

    public void Sleep()
    {
        gameObject.SetActive(false);
    }



    #region AnimationEvent用メソッド
    public void PlayAudio()
    {
        SEPlayer.Instance.PlayOneShot(SEEnum.Slime);
    }

    public void CoreColliderOFF()
    {
        coreCollider.enabled = false;
    }

    public void CopySelf()
    {
        StartCoroutine(_CopySelf());
    }

    private IEnumerator _CopySelf()
    {
        foreach (var cp in copyPoints)
        {
            SlimeManager.Instance.Generate(cp);
        }
        yield return null;
        SlimeManager.Instance.Release(this);
    }

    public void DestroySelf()
    {
        SlimeManager.Instance.Release(this);
    }
    #endregion
}
