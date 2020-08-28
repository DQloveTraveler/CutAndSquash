using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace UI
{
    public class LivingSlimeCounter : SlimeCounter
    {
        // Update is called once per frame
        void Update()
        {
            NumString = SlimeManager.Instance.SlimeCount.ToString();
            numText.text = NumString;
        }
    }
}
