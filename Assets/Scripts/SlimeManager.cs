using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlimeManager : SingletonMonoBehaviour<SlimeManager>
{
    public bool IsGameOver => gameOverTimeCounter > 1;

    public static readonly int maxSlimeCount = 50;

    private List<SlimeController> slimes = new List<SlimeController>();
    public int SlimeCount => slimes.Count;

    private float gameOverTimeCounter = 0;

    void Update()
    {
        UpdateList();
        if (SlimeCount <= 0) gameOverTimeCounter += Time.deltaTime;
        else gameOverTimeCounter = 0;
    }

    public void AddList(SlimeController newSlime)
    {
        slimes.Add(newSlime);
    }

    public void RemoveList(SlimeController slime)
    {
        slimes.Remove(slime);
    }

    private void UpdateList()
    {
        if(slimes.Count > 0)
        {
            foreach(var slime in slimes)
            {
                if (slime == null)
                {
                    slimes.Remove(slime);
                }
            }

            while(slimes.Count > maxSlimeCount)
            {
                Destroy(slimes[0].gameObject);
                slimes.RemoveAt(0);
            }
        }
    }

    public void StopAll()
    {
        foreach(var enemy in slimes)
        {
            enemy.Stop();
            enemy.StopAnimator();
        }
    }

}
