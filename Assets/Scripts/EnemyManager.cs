using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
{
    public bool IsGameOver => gameOverTimeCounter > 1;

    public static readonly int maxEnemyCount = 50;

    private List<SlimeController> enemies = new List<SlimeController>();
    public int SlimeCount => enemies.Count;

    private float gameOverTimeCounter = 0;

    void Update()
    {
        UpdateList();
        if (SlimeCount <= 0) gameOverTimeCounter += Time.deltaTime;
        else gameOverTimeCounter = 0;
    }

    public void AddList(SlimeController newSlime)
    {
        enemies.Add(newSlime);
    }

    public void RemoveList(SlimeController slime)
    {
        enemies.Remove(slime);
    }

    private void UpdateList()
    {
        if(enemies.Count > 0)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i] == null)
                {
                    enemies.RemoveAt(i);
                }
            }

            while(enemies.Count > maxEnemyCount)
            {
                Destroy(enemies[0].gameObject);
                enemies.RemoveAt(0);
            }
        }
    }

    public void StopAll()
    {
        foreach(var enemy in enemies)
        {
            enemy.Stop();
            enemy.StopAnimator();
        }
    }

}
