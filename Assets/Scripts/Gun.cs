using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCoolDown;

    private float _currentCooldown;
    void Start()
    {
        _currentCooldown = fireCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentCooldown <= 0)
            {
                onGunShoot?.Invoke();
                _currentCooldown = fireCoolDown;
            }
        }
        
        _currentCooldown -= Time.deltaTime;
    }
}
