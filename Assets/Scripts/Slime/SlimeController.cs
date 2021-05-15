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
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    #endregion


    private bool isCut = false;
    private SlimeAnimator _slimeAnimator;
    private SlimeMover _slimeMover;
    private Collider2D _collider;

    public ObjectPool Pool { get; set; }

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        SlimeManager.Instance.AddList(this);
        _slimeAnimator = new SlimeAnimator(animator);
        _slimeMover = new SlimeMover(startSpeed, rigidbody2D);
        _collider = GetComponent<Collider2D>();
        _collider.enabled = true;
        isCut = false;
        coreCollider.enabled = true;
        gameObject.SetActive(true);

        _slimeMover.SetVelocity();
    }

    private void FixedUpdate()
    {
        _slimeMover.FixedUpdate();
    }

    public void Cut()
    {
        if (!isCut)
        {
            SlimeManager.Instance.RemoveList(this);
            _slimeAnimator.Cut();
            _slimeMover.Stop();
            _collider.enabled = false;
            isCut = true;
        }
    }

    public void Die()
    {
        GameManager.Instance.AddSquashedNum();
        SlimeManager.Instance.RemoveList(this);
        _slimeAnimator.Die();
        _slimeMover.Stop();
        _collider.enabled = false;
    }

    public void Stop()
    {
        _slimeMover.Stop();
        _collider.enabled = false;
    }

    public void DesableAnimator()
    {
        _slimeAnimator.Desable();
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
