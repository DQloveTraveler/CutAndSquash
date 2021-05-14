using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public ObjectPool Pool { get; set; }
    public GameObject gameObject { get; }
    public void SetUp();
    public void Sleep();
}
