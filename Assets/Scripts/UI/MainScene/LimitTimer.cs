﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class LimitTimer : MonoBehaviour
    {
        [SerializeField] private int limitTime = 60;
        [SerializeField] private TextMeshProUGUI timeText = null;
        [SerializeField] private Color warningColor = Color.red;

        public bool IsGameOver { get; private set; } = false;
        private float elapsedTime = 0;

        void Start()
        {
            limitTime++;
            _Update();
            enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            _Update();
        }

        private void _Update()
        {
            if (!IsGameOver)
            {
                elapsedTime += Time.deltaTime;
                int time = (int)(limitTime - elapsedTime);

                if (time <= 10)
                {
                    if(time == 10)
                    {
                        SEPlayer.Instance.Play(SEEnum.Warning);
                    }
                    _ColorChange();
                }

                if (time <= 0)
                {
                    time = 0;
                    timeText.text = time.ToString();
                    IsGameOver = true;
                    enabled = false;
                }

                timeText.text = time.ToString();
            }
        }

        private void _ColorChange()
        {
            timeText.color = warningColor;
        }

        public void StopAudio()
        {
            SEPlayer.Instance.Stop(SEEnum.Warning);
        }
    }
}
