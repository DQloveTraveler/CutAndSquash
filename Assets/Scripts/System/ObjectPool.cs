using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private IPoolable originalPrefab;
    private Stack<IPoolable> pool = new Stack<IPoolable>();

    public void SetOriginal(IPoolable original) => originalPrefab = original;

    public GameObject Generate()
    {
        GameObject obj;
        if(pool.Count < 0)
        {
            obj = pool.Pop().gameObject;
        }
        else
        {
            obj = Instantiate(originalPrefab.gameObject);
        }
        obj.GetComponent<IPoolable>().SetUp();
        return obj;
    }

    public void Release(IPoolable poolable)
    {
        poolable.Sleep();
        pool.Push(poolable);
    }

    public void Clear() => pool.Clear();

    public void DestroyAll()
    {
        foreach(var poolable in pool)
        {
            if (poolable == null) continue;
            Destroy(poolable.gameObject);
        }
    }

}
