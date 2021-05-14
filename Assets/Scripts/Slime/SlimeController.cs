using Slime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private float startSpeed = 10;
    [SerializeField] private GameObject slimePrefab = null;
    [SerializeField] private Transform[] copyPoints = null;
    [SerializeField] private Collider2D coreCollider = null;

    private bool isCut = false;

    private SlimeAnimator _slimeAnimator;
    private SlimeMover _slimeMover;
    private Collider2D _collider;


    private void Awake()
    {
        SetUp();
    }

    private void Start()
    {
        _slimeMover.SetUpVelocity();
    }

    private void SetUp()
    {
        SlimeManager.Instance.AddList(this);
        _slimeAnimator = new SlimeAnimator(GetComponent<Animator>());
        _slimeMover = new SlimeMover(startSpeed, GetComponent<Rigidbody2D>());
        _collider = GetComponent<Collider2D>();
        coreCollider.enabled = true;
        _collider.enabled = true;
        isCut = false;
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

    public void StopAnimator()
    {
        _slimeAnimator.Stop();
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

    public void CopyMe()
    {
        StartCoroutine(_CopyMe());
    }

    private IEnumerator _CopyMe()
    {
        foreach (var cp in copyPoints)
        {
            Instantiate(slimePrefab, cp.position, cp.rotation);
        }
        yield return null;
        Destroy(gameObject);
    }

    public void DestroySelf()
    {
        Destroy(transform.root.gameObject);
    }
    #endregion
}
