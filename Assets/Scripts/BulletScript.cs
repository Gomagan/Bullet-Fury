using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody _rb;
    private float _time = 0f;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _time += Time.deltaTime;
        _rb.AddForce(transform.up * 80f);

        if (_time >= 2f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("T1"))
        {
            Destroy(GameObject.Find("T1"));
        }
        else if (other.CompareTag("T2"))
        {
            Destroy(GameObject.Find("T2"));
        }
        else if (other.CompareTag("T3"))
        {
            Destroy(GameObject.Find("T3"));
        }
        else if (other.CompareTag("T4"))
        {
            Destroy(GameObject.Find("T4"));
        }
        else if (other.CompareTag("T5"))
        {
            Destroy(GameObject.Find("T5"));
        }
    }
}
