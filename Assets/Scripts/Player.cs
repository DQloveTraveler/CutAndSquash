using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slime;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject slashEffect;
    [SerializeField] private GameObject handEffect;

    private Camera _camera;
    private GameObject _instanceSlash = null;
    private GameObject _instanceHand = null;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_instanceSlash == null)
            {
                var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                _instanceSlash = Instantiate(slashEffect, mousePos, Quaternion.identity);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if(_instanceHand == null)
            {
                var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                _instanceHand = Instantiate(handEffect, mousePos, Quaternion.identity);
            }
        }
    }
}
