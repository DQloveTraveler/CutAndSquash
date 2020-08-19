using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;

    void Awake()
    {
        var camera = GetComponent<Camera>();
        var lb = camera.ViewportToWorldPoint(new Vector2(0, 0));
        lb.z = 0;
        var rt = camera.ViewportToWorldPoint(new Vector2(1, 1));
        rt.z = 0;
        var lt = new Vector3(lb.x, -lb.y, 0);
        var rb = new Vector3(-rt.x, rt.y, 0);

        Instantiate(wallPrefab, lb, Quaternion.identity);
        Instantiate(wallPrefab, lt, Quaternion.identity);
        Instantiate(wallPrefab, rt, Quaternion.Euler(0, 0, -90));
        Instantiate(wallPrefab, rb, Quaternion.Euler(0, 0, -90));
    }


}
