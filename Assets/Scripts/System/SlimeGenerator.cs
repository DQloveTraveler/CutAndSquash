using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGenerator : SingletonMonoBehaviour<SlimeGenerator>
{
    [SerializeField] private SlimeController slimePrefab;

    public void Generate(Transform generatePoint)
    {
        var slime = Instantiate(slimePrefab.gameObject, generatePoint.position, generatePoint.rotation);
    }



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
