using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject target, point1, point2;

    public float speed;
    
    private bool _goingDown;
    private float _timer = 0f;
    

    private void Start()
    {
        //target.transform.position = new Vector3(target.transform.position.x, point2.transform.position.y, target.transform.position.z); ;
    }

    void Update()
    {
        if (_goingDown)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, point2.transform.position, Time.deltaTime * speed);
        }
        else
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, point1.transform.position, Time.deltaTime * speed);
        }
        
        _timer += Time.deltaTime;
        if (_timer >= 2f)
        {
            _goingDown = !_goingDown;
            _timer = 0f;
        }
    }
}
