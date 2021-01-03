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
    private const float audioDelay_Lose = 1.5f;
    private const float audioDelay_Bad = 2;

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
        VoicePlayer.Instance.Play(VoiceEnum.CountDown, 0.1f);
        yield return _readyTimer.StartCountDown();
        VoicePlayer.Instance.Play(VoiceEnum.Start);
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
        VoicePlayer.Instance.Play(VoiceEnum.Finish);
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
        SEPlayer.Instance.Play(SEEnum.Lose, audioDelay_Lose);
        VoicePlayer.Instance.Play(VoiceEnum.Bad, audioDelay_Bad);
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

        SEPlayer.Instance.Play(SEEnum.Win);

        if (RSM.IsHighScore)
        {
            VoicePlayer.Instance.Play(VoiceEnum.Congratulations);
        }
        else
        {
            VoicePlayer.Instance.Play(VoiceEnum.Good);
        }
    }


}
