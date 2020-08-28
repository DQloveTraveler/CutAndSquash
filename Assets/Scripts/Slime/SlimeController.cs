using Slime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    [SerializeField] private GameObject slimePrefab = null;
    [SerializeField] private Transform[] copyPoints = null;
    [SerializeField] private Collider2D coreCollider = null;

    private bool IsCut { get; set; } = false;

    private SlimeAnimator _slimeAnimator;
    private SlimeMover _slimeMover;
    private Collider2D _collider;

    void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        SlimeManager.Instance.AddList(this);
        _slimeAnimator = new SlimeAnimator(GetComponent<Animator>());
        _slimeMover = GetComponent<SlimeMover>();
        _collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        coreCollider.enabled = true;
        _collider.enabled = true;
        IsCut = false;
    }


    public void Cut()
    {
        if (!IsCut)
        {
            SlimeManager.Instance.RemoveList(this);
            _slimeAnimator.Cut();
            _slimeMover.Stop();
            _collider.enabled = false;
            IsCut = true;
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
        AudioManager.Instance.PlayOneShot(8);
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
