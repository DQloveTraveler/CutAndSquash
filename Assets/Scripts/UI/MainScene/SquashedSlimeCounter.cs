using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

namespace UI
{
    public class SquashedSlimeCounter : SlimeCounter
    {
        // Update is called once per frame
        void Update()
        {
            NumString = GameManager.Instance.SquashedNum.ToString();
            numText.text = NumString;
        }
    }
}
