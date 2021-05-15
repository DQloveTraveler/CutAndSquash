using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlimeManager : SingletonMonoBehaviour<SlimeManager>
{
    #region serialize field
    [SerializeField] private SlimeController slimePrefab;
    [SerializeField] private ObjectPool slimePool;
    #endregion

    public bool IsGameOver => gameOverTimeCounter > 1;
    public static readonly int maxSlimeCount = 100;
    private readonly List<SlimeController> slimes = new List<SlimeController>();
    public int SlimeCount => slimes.Count;
    private float gameOverTimeCounter = 0;


    #region unity function
    protected override void Awake()
    {
        base.Awake();
        slimePool.SetOriginal(slimePrefab);
    }

    void Update()
    {
        UpdateList();
        if (SlimeCount <= 0)
        {
            gameOverTimeCounter += Time.deltaTime;
        }
        else
        {
            gameOverTimeCounter = 0;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach(var sc in slimes)
            {
                Debug.Log(sc.name);
            }
        }
    }
    #endregion

    #region function
    public void Generate(Transform generatePoint) => slimePool.Generate(generatePoint);

    public void Release(SlimeController slime) => slimePool.Release(slime);

    public void ClearPool() => slimePool.Clear();

    public void DestroyAll() => slimePool.DestroyAll();

    public void AddList(SlimeController newSlime)
    {
        if (!slimes.Contains(newSlime))
        {
            slimes.Add(newSlime);
        }
    }

    public void RemoveList(SlimeController slime)
    {
        slimes.Remove(slime);
    }

    private void UpdateList()
    {
        if(slimes.Count > 0)
        {
            foreach(var sc in slimes)
            {
                if (!sc.gameObject.activeSelf)
                {
                    slimes.Remove(sc);
                }
            }

            while(slimes.Count > maxSlimeCount)
            {
                slimePool.Release(slimes[0]);
                slimes.RemoveAt(0);
            }
        }
    }

    public void StopAll()
    {
        foreach(var sc in slimes)
        {
            sc.Stop();
            sc.DesableAnimator();
        }
    }
    #endregion
}
