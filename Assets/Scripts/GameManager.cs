using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UI;
using naichilab;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public int SquashedNum { get; private set; } = 0;
    public bool IsGameOver { get; private set; } = false;

    private Player _player;
    private LimitTimer _limitTimer;
    private CanvasController _canvasController;
    private ReadyTimer _readyTimer = new ReadyTimer(3);

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _limitTimer = FindObjectOfType<LimitTimer>();
        _canvasController = FindObjectOfType<CanvasController>();
        StartCoroutine(_readyState());
    }

    private IEnumerator _readyState()
    {
        AudioManager.Instance.Play(0, 0.1f);
        yield return _readyTimer.StartCountDown();
        AudioManager.Instance.Play(1);
        BGMPlayer.Instance.Play(1);
        _player.enabled = true;
        _limitTimer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(SlimeManager.Instance.IsGameOver|| _limitTimer.IsGameOver)
        {
            if (!IsGameOver) StartCoroutine(_GameOver());
        }
    }

    public void AddSquashedNum()
    {
        SquashedNum++;
    }

    private IEnumerator _GameOver()
    {
        IsGameOver = true;
        _limitTimer.StopAudio();
        _limitTimer.enabled = false;
        AudioManager.Instance.Play(2);
        BGMPlayer.Instance.Stop();
        _canvasController.GameOver();
        Destroy(_player);

        yield return _WaitClick(1);

        if(SlimeManager.Instance.SlimeCount > 0)
        {
            _ScoreZero();
        }
        else
        {
            StartCoroutine(_CallRanking());
        }
    }
    private IEnumerator _WaitClick(float delay)
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            if (Input.GetMouseButtonDown(0)) yield break;
            yield return null;
        }
    }

    private void _ScoreZero()
    {
        AudioManager.Instance.Play(12, 1.5f);
        AudioManager.Instance.Play(3, 2);
        _canvasController.ScoreZero();
    }

    private IEnumerator _CallRanking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(SquashedNum);
        _canvasController.onCallRanking.Invoke();

        RankingSceneManager RSM = null;
        while(RSM == null)
        {
            RSM = FindObjectOfType<RankingSceneManager>();
            yield return null;
        }

        AudioManager.Instance.Play(13);

        if (RSM.IsHighScore)
        {
            AudioManager.Instance.Play(5);
        }
        else
        {
            AudioManager.Instance.Play(4);
        }
    }


}
